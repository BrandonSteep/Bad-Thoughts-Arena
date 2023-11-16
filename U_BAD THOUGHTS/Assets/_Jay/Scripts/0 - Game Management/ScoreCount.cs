using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreCount : MonoBehaviour
{
    [SerializeField] private int additionalScore;
    [SerializeField] private ScriptableVariable timeVar;
    [SerializeField] private ScriptableVariable highScore;

    [SerializeField] private int finalScore;
    
    public void CountFinalScore(){
        PlayerData myData = SaveSystem.LoadData();
        finalScore = (int) timeVar.value + additionalScore;

        if(finalScore > myData.highScore){
            Debug.Log("HIGH SCORE");
            NewHighScore();

            Data data = References.player.GetComponent<Data>();
            data.SaveScore(finalScore);
        }
    }

    public delegate void HighScore();
    public static event HighScore NewHighScore;

    void OnEnable(){
        PlayerStatus.OnDeath += CountFinalScore;
    }

    void OnDisable(){
        PlayerStatus.OnDeath -= CountFinalScore;
    }
}
