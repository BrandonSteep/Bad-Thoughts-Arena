using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TimerUI : MonoBehaviour
{
    [SerializeField] private TMP_Text text;
    [SerializeField] private ScriptableVariable timerVar;
    
    void Start(){
        text = GetComponent<TMP_Text>();
    }

    // Update is called once per frame
    void Update()
    {
        text.text = timerVar.value.ToString("00.00");
    }
}
