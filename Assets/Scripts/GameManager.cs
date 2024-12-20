using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
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
            Debug.Log(score);
        }
    }
    public void SetTimer() {
        // 타이머 시작
        setTimer = true;
    }
    public void SetGameOver() {
        isGameOver = true;
        Invoke("ShowGameOverPanel", 1f);
        
    }
    void ShowGameOverPanel() {
        gameOverPanel.SetActive(true);
        ScoreText.SetText(score.ToString());
        PlayTimeText.SetText(playTime.ToString());
        Debug.Log(playTime);
        setTimer = false;
    }
    public void PlayAgain() {
        SceneManager.LoadScene("SampleScene");
    }
}
