using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShadowManStatus : EnemyStatus
{
    [SerializeField] private ParticleSystem deathParticles;

    // Update is called once per frame
    public override void Die()
    {
        GetComponent<ZombieLocomotion>().enabled = false;
        StartCoroutine(Shrink());
    }

    private IEnumerator Shrink(){
        //Shrink//
        float elapsedTime = 0f;
        while (elapsedTime < 5f){
            elapsedTime += Time.deltaTime;
            Vector3 fade = new Vector3();
            fade = Vector3.Lerp(this.transform.localScale, new Vector3(0, 0, 0), 2.5f * Time.deltaTime * 0.25f);

            this.transform.localScale = fade;
            aSource.pitch = fade.x;
            yield return null;
        }
        Instantiate(deathParticles, this.transform.position, Quaternion.identity);
        Destroy(this.gameObject);
    }
}
