using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//Code by William Rindone
//The Code for the buttons used in the main menu

//Tags associated:  TeleportBox -> Takes you to a level
//                  QuitBox -> Exits the Application
//                  StateBox -> Changes the state of the menu

//for states (What we used)
//size = 2
//states[0] = Graphic ("Quit" "Credits" "LvlSelect" Etc.)

public class MenuButton : MonoBehaviour
{
    public int sceneToLoad;
    public Material[] states;
    Renderer rend;

    //Sets up the renderer to render the buttons
    void Start()
    {
        rend = gameObject.GetComponent<Renderer>();
        rend.enabled = true;
        rend.sharedMaterial = states[0];
    }

    //Necesary, because the way the menu works is by diabling all pages of the menu
    //Except the one the user wants
    private void OnEnable()
    {
        rend = gameObject.GetComponent<Renderer>();
        rend.enabled = true;
        rend.sharedMaterial = states[0];
    }

    //When the pointer the character uses enters the menu option, changes the state so that the user know they have it
    //selected, then, depending on what type of box it is, performs it's associated action
    private void OnTriggerEnter(Collider other)
    {
        rend.sharedMaterial = states[1];
        if (gameObject.CompareTag("QuitBox") && OVRInput.Get(OVRInput.Button.One, OVRInput.Controller.RTouch))
        {
            Application.Quit();
        }
        if (gameObject.CompareTag("TeleportBox") && OVRInput.Get(OVRInput.Button.One, OVRInput.Controller.RTouch))
        {
            SceneManager.LoadScene(sceneToLoad);
        }
        if (gameObject.CompareTag("StateBox") && OVRInput.Get(OVRInput.Button.One, OVRInput.Controller.RTouch))
        {
            gameObject.GetComponent<PlayMakerFSM>().SendEvent("Button Pressed");
        }
    }

    //Repeat of OnTriggerEnter, so that the options still exist after the trigger stays in the object
    private void OnTriggerStay(Collider other)
    {
        rend.sharedMaterial = states[1];
        if (gameObject.CompareTag("QuitBox") && OVRInput.Get(OVRInput.Button.One, OVRInput.Controller.RTouch))
        {
            Application.Quit();
        }
        if (gameObject.CompareTag("TeleportBox") && OVRInput.Get(OVRInput.Button.One, OVRInput.Controller.RTouch))
        {
            SceneManager.LoadScene(sceneToLoad);
        }
        if (gameObject.CompareTag("StateBox") && OVRInput.Get(OVRInput.Button.One, OVRInput.Controller.RTouch))
        {
            gameObject.GetComponent<PlayMakerFSM>().SendEvent("Button Pressed");
        }
    }

    //Returns the menu to it's unactive state
    private void OnTriggerExit()
    {
        rend.sharedMaterial = states[0];
    }

}