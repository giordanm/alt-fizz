using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This code is more or less completely made by owner of FusedVR youtube channel
//Updated by William Rindone to work with the Oculus SDK

public class Arrow : MonoBehaviour {

    private bool isAttached = false;

    private bool isFired = false;

    void OnTriggerStay()
    {
            AttachArrow();
    }

    void OnTriggerEnter()
    {
            AttachArrow();
    }

    private void Update()
    {
        if(isFired){
            transform.LookAt(transform.position + transform.GetComponent<Rigidbody>().velocity);
        }
    }

    public void Fired(){
        isFired = true;
    }

    private void AttachArrow(){
        //Hey, Future me, this line is probably going to be the one
        //That is horribly broken.
        //I'm not exactly sure what the vareity of buttons for OVR are
        //So, I'm going to copy pase someone's answer here until you solve it.
        /*
         * Returns true if the primary button (usually A) is pressed)
         * OVRInput.Get(OVRInput.Button.One);
         * 
         * Returns true if the A button is pressesd on the Right controller
         * OVRInput.Get(OVRInput.Button.One, OVRInput.Controller.RTouch);
         * 
         * To detect trigger presses
         * (Returns float)
         * OVRInput.Get(OVRInput.Axis1D.PrimaryHandTrigger,OVRInput.Controller.LTouch);
         */
        if(!isAttached && OVRInput.Get(OVRInput.Button.One, OVRInput.Controller.RTouch)){
            ArrowManager.Instance.AttachBowToArrow();
            isAttached = true;
        }
    }
}
