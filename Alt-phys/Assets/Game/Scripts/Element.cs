using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Code by William Rindone

//Note: I know that typically, hardcoded values are bad,
//but as there are only 4 types of elements in our simulation
//we're just going to roll with the hardcoded values


//For people:
//0 = Earth
//1 = Water
//2 = Air
//3 = Fire
//Turn off gravity for any object with this script, it simulates its own gravity

public class Element : MonoBehaviour {

    private Rigidbody rb;
    public int element;
    public Material[] material;
    //Reminder: Material list should be as follows:
    //0 = Earth(Material)
    //1 = Water(Material)
    //2 = Air(Material)
    //3 = Fire(Material)

    private bool stopUpdates = false;
    Renderer rend;

	//On initialization: Sets the object to the proper material
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
        if (!stopUpdates)
        {

            //If element is Earth or Water, normal gravity applies
            if (element < 2)
            {
                rb.AddForce(-9.8f * Vector3.up);
            }

            //If it's fire, then reverse gravity (easier for user experience)
            if (element == 3)
            {
                rb.AddForce(9.8f * Vector3.up);
            }
        }

        //Otherwise, no gravity (air is not affected by gravity)
    }

    //Handles triggers with other collider (Need to add more interactions later...)
    private void OnTriggerEnter(Collider other)
    {
        //Moves the element up a level when interacting with an object tagged "Magic"
        if (other.gameObject.CompareTag("Magic")) {
            rb.velocity = Vector3.zero;
            if (element < 3) {
                element++;
            } else {
                element = 0;
            }
            rend.sharedMaterial = material[element];
        }

        //Turns the object into an Earth Object (normal Gravity)
        if (other.gameObject.CompareTag("EarthArrow"))
        {
            rb.velocity = Vector3.zero;
            element = 0;
            rend.sharedMaterial = material[element];
        }

        //Turns the object into a Water Object (normal Gravity)
        if (other.gameObject.CompareTag("WaterArrow"))
        {
            rb.velocity = Vector3.zero;
            element = 1;
            rend.sharedMaterial = material[element];
        }

        //Turns the object into an Air Object (Zero Gravity)
        if (other.gameObject.CompareTag("AirArrow"))
        {
            rb.velocity = Vector3.zero;
            element = 2;
            rend.sharedMaterial = material[element];
        }

        //Turns the object into a Fire Object (Negative Gravity)
        if (other.gameObject.CompareTag("FireArrow"))
        {
            rb.velocity = Vector3.zero;
            element = 3;
            rend.sharedMaterial = material[element];
        }

        //If the object is called StickInThe, and this is an arrow, has the arrow stick in the object. (and stops update the object)
        if (other.gameObject.CompareTag("StickInThe") && gameObject.CompareTag("EarthArrow"))
        {
            rb.velocity = Vector3.zero;
            stopUpdates = true;
        }
    }
}
