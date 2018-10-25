using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Earth : MonoBehaviour {

    private Rigidbody rb;

    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update () {
		
	}

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("EarthPlane"))
        {
            rb.Sleep();
        }
    }
}
