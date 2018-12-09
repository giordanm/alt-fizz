using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

//Code by William Rindone
//A script for a button 
//For material list:
//Size = 2
//typeOfButton[0] = EarthTarget materail
//typeOfButton[1] = GreenTarget material

public class ArrowButton : MonoBehaviour
{

    //Materials for the button
    public Material[] typeOfButton;
    //Renderer (will actually change the way the button looks)
    Renderer rend;
    //Holds what type of element needs to interact with it
    public int element;
    //Used to send an event for the State machine
    PlayMakerFSM playMakerFsm;

    private bool sentSignal = false;

    // Initializes all componenets not managed by the user
    void Start()
    {
        rend = GetComponent<Renderer>();
        rend.enabled = true;
        rend.sharedMaterial = typeOfButton[element];
        playMakerFsm = GetComponent<PlayMakerFSM>();
    }

    // If an object is an earth arrow, activates the button and sends out a signal to send
    // a playmaker event (and sets the button to its activated color) (Typically GreenTarget)
    private void OnTriggerEnter(Collider other)
    {
        Element typio = other.GetComponent<Element>();
        if (typio != null &&
            !other.gameObject.CompareTag("EarthArrow"))
        {
            if (element == typio.element)
            {
                if (!sentSignal)
                {
                    rend.sharedMaterial = typeOfButton[1];
                    playMakerFsm.SendEvent("Bango");
                    sentSignal = true;
                }
            }
        }
    }

    //Repeat of OnTriggerEnter, for instances where the arrow sticks in it.
    private void OnTriggerStay(Collider other)
    {
        Element typio = other.GetComponent<Element>();
        if (typio != null &&
            other.gameObject.CompareTag("EarthArrow"))
        {
            if (element == typio.element)
            {
                if (!sentSignal)
                {
                    rend.sharedMaterial = typeOfButton[1];
                    playMakerFsm.SendEvent("Bango");
                    sentSignal = true;
                }
            }
        }
    }

}
