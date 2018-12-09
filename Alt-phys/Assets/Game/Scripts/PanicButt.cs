using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//Special Thanks to alucardj on the Unity Forum, which this code is inspired by.

public class PanicButt : MonoBehaviour {

    private float timer = 0;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
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
