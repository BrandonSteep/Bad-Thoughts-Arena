using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimAtPlayer : MonoBehaviour
{
    public Transform target;
    [SerializeField] private bool inverted;
    [SerializeField] private float minXClamp = 0f;
    [SerializeField] private float maxXClamp = 0f;

    void Start()
    {
        target = References.cam.transform;
    }

    void Update()
    {
        Look();
    }    

    private void Look()
    {
        if(target != null){
            transform.LookAt(2 * transform.position - target.position);
        }
    }
}
