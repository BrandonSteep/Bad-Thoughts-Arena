using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HighScoreCount : MonoBehaviour
{
    [SerializeField] private TMP_Text text;
    [SerializeField] private int highScore;

    void Awake(){
        PlayerData myData = SaveSystem.LoadData();
        highScore = (int) myData.highScore;
        
        text = GetComponent<TMP_Text>();
        text.text = ("HIGH SCORE: " + highScore.ToString());
    }
}
