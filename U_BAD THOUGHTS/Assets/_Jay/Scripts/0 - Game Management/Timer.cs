using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    [SerializeField] private ScriptableVariable timeVar;
    private bool timerEnabled;

    void Start(){
        timeVar.value = 0f;
        timerEnabled = true;

        StartCoroutine(CallEvent());
    }

    void Update(){
        if(timerEnabled){
        CountUp();
        }
    }

    void CountUp(){
        timeVar.value += Time.deltaTime;
    }

#region TenSecondEvent
    public delegate void TenSecondEvent();

    public static event TenSecondEvent TimedEvent;

    private IEnumerator CallEvent(){
        yield return new WaitForSeconds(10f);
        TimedEvent();
        StartCoroutine(CallEvent());
    }
    #endregion

#region OnDeath
    private void DisableTimer(){
        timerEnabled = false;
    }

    void OnEnable(){
        PlayerStatus.OnDeath += DisableTimer;
    }
    void OnDisable(){
        PlayerStatus.OnDeath -= DisableTimer;
    }
    #endregion
}
