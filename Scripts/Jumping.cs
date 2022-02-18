using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class Jumping : MonoBehaviour
{
    public float timeScale = 1.0f;
    public float launch = 10f;
    public GameObject target;
    Rigidbody rb;
    Vector3 startPosition;

    private float myTimeScale = 1f;

    void Start()
    {
        startPosition = transform.position;
        Time.timeScale = myTimeScale;
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            FiringSolution fs = new FiringSolution();
            Nullable<Vector3> aimVector = fs.Calculate(transform.position, target.transform.position, launch, Physics.gravity);
            if (aimVector.HasValue)
            {
                Debug.Log(aimVector);
                rb.AddForce(aimVector.Value.normalized * launch, ForceMode.VelocityChange);
            }
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            rb.isKinematic = true;
            transform.position = startPosition;
            rb.isKinematic = false;
        }
    }
}
