using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatus : Status
{
    public ScriptableVariable currentHp;
    [SerializeField] private ParticleSystem particles;

    //Audio
    [SerializeField] private PlayerSounds soundManager;
    [SerializeField] private AudioClip hurtSound;
    [SerializeField] private AudioClip deathSound;
    [SerializeField] private AudioClip healSound;    

    void Awake()
    {
        currentHp.value = maxHp.value;
        soundManager = GetComponent<PlayerSounds>();
    }

    public override int TakeDamage(int damage, Transform other, float falterDamage)
    {
        if (canTakeDamage)
        {
            canTakeDamage = false;
            currentHp.value -= damage;

            References.playerAnim.SetTrigger("TakeDamage");
            References.playerKnockback.AddImpact((this.transform.position - other.position), 75f);
            if(currentHp.value <= 0){
                OnDeath();
                soundManager.PlaySound(deathSound);
            }
            else{
                soundManager.PlaySound(hurtSound);
            }
            return base.TakeDamage(damage, other, falterDamage);
        }
        else
        {
            return 0;
        }
    }    

    public void Heal(int healAmount){
        currentHp.value += healAmount;
        if(currentHp.value > maxHp.value){
            currentHp.value = maxHp.value;
        }
        soundManager.PlaySound(healSound);
        particles.Play();
    }

    public void ResetDamage()
    {
        canTakeDamage = true;
    }
    
    
    public delegate void Die();

    public static event Die OnDeath;
}
