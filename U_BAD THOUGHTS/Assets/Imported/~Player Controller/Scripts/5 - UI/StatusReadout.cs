using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class StatusReadout : MonoBehaviour
{
    [SerializeField] private ScriptableVariable max;
    [SerializeField] private ScriptableVariable current;
    [SerializeField] private float percentage;

    [SerializeField] private int Caution = 60;
    [SerializeField] private int Danger = 20;

    [SerializeField] private TMP_Text statusText;


    void Start()
    {
        statusText = GetComponent<TMP_Text>();
    }

    void Update()
    {
        percentage = (current.value / max.value) * 100f;
        if (percentage < Caution)
        {
            if(percentage < Danger)
            {
                statusText.text = "Danger";
            }
            else
            {
                statusText.text = "Caution";
            }
        }
        else
        {
            statusText.text = "Fine";
        }
    }
}
