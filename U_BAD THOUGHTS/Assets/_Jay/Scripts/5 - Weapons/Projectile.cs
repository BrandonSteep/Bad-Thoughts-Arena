using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private Rigidbody rb;
    [SerializeField] private float speed;
    [SerializeField] private LayerMask shootableLayers;
    
    [SerializeField] private AudioClip hitSound;
    [SerializeField] private GameObject splashParticle;

    [SerializeField] private bool AOE = false;
    [SerializeField] private GameObject AOEHit;

    void OnEnable()
    {
        rb = GetComponent<Rigidbody>();
        Vector3 forward = this.transform.forward;
        rb.AddForce(-forward * speed, ForceMode.Impulse);

        StartCoroutine("Timer");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Shootable") || other.gameObject.layer == LayerMask.NameToLayer("Environment"))
        {
            Instantiate(splashParticle, this.transform.position, Quaternion.identity);
            if (other.tag == "PhysicsObject")
            {
                Vector3 dir = References.player.transform.localPosition - other.transform.position;
                other.GetComponent<Rigidbody>().AddForce((-dir.normalized * 5f), ForceMode.Impulse);
            }
            // else if (other.tag == "Ground")
            // {
            //     if (AOE)
            //     {
            //         Debug.Log("Lava");
            //         Instantiate(AOEHit, this.transform.position, Quaternion.identity);
            //     }
            //     Destroy(this.gameObject);
            // }
            Destroy(this.gameObject);
        }
    }

    private IEnumerator Timer()
    {
        yield return new WaitForSeconds(4f);
        Destroy(this.gameObject);
        yield return null;
    }
}
