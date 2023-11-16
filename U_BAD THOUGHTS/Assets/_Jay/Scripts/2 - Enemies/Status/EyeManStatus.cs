using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EyeManStatus : EnemyStatus
{
    [SerializeField] private GameObject AOE;
    
    public override void Die(){
        Instantiate(AOE, this.transform.position, Quaternion.identity);
        Destroy(this.gameObject);
    }
}
