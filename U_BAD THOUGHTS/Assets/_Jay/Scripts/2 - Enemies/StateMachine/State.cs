using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class State : MonoBehaviour
{
    public GameObject enemy;

    public NavMeshAgent nav;
    //public GameObject player;
    public Animator anim;

    void Awake()
    {
        nav = enemy.GetComponentInParent<NavMeshAgent>();
    }

    public virtual State RunCurrentState(){
        return this;
    }
}
