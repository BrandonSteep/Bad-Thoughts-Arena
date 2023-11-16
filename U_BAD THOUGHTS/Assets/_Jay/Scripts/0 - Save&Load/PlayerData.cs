using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerData 
{
    public float sensitivity;

    public float highScore;

    public PlayerData(Data data){
        sensitivity = data.sensitivity.value;
        highScore = data.highScore.value;
    }
}
