using UnityEngine;


//Special Thanks to jeffreyschoch who basically wrote this code, with minor
//Edits by William Rindone

//If an object is released, returns it to the position it was originally in
//Note: needs to be on an object with the ExtraGrabbable Script

//Hi Future Groups. The purpose of this code has changed to allow the object to maintain
//It's position, while only redoing its rotation. If you ever want to change it to the above
//Descriptor, simply uncomment any line that contains code.

public class ReturnToStart : MonoBehaviour
{

   // private Vector3 initialLocalPosition;
    private Quaternion initialLocalRotation;
    private ExtraGrabbable grabbable;
    private Rigidbody rb;

    private void Awake()
    {
        // get the grabbable component on this object
        grabbable = GetComponent<ExtraGrabbable>();
        rb = GetComponent<Rigidbody>();
    }

    // Sets the initial location and orientation of the obeject
    private void Start()
    {
        //initialLocalPosition = transform.localPosition;
        initialLocalRotation = transform.localRotation;
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

    //When the object is released, returns it to its inital position
    public void OnReleased()
    {
       // transform.position = initialLocalPosition;
        transform.localRotation = initialLocalRotation;
        rb.velocity = Vector3.zero;
        rb.freezeRotation = true;
    }

    //does nothing when the object is grabbed
    public void OnGrabbed()
    {

    }

}