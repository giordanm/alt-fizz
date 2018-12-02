using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Special Thanks to jeffreyschoch,
//This is basically an edited version of his work
public class HandMagic : MonoBehaviour
{

    //hand and otherhand are the physical hand objects, you should set those
    //to the actual hand models (not their anchors)
    [SerializeField]
    protected GameObject hand;
    [SerializeField]
    protected GameObject otherhand;

    //The object housing the arrowManager (in our case, the RightHandAnchor)
    [SerializeField]
    protected GameObject arrowthing;

    //means this needs to be on an object with the ExtraGrabbable component
    //so that we can listen for grabs
    private ExtraGrabbable grabbable;

    private void Awake()
    {
        // get the grabbable component on this object
        grabbable = GetComponent<ExtraGrabbable>();
    }


    private void OnEnable()
    {
        // listen for grabs
        grabbable.OnGrabBegin.AddListener(OnGrabbed);
        grabbable.OnGrabEnd.AddListener(OnReleased);
    }

    private void OnDisable()
    {
        // stop listening for grabs
        grabbable.OnGrabBegin.RemoveListener(OnGrabbed);
        grabbable.OnGrabEnd.RemoveListener(OnReleased);
    }

    //If the object is let go...
    public void OnReleased()
    {
        //Destroy the current arrow being held (this is why it has to be public)
        GameObject destroyThis = arrowthing.GetComponent<ArrowManager>().currentArrow;
        Destroy(destroyThis);

        //Turn off the arrowManager
        arrowthing.GetComponent<ArrowManager>().enabled = false;
   

        //Return the hand models
        hand.SetActive(true);
        otherhand.SetActive(true);
    }

    public void OnGrabbed()
    {
        //Turn on the arrowManager
        arrowthing.GetComponent<ArrowManager>().enabled = true;

        //Remove the hand models
        hand.SetActive(false);
        otherhand.SetActive(false);
    }

}