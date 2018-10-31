using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Element : MonoBehaviour {

    private Rigidbody rb;
    public int element;
    public Material[] material;
    Renderer rend;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody>();
        rend = GetComponent<Renderer>();
        rend.enabled = true;
        if (element >= 0 && element < 4){
            rend.sharedMaterial = material[element];
        } else {
            element = 0;
            rend.sharedMaterial = material[element];
        }
    }
	
	// Update is called once per frame
	private void FixedUpdate() {
        if(element < 2){
            rb.AddForce(-9.8f * Vector3.up);
        }
        if(element == 3){
            rb.AddForce(9.8f * Vector3.up);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(element == 0 && other.gameObject.CompareTag("EarthPlane")){
            rb.velocity = Vector3.zero;
        }
        if(element == 1 && other.gameObject.CompareTag("WaterPlane")){
            rb.velocity = Vector3.zero;
        }
        if(other.gameObject.CompareTag("Magic")){
            rb.velocity = Vector3.zero;
            if(element < 3){
                element++;
            } else {
                element = 0;
            }
            rend.sharedMaterial = material[element];
        }
    }
}
