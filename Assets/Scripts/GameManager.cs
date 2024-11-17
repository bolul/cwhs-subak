using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance = null;
    [SerializeField]
    private TextMeshProUGUI text;

    [SerializeField]
    private GameObject gameOverPanel;
    private int score = 0;

    [HideInInspector]
    public bool isGameOver = false;

    void Awake() {
        if (instance == null)
        {
            instance = this;
        }
    }
    public void IncreaseScore() {
        score += 1;
        text.SetText(score.ToString());
        Debug.Log(score);
    }
    public void SetGameOver() {
        isGameOver = true;
        Invoke("ShowGameOverPanel", 1f);
        
    }
    void ShowGameOverPanel() {
        gameOverPanel.SetActive(true);
    }
    public void PlayAgain() {
        SceneManager.LoadScene("SampleScene");
    }
}
