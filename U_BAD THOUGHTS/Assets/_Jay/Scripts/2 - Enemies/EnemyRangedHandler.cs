using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRangedHandler : MonoBehaviour
{
    [SerializeField] private GameObject lightProjectile;
    [SerializeField] private AudioClip lightSound;

    [SerializeField] private GameObject heavyProjectile;
    [SerializeField] private AudioClip heavySound;

    [SerializeField] private Transform muzzle;
    [SerializeField] private AudioSource audioSource;

    public void FireLightProjectile()
    {
        Instantiate(lightProjectile, muzzle.position, muzzle.rotation);
        audioSource.PlayOneShot(lightSound);
    }

    public void FireHeavyProjectile()
    {
        Instantiate(heavyProjectile, muzzle.position, muzzle.rotation);
        if(heavySound != null){
           audioSource.PlayOneShot(heavySound);
        }
        else{
            audioSource.PlayOneShot(lightSound);
        }
    }
}
