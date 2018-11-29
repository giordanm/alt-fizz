using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class FunButton : MonoBehaviour {
    
    public Material[] typeOfButton;
    Renderer rend;
    public int element;

    [HideInInspector] public UnityEvent ButtonActivated;

    // Use this for initialization
    void Start () {
        rend = GetComponent<Renderer>();
        rend.enabled = true;
        rend.sharedMaterial = typeOfButton[element];
    }

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
                ButtonActivated.Invoke();
                rend.sharedMaterial = typeOfButton[4];
            }
        }
    }
    
}
