using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InspectController : MonoBehaviour
{
    [SerializeField] private TMP_Text inspectInfo;

    [SerializeField] private float onScreenTimer;
    [HideInInspector] public bool startTimer;
    private float timer;


    void FixedUpdate()
    {
        if (startTimer)
        {
            timer -= Time.deltaTime;

            if (timer <= 0)
            {
                timer = 0;
                ClearInfo();
                startTimer = false;
            }
        }
    }

    public void ShowInfo(string newInfo)
    {
        inspectInfo.text = newInfo;
        timer = onScreenTimer;
        startTimer = true;
    }

    void ClearInfo()
    {
        inspectInfo.text = "";
    }
}
