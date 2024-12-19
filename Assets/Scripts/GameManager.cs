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
    private GameObject gameOverPanel;

    [HideInInspector]
    public bool isGameOver = false;
    private int score = 0;

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
    public void SetGameOver() {
        isGameOver = true;
        Invoke("ShowGameOverPanel", 1f);
        
    }
    void ShowGameOverPanel() {
        gameOverPanel.SetActive(true);
        ScoreText.SetText(score.ToString());
    }
    public void PlayAgain() {
        SceneManager.LoadScene("SampleScene");
    }
}
