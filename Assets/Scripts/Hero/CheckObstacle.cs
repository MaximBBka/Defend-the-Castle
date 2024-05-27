using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class CheckObstacle 
{
    [field: SerializeField] public Color color { private set; get; }
    [field: SerializeField] public float radius { private set; get; }
    [SerializeField] private LayerMask findLayer;

    public Collider[] Check(Transform transform)
    {
        return Physics.OverlapSphere(transform.position, radius, findLayer);
    }
}
