using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{   
     void OnTriggerStay(Collider other)
    {
        if(other.tag == "Damaging" && References.playerStatus.canTakeDamage)
        {
           References.playerStatus.TakeDamage(20, other.transform, 0);
        }
        else if(other.tag == "Interactable")
        {
            other.GetComponent<Interactable>().Interact();
        }
    }
}
