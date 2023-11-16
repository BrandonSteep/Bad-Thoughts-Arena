using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MoveState : State
{
    [SerializeField] private State attackState;
    
    [SerializeField] float maxWaitTime = 5f;
    [SerializeField] float currentWaitTime = 5f;
    
    [SerializeField] float minDistance = 7.5f;
    [SerializeField] float maxDistance = 12.5f;
    public float idealDistance;

    [SerializeField] float minSpeed = 1.5f;
    [SerializeField] float maxSpeed = 3f;
    private float speed;

    [SerializeField] private LayerMask sightCheckIgnore;

    void Awake()
    {
        nav = enemy.GetComponentInParent<NavMeshAgent>();

        currentWaitTime = maxWaitTime;
        InvokeRepeating("CheckLineOfSight", 0f, 0.25f);

        idealDistance = Random.Range(minDistance, maxDistance);
        speed = Random.Range(minSpeed, maxSpeed);
        nav.speed = speed;
    }

    public override State RunCurrentState()
    {
        var distance = CheckDistance();

        if (distance > idealDistance || !canSeePlayer)
        {
            nav.SetDestination(References.player.transform.position);
        }
        else
        {
            nav.SetDestination(enemy.transform.position);
        }

        //enemy.transform.LookAt(References.player.transform.position);
        return CountDownToAttack();
    }

    private void LookHandler()
    {
        Debug.Log("Look At Player");
        // var lookPos = References.player.transform.position - transform.position;
        // lookPos.y = 0;
        // var rotation = Quaternion.LookRotation(-lookPos);
        // transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * 1.5f);
        
        transform.LookAt(References.player.transform.position);

        transform.eulerAngles = new Vector3(Mathf.Clamp(transform.eulerAngles.y, 0, 0), transform.eulerAngles.y, Mathf.Clamp(transform.eulerAngles.y, 0, 0));
        
    }

    public float CheckDistance()
    {
        return Vector3.Distance(this.transform.position, References.player.transform.position);
    }

    private State CountDownToAttack()
    {
        currentWaitTime -= Time.deltaTime;
        if (currentWaitTime < 0f && canSeePlayer)
        {
            currentWaitTime = maxWaitTime;
            return attackState;
        }
        else
        {
            return this;
        }
    }


    public bool canSeePlayer;

    public bool CheckLineOfSight()
    {

        RaycastHit hit;
        Vector3 rayDirection = References.player.transform.position - enemy.transform.position;
        if (Physics.Raycast(transform.position, rayDirection, out hit, sightCheckIgnore))
        {
            if (hit.transform == References.player.transform)
            {
                // enemy can see the player!
                //Debug.Log("Can See Player");
                canSeePlayer = true;
                return true;
            }
            else
            {
                // there is something obstructing the view
                canSeePlayer = false;
                return false;
            }
        }
        canSeePlayer = false;
        return false;
    }
}

