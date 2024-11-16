using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance = null;
    [SerializeField]
    private TextMeshProUGUI text;
    private int score = 0;

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
}
