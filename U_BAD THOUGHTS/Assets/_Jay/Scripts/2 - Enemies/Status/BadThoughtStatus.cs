using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BadThoughtStatus : EnemyStatus
{
    [SerializeField] private Collider damageColl;

    public override void Die(){
        GetComponent<UnityEngine.AI.NavMeshAgent>().enabled = false;
        GetComponent<ZombieLocomotion>().enabled = false;

        this.gameObject.AddComponent<ObjectPhysicsHandler>();

        GetComponentInChildren<Animator>().enabled = false;
        GetComponent<Collider>().isTrigger = false;

        damageColl.enabled = false;

        StartCoroutine(Despawn());
    }

    private IEnumerator Despawn(){
        yield return new WaitForSeconds(5f);
        
        //Shrink//
        float elapsedTime = 0f;
        while (elapsedTime < 5f){
            elapsedTime += Time.deltaTime;
            this.transform.localScale = Vector3.Lerp(this.transform.localScale, new Vector3(0, 0, 0), 2.5f * Time.deltaTime * 0.25f);
            yield return null;
        }
        Destroy(this.gameObject);
    }
}
