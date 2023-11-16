using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastManager : MonoBehaviour
{
    public static RaycastManager instance;

    [SerializeField]
    private LayerMask ignoreLayers;

    void Awake()
    {
        instance = this;
    }

    public Tuple<bool, RaycastHit> CastRay(Vector3 origin, Vector3 direction, float maxDistance)
    {
        RaycastHit hitInfo = new RaycastHit();

        if (Physics.Raycast(origin, direction, out hitInfo, maxDistance, ignoreLayers))
        {
            //Debug.Log("Raycast Successful");
            return Tuple.Create(true, hitInfo);
        }
        else
        {
            //Debug.Log("Raycast Failed");
            return Tuple.Create(false, hitInfo);
        }
    }
}
