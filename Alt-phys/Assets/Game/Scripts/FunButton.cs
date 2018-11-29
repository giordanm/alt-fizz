using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

//Code by William Rindone
//A script for a button (attach to a plane)
//For material list:
//Size = 5
//Same order of element materials
//typeOfButton[4] = activatedSwitch material

public class FunButton : MonoBehaviour {
    
    //Materials for the button
    public Material[] typeOfButton;
    //Renderer (will actually change the way the button looks)
    Renderer rend;
    //Holds what type of element needs to interact with it
    public int element;
    //Used to send an event for the State machine
    PlayMakerFSM playMakerFsm;

    // Initializes all componenets not managed by the user
    void Start () {
        rend = GetComponent<Renderer>();
        rend.enabled = true;
        rend.sharedMaterial = typeOfButton[element];
        playMakerFsm = GetComponent<PlayMakerFSM>();
    }

    // If an object isn't an arrow, activates the button and sends out a signal to send
    // a playmaker event (and sets the button to its activated color
    private void OnTriggerEnter(Collider other)
    {
        Element typio = other.GetComponent<Element>();
        if(typio != null &&
            !other.gameObject.CompareTag("EarthArrow") &&
            !other.gameObject.CompareTag("WaterArrow") &&
            !other.gameObject.CompareTag("FireArrow") &&
            !other.gameObject.CompareTag("AirArrow"))
        {
            if(element == typio.element)
            {
                rend.sharedMaterial = typeOfButton[4];
                playMakerFsm.SendEvent("Dingus");
            }
        }
    }
    
}
