using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Torch : ItemAnimationManager
{
    [SerializeField] private Animator anim;

    [SerializeField] private Light lightSource;
    [SerializeField] private float normalRange;
    [SerializeField] private float aimingRange;
    [SerializeField] private float currentRange;
    public bool isAiming;

    private float t = 0f;
    private float x = 0f;

    [SerializeField] private ParticleSystem particles;

    void Start()
    {
        anim = GetComponentInChildren<Animator>();
        lightSource = GetComponentInChildren<Light>();

        particles = GetComponentInChildren<ParticleSystem>();
        particles.gameObject.layer = 0;
    }
    
    // Update is called once per frame
    void Update()
    {
        UpdateAiming();
    }

    void UpdateAiming()
    {
        if (References.playerController.aiming != 1)
        {
            anim.SetBool("Aiming", false);
            currentRange = Mathf.Lerp(aimingRange, normalRange, x);
            if (x <= 1) x += Time.deltaTime / 0.5f;

            t = 0f;
        }
        else if (References.playerController.aiming == 1)
        {
            anim.SetBool("Aiming", true);
            currentRange = Mathf.Lerp(normalRange, aimingRange, t);
            if (t <= 1) t += Time.deltaTime / 0.5f;

            x = 0f;
        }

        lightSource.range = currentRange;
    }
}
