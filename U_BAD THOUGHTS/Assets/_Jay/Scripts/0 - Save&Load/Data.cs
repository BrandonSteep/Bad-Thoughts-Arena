using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Data : MonoBehaviour
{
    public ScriptableVariable sensitivity;
    public ScriptableVariable highScore;

    [SerializeField] private Slider sensitivitySlider;

    void Start(){
        // LoadData();
    }

    public void UpdateValue(){
        sensitivity.value = sensitivitySlider.value;
    }

    public void SaveScore(float newScore){
        highScore.value = newScore;
        SaveData();
    }

    public void SaveData(){
        SaveSystem.SaveData(this);
        Debug.Log("Saved");
    }

    private void LoadData(){
        PlayerData myData = SaveSystem.LoadData();
        sensitivity.value = myData.sensitivity;
        Debug.Log("Loaded");
    }
}
