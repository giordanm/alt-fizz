using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Water : MonoBehaviour {

    private Rigidbody rb;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody>();
	}

    private void FixedUpdate()
    {

    }

    private void OnTriggerStay(Collider other)
    {
        if(other.gameObject.CompareTag("WaterPlane")){
            rb.Sleep();
        }
    }
}
