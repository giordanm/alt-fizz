using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//Code By William Rindone
//Special Thanks to alucardj on the Unity Forum, for explaning how to use a timer essentially.
//Literally Attach this to anything in the scene (we typically set it up on the Front Wall)

public class PanicButt : MonoBehaviour {

    private float timer = 0;

    // Use this for initialization
    void Start () {
		
	}
	
	// Checks that the upper trigger on both of the controllers are being held.
    // Waits 5 seconds, and then warps the user back to the main menu
	void Update () {
		if(OVRInput.Get(OVRInput.Button.PrimaryIndexTrigger, OVRInput.Controller.RTouch) &&
            OVRInput.Get(OVRInput.Button.PrimaryIndexTrigger, OVRInput.Controller.LTouch))
        {
            timer += Time.deltaTime;
            if(timer > 5)
            {
                SceneManager.LoadScene(0);
            }
        } else
        {
            timer = 0;
        }
	}
}
