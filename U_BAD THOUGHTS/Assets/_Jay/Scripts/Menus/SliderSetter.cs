using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderSetter : MonoBehaviour
{
    // [SerializeField] private ScriptableVariable value;
    [SerializeField] private Slider thisSlider;

    void Awake(){
        PlayerData myData = SaveSystem.LoadData();

        GetComponent<Slider>().value = myData.sensitivity;
    }
}
