using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Code by William Rindone

//Based upon our understanding of Aristotilean Physics:
//Horizontal motion requires an active outside force to exist,
//thus an object with no outside force applied will have a negative
//force applied to it such that its net horizontal velocity is zero

public class ProjectileFunction : MonoBehaviour {

    private Rigidbody rb;

	void Start () {
        rb = GetComponent<Rigidbody>();
    }

    //Applies a negative force upon the XZ plane, resulting in a loss of horizontal
    //motion. 
    //We could easily lessen the force if desired, resulting in taking longer to achieve
    //zero horizontal motion.
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


