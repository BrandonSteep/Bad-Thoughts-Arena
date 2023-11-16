using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Status : MonoBehaviour
{
    public ScriptableVariable maxHp;
    public bool isAlive = true;

    public bool canTakeDamage = true;


    public virtual int TakeDamage(int damage, Transform other, float falterDamage)
    {
        return 0;
    }

    public void ResetDamage()
    {
        canTakeDamage = true;
    }
}
