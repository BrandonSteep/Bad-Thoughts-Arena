using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtPlayer : MonoBehaviour
{
    public Transform target;
    [SerializeField] private bool inverted;
    [SerializeField] private float minXClamp = 0f;
    [SerializeField] private float maxXClamp = 0f;

    void Start()
    {
        target = References.player.transform;
    }

    void Update()
    {
        Look();
    }    

    private void Look()
    {
        if(!inverted && target != null){
            transform.LookAt(target);
            transform.eulerAngles = new Vector3(Mathf.Clamp(transform.eulerAngles.x, minXClamp, maxXClamp), transform.eulerAngles.y, Mathf.Clamp(transform.eulerAngles.y, 0, 0));
        }
        else if(inverted && target != null){
            transform.LookAt(2 * this.transform.position - target.position);
            transform.eulerAngles = new Vector3(Mathf.Clamp(transform.eulerAngles.x, minXClamp, maxXClamp), transform.eulerAngles.y, Mathf.Clamp(transform.eulerAngles.y, 0, 0));
        }
    }

    // private void InvertedLook()
    // {
    //     if (target != null)
    //     {
    //         transform.LookAt(2 * this.transform.position - target.position);

    //         transform.eulerAngles = new Vector3(Mathf.Clamp(transform.eulerAngles.y, 0, 0), transform.eulerAngles.y, Mathf.Clamp(transform.eulerAngles.y, 0, 0));
    //     }
    // }
}
