using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CenterOfMass : MonoBehaviour
{
    [SerializeField] Transform com;

    void OnEnable()
    {
        Rigidbody rb = GetComponent<Rigidbody>();
        rb.centerOfMass = com.localPosition;
    }
}