using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Firearm : ItemAnimationManager
{

    [SerializeField] private Animator anim;
    public bool isAiming;

    // F I R E A R M   V A R I A B L E S //
    [SerializeField] private int currentAmmo;
    
    [SerializeField] private bool isHitscan = true;
    [SerializeField] private int damage = 1;
    [SerializeField] private int shotCount = 1;
    [SerializeField, Tooltip("0 = Perfect Accuracy")] private float accuracy = 0f;
    [SerializeField] private float range = 100f;
    [SerializeField] private LayerMask shootable;
    [SerializeField] private float falterDamage;

    // E F F E C T S   &   P A R T I C L E S //
    [SerializeField] Transform muzzle;
    [SerializeField] private ParticleSystem muzzleSmoke;
    [SerializeField] private ParticleSystem hitParticle;
    [SerializeField] private LineRenderer bulletTrail;

    // A U D I O //
    [SerializeField] private AudioSource aSource;
    [SerializeField] private AudioClip shotSound;
    [SerializeField] private AudioClip hitSound;

    // P R O J E C T I L E //
    [SerializeField] private GameObject projectilePrefab;



    void Start()
    {
        anim = GetComponent<Animator>();
        aSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        UpdateAiming();
    }


    #region Aiming
    void UpdateAiming()
    {
        if (References.playerController.aiming == 1)
        {
            anim.SetBool("Aiming", true);
        }
        else if (References.playerController.aiming != 1)
        {
            anim.SetBool("Aiming", false);
        }
    }


    public void SetAimingTrue()
    {
        isAiming = true;
    }
    public void SetAimingFalse()
    {
        isAiming = false;
    }
    #endregion


    public override void Action()
    {
        // Debug.Log("ACTION");
        if (isAiming)
        {
            SetAimingFalse();
            anim.SetTrigger("Shoot");
        }
    }


    void FireRound()
    {
        muzzleSmoke.Play();
        aSource.PlayOneShot(shotSound);
        if (isHitscan)
        {
            Hitscan();
        }
        else
        {
            Projectile();
        }
    }

    void Hitscan()
    {
        for (var i = 0; i < shotCount; i++)
        {
            //Debug.Log("Hitscan Shot");
            var randomDirection = new Vector3(Random.Range(-accuracy, accuracy), Random.Range(-accuracy, accuracy), 0f);

            RaycastHit hit;
            if (Physics.Raycast(References.cam.transform.position, randomDirection + References.cam.transform.forward, out hit, range, shootable))
            {
                // Debug.Log(hit.collider.name);
                // Trail(hit);
                if(hit.collider != null)
                {
                    var particleRotation = Quaternion.LookRotation(hit.normal);
                    
                    if(hit.collider.tag == "Enemy")
                    {
                        hit.collider.GetComponentInParent<Status>().TakeDamage(damage * 2, References.player.transform, falterDamage / 2);
                        GameObject bloodParticle = References.objectPool.SpawnFromPool("BloodParticle", hit.point, particleRotation);
                        bloodParticle.GetComponent<ParticleSystem>().Play();
                    }
                    else{
                    GameObject hitParticle = References.objectPool.SpawnFromPool("HitParticle", hit.point, particleRotation);
                    hitParticle.GetComponent<ParticleSystem>().Play();
                    }
                    
                    var rb = hit.collider.GetComponent<ObjectPhysicsHandler>();
                    if(rb != null)
                    {
                        rb.AddForce(References.cam.transform.forward * 5f, ForceMode.Impulse);
                    }
                }
            }
            else
            {
                // Trail(hit);
            }
        }
    }

    void Projectile()
    {
        Debug.Log("Projectile Shot");
        Instantiate(projectilePrefab, muzzle.position, muzzle.rotation);
    }

    void Trail(RaycastHit hit)
    {
        GameObject bulletTrailEffect = References.objectPool.SpawnFromPool("BulletTrail", muzzle.position, Quaternion.identity);

        LineRenderer line = bulletTrailEffect.GetComponent<LineRenderer>();

        line.SetPosition(0, muzzle.position);
        if (hit.collider != null)
        {
            line.SetPosition(1, hit.point);
        }
        else
        {
            var point = References.cam.ViewportToWorldPoint(new Vector3((0.5f + Random.Range(-accuracy / 2, accuracy / 2)), (0.5f + Random.Range(-accuracy / 3, accuracy / 3)), range));
            Debug.Log(point);
            line.SetPosition(1, point);
        }

        StartCoroutine(DestroyTrail(bulletTrailEffect));
    }

    private IEnumerator DestroyTrail(GameObject trail)
    {
        yield return new WaitForSeconds(1f);
        trail.SetActive(false);
    }
}
