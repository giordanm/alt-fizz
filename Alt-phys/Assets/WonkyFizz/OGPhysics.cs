using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OGPhysics : MonoBehaviour {

    private Rigidbody rb;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody>();
        rb.AddForce(400f, 300f, 0);
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
