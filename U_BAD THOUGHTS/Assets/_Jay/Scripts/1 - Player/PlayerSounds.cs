using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSounds : MonoBehaviour
{
    [SerializeField] private AudioSource aSource;

    [SerializeField] private AudioClip[] footsteps;
    [SerializeField] private AudioClip pickupSound;
    

    // Start is called before the first frame update
    void Start()
    {
        aSource = GetComponent<AudioSource>();
    }

    //Footstep Sound
    public void PlayFootstepSound(){
        var soundID = Random.Range(0, footsteps.Length);
        aSource.PlayOneShot(footsteps[soundID], 0.3f);
    }

    //Pickup Sound
    public void PlayPickupSound(){
        aSource.PlayOneShot(pickupSound);
    }

    //Hurt Sound
    public void PlaySound(AudioClip sound){
        aSource.PlayOneShot(sound);
    }
}
