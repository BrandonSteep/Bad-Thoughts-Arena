using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShadowManBehaviour : MonoBehaviour
{
    private EnemyStatus status;
    [SerializeField] private ParticleSystem smokeParticles;

    void Start(){
        status = GetComponent<EnemyStatus>();
        StartCoroutine(DeathTimer());
    }

    private IEnumerator DeathTimer(){
        yield return new WaitForSeconds(35f);
        smokeParticles.Stop();
        status.Die();
    }
}
