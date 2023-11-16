using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealingItem : Interactable
{
    [SerializeField] private int healAmount;

    void Start(){
        StartCoroutine(Countdown());
    }

    public override void Interact(){
        if(References.playerStatus.currentHp.value < References.playerStatus.maxHp.value){
            References.playerStatus.Heal(healAmount);
            Destroy(this.gameObject);
        }
    }

    private IEnumerator Countdown(){
        yield return new WaitForSeconds(25f);
        
        float elapsedTime = 0f;
        
        while (elapsedTime < 5f){
            elapsedTime += Time.deltaTime;
            this.transform.localScale = Vector3.Lerp(this.transform.localScale, new Vector3(0, 0, 0), 2.5f * Time.deltaTime * 0.25f);
            yield return null;
        }Despawn();
    }

    private void Despawn(){
        References.objectPool.SpawnFromPool("HitParticle", this.transform.position, Quaternion.identity);
        Destroy(this.gameObject);
    }
}
