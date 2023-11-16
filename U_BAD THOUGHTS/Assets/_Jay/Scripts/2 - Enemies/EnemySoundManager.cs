using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySoundManager : MonoBehaviour
{
    [SerializeField] private AudioSource aSource;
    [SerializeField] private AudioClip[] miscClips;
    [SerializeField] private AudioClip[] attackClips;

    [SerializeField] private float minWaitTime = 5f;
    [SerializeField] private float maxWaitTime = 15f;
    [SerializeField] private float currentWaitTime;

    [SerializeField] private EnemyStatus status;
    
    // Start is called before the first frame update
    void Awake()
    {
        aSource = GetComponent<AudioSource>();
        if(!status){
            status = GetComponent<EnemyStatus>();
        }

        currentWaitTime = Random.Range(minWaitTime, maxWaitTime);
        StartCoroutine(Countdown(currentWaitTime));
    }

    public void PlayRandomSound(){
        //Choose Random Sound//
        var soundID = Random.Range(0, miscClips.Length);
        aSource.PlayOneShot(miscClips[soundID]);
    }

    public void PlayAttackSound(int soundID){
        aSource.PlayOneShot(attackClips[soundID]);
    }

    private IEnumerator Countdown(float waitTime){
        //Wait//
        yield return new WaitForSeconds(waitTime);

        if(status.currentHp > 0f){
          //Play Sound//
           PlayRandomSound();
        }

        //Restart Coroutine//
        var newWaitTime = Random.Range(minWaitTime, maxWaitTime);
        StartCoroutine(Countdown(newWaitTime));
        yield return null;
    }
}
