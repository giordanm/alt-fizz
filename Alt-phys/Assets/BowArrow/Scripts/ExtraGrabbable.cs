using UnityEngine;
using UnityEngine.Events;


//Special thanks to jeffreyschoch on the Unity Forums, who basically wrote this code
public class ExtraGrabbable : OVRGrabbable
{
    [HideInInspector] public UnityEvent OnGrabBegin;
    [HideInInspector] public UnityEvent OnGrabEnd;

    public override void GrabBegin(OVRGrabber hand, Collider grabPoint)
    {
        OnGrabBegin.Invoke();
        base.GrabBegin(hand, grabPoint);
    }

    public override void GrabEnd(Vector3 linearVelocity, Vector3 angularVelocity)
    {
        base.GrabEnd(linearVelocity, angularVelocity);
        OnGrabEnd.Invoke();
    }
}