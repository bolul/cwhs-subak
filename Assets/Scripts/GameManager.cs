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
    public bool setTimer = false;
    private int score = 0;
    private float playTime = 0f;
    private int playMin = 0;
    private int playSec = 0;

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
    }
    void ShowGameOverPanel() {
        gameOverPanel.SetActive(true);
        ScoreText.SetText(score.ToString());
        playMin = (int)playTime / 60;
        playSec = (int)playTime % 60;
        PlayTimeText.SetText(playMin.ToString()+"M      "+playSec.ToString()+"S");
        setTimer = false;
    }
    public void MenuButtonClick() {
        SceneManager.LoadScene("Mainscene");
    }

    public void RankingButtonClick() {
        
    }

    public void PlayRecordButtonClick() {
        Debug.Log("Play 기록됨");
    }
}
