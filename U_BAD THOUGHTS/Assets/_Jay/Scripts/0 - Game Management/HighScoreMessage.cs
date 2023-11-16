using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HighScoreMessage : MonoBehaviour
{
    [SerializeField] private TMP_Text text;

    void Awake(){
        text = GetComponent<TMP_Text>();
    }

    private void ShowMessage(){
        text.enabled = true;
    }

    void OnEnable(){
        ScoreCount.NewHighScore += ShowMessage;
    }

    void OnDisable(){
        ScoreCount.NewHighScore -= ShowMessage;
    }
}
