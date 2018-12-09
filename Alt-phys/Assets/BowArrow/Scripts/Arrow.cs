using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This code is more or less completely made by owner of FusedVR youtube channel
//Updated by William Rindone to work with the Oculus SDK (And minor edits for some cool stuff)
//If future people are using this code. Hi, there are probably better ways to do this, but
//This way is pretty cool too.

//For proper usage, only attach this script to arrow objects

public class Arrow : MonoBehaviour {

    //bool value informing Arrow (and Manager) if the arrow is attached
    private bool isAttached = false;

    //bool value informing Arrow (and Manager) if the arrow is attached
    private bool isFired = false;

    //If the arrow is in a trigger, makes it possible to attach the arrow
    //to the bow (Note, this applies for anything that is a trigger, including
    //many things relating to main character. I may go back and fix this later
    //to ensure that it only works if the trigger is the bow, but it's not the end
    //of the world if I don't
    void OnTriggerStay()
    {
            AttachArrow();
    }

    //If the arrow enters a trigger, makes it possible to attach the arrow
    //to the bow (Note: See above note)
    void OnTriggerEnter()
    {
            AttachArrow();
    }


    //Is called at every available frame while the system processes the scens
    private void Update()
    {
        //If the arrow is fired, has the arrow look in the direction it is traveling
        if(isFired){
            transform.LookAt(transform.position + transform.GetComponent<Rigidbody>().velocity);
        }
    }

    //If the arrow is fired, sets isFired to true.
    //Then destroys the arrow 10 seconds later (if you want to change the arrow lifespan,
    //adjust the second value of destroy)
    public void Fired(){
        isFired = true;
        Destroy(gameObject, 10);
    }


    //If the arrow is not attached, but can be, and the user presses the a button
    //on the right controller, tells the manager to attach the arrow to the bow
    //and set isAttached to true.
    private void AttachArrow(){
        if(!isAttached && OVRInput.Get(OVRInput.Button.One, OVRInput.Controller.RTouch)){
            ArrowManager.Instance.AttachBowToArrow();
            isAttached = true;
        }
    }

    //Hey, Future Groups,
    //Here's an explanation on checking controller presses for OVR found
    //on a forum somewhere (sorry, I would post credit, but lost the link)
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
}
