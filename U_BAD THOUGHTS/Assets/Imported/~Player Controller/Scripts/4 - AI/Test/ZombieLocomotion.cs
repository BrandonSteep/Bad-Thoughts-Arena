using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ZombieLocomotion : MonoBehaviour
{
    [SerializeField] private NavMeshAgent agent;
    public Transform target;

    [SerializeField] private ScriptableVariable averageMoveSpeed;
    [SerializeField] private float moveSpeed;
    [SerializeField] private float moveSpeedVariance;
    
    //[SerializeField] private Animator anim;

    private void Start()
    {
        target = GameObject.FindWithTag("Player").transform;
        agent = GetComponent<NavMeshAgent>();
        //anim = GetComponent<Animator>();

        moveSpeed = Random.Range(averageMoveSpeed.value-moveSpeedVariance, averageMoveSpeed.value + moveSpeedVariance);

        //anim.SetFloat("Speed", moveSpeed);
    }

    void Update()
    {
        MoveToTarget();
    }

    void MoveToTarget()
    {
        agent.SetDestination(target.position);
    }

    void DisableNav(){
        target = this.transform;
    }

    void OnEnable(){
        PlayerStatus.OnDeath += DisableNav;
    }

    void OnDisable(){
        PlayerStatus.OnDeath -= DisableNav;
    }
}
