using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileFunction : MonoBehaviour {

    private Rigidbody rb;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        Vector3 x = Vector3.Project(rb.velocity, new Vector3(1f, 0f, 0f));
        Vector3 z = Vector3.Project(rb.velocity, new Vector3(0f, 0f, 1f));
        if (x != Vector3.zero){
            rb.AddForce(-x);
        }
        if (z != Vector3.zero)
        {
            rb.AddForce(-z);
        }
    }
}


