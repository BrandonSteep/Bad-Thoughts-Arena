using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStatus : Status
{
    public float currentHp;

    [SerializeField] protected AudioClip hitSound;
    [SerializeField] protected AudioSource aSource;

    void Awake(){
        if(maxHp != null){
            currentHp = maxHp.value;
        }
        if(!aSource){
            aSource = GetComponent<AudioSource>();
        }
    }

    public override int TakeDamage(int damage, Transform other, float falterDamage){
        currentHp -= damage;

        if(!aSource){
            aSource = GetComponent<AudioSource>();
        };
        PlayHitSound();

        if (currentHp <= 0){
            Die();
        }

        return 0;
    }

    private void PlayHitSound(){
        Debug.Log("Play Hit Sound");
        aSource.PlayOneShot(hitSound, 1.25f);
    }

    public virtual void Die(){
    }
}
