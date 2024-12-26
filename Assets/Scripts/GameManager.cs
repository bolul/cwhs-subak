using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
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
    private TextMeshProUGUI RankingText;
    [SerializeField]
    private GameObject gameOverPanel;
    [SerializeField]
    private GameObject rankingPanel;
    [SerializeField]
    private TMP_InputField NameInputField;
    [SerializeField]
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
        rankingPanel.SetActive(true);
        string str = "";// idx 0 ~ idx 5까지 출력
        for (int i = 0; i < 5; i++)
        {
           str +=  $"  {i + 1}.      {PlayerPrefs.GetString(i+"n")}                                    {PlayerPrefs.GetInt(i+"s")}\n";
           
        }
        str += $"\n           현재 나의 점수는?!            "+PlayerPrefs.GetInt("currentScore")+"\n";
        RankingText.SetText(str);// 현재 자신의 점수 출력



    }

    public void PlayRecordButtonClick() {
        // 이미 저장됨 ->
        if (isSaved == true)
        {
            return;
        }

        // 저장안됨 ->
        NameInputField.gameObject.SetActive(true);
        isSaved = true;
        
    }
    public void RankingExitbutton() {
        rankingPanel.SetActive(false);
    }

    public void SubmitName()
    {
        currentName = NameInputField.text;

        // 입력값이 유효한지 확인 (최대 5글자로 제한)
        if (currentName.Length > 3)
        {
            currentName = currentName.Substring(0, 3);
        }

        Debug.Log($"입력된 이름: {currentName}");

        // 입력창 비활성화
        NameInputField.gameObject.SetActive(false);
        SetRanking();
    }
}   

