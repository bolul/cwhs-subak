using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private Animator animator;

    public static GameManager instance = null;
    [SerializeField]
    private TextMeshProUGUI InGameScoreText;
    [SerializeField]
    private TextMeshProUGUI ScoreText;
    [SerializeField]
    private TextMeshProUGUI PlayTimeText;
    [SerializeField]
    private GameObject gameOverPanel;

    [HideInInspector]
    public bool isGameOver = false;
    public bool isSaved = false; // 랭킹에 저장되었는지 확인
    public bool setTimer = false;
    private int score = 0;
    private int currentScore;
    private string currentName = "gunho";
    private float playTime = 0f;
    private int playMin = 0;
    private int playSec = 0;
    private int rankingSize = 5; // 랭킹에 들어가는 인원 수
    void Update()
    {
        if (setTimer == true)
        {
            playTime += Time.deltaTime;
        }
    }

    void Awake() {
        if (instance == null)
        {
            instance = this;
        }
    }
    public void IncreaseScore(int fruitIdx) {
        if (isGameOver == false)
        {
            score += (fruitIdx+1)*(fruitIdx+2)/2;
            InGameScoreText.SetText(score.ToString());
        }
    }
    public void SetTimer() {
        // 타이머 시작
        setTimer = true;
    }
    public void SetGameOver() {
        if (isGameOver == false) animator.SetTrigger("Playpanel");
        isGameOver = true;
        Invoke("ShowGameOverPanel", 1f);
        currentScore = score;
        PlayerPrefs.SetInt("currentScore", currentScore);
        PlayerPrefs.SetString("currentName", currentName);

    }
    public void SetRanking() {

        int[] bestScore = new int[5];
        string[] bestName = new string[5];
        int tmpScore;
        string tmpName;

        for(int i = 0; i < rankingSize; i++)
        {
            bestScore[i] = PlayerPrefs.GetInt(i+"s");
            bestName[i] = PlayerPrefs.GetString(i+"n");

            if (bestScore[i] <= currentScore)
            {
                tmpScore = bestScore[i];
                tmpName = bestName[i];
                bestScore[i] = currentScore;
                bestName[i] = currentName;

                currentScore = tmpScore;
                currentName = tmpName;
            }
        }
        for(int i = 0; i < rankingSize; i++)
        {
            PlayerPrefs.SetInt(i+"s", bestScore[i]);
            PlayerPrefs.SetString(i+"n", bestName[i]);
        }

    }

    void ShowGameOverPanel() {
        gameOverPanel.SetActive(true);
        ScoreText.SetText(currentScore.ToString());
        playMin = (int)playTime / 60;
        playSec = (int)playTime % 60;
        PlayTimeText.SetText(playMin.ToString()+"M      "+playSec.ToString()+"S");
        setTimer = false;
    }


// 게임오버 패널 버튼 이벤트 핸들러
    public void MenuButtonClick() {
        SceneManager.LoadScene("Mainscene");
    }

    public void RankingButtonClick() {
        // idx 0 ~ idx 5까지 출력
        for (int i = 0; i < 5; i++)
        {
            Debug.Log(PlayerPrefs.GetString(i+"n")+" : "+PlayerPrefs.GetInt(i+"s"));
        }
        // 현재 자신의 점수 출력
        Debug.Log("나 : "+PlayerPrefs.GetInt("currentScore"));
    }

    public void PlayRecordButtonClick() {
        // 이미 저장됨 ->
        if (isSaved == true)
        {
            Debug.Log("이미 저장됨.");
            return;
        }

        // 저장안됨 ->
        Debug.Log("랭킹에 등록할 이름 입력 -> gunho");
        SetRanking();
        isSaved = true;
    }
}
