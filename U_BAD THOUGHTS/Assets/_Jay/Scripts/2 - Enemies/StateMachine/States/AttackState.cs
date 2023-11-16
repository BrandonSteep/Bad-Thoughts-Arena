using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackState : State
{
    [SerializeField] private State moveState;

    private bool hasAttacked = false;
    private bool attackFinished = false;

    [SerializeField] private float AOERange = 6f;

    public override State RunCurrentState()
    {
        Debug.Log("Do Attack");

        if (!hasAttacked)
        {
            hasAttacked = true;
            attackFinished = false;

            if (CheckDistance() > AOERange)
            {
                anim.SetBool("Heavy", false);
                anim.SetTrigger("Attack");
            }
            else
            {
                anim.SetBool("Heavy", true);
                anim.SetTrigger("Attack");
            }

            float repeatChance = Random.Range(0f, 1f);
            if (repeatChance <= 0.75f)
            {
                hasAttacked = false;
            }
            else
            {
                attackFinished = true;
            }
        }
        else if (attackFinished)
        {
            hasAttacked = false;
            return moveState;
        }

        return this;
    }

    public float CheckDistance()
    {
        return Vector3.Distance(this.transform.position, References.player.transform.position);
    }
}
