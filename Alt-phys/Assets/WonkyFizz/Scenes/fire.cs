using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fire : MonoBehaviour {

    private Rigidbody rb;

    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

	
	// Update is called once per frame
    private void FixedUpdate() {
        rb.AddForce(0, 9.8f, 0);
	}
}
