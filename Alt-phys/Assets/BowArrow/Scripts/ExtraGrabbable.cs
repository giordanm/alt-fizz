using UnityEngine;
using UnityEngine.Events;


//Special thanks to jeffreyschoch on the Unity Forums, who basically wrote this code

//This entire class basically allows us to know if an object has been grabbed or not,
//by announcing that said objec has been grabbed.

//You can also totally just use this as a replacement to OVRGrabbable,
//As it inherits all of its functions

public class ExtraGrabbable : OVRGrabbable
{
    [HideInInspector] public UnityEvent OnGrabBegin;
    [HideInInspector] public UnityEvent OnGrabEnd;

    //Tells publicly that object has been grabbed
    public override void GrabBegin(OVRGrabber hand, Collider grabPoint)
    {
        OnGrabBegin.Invoke();
        base.GrabBegin(hand, grabPoint);
    }

    //Tells publicly that object has been released
    public override void GrabEnd(Vector3 linearVelocity, Vector3 angularVelocity)
    {
        base.GrabEnd(linearVelocity, angularVelocity);
        OnGrabEnd.Invoke();
    }
}