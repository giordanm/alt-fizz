using UnityEngine;


//Special Thanks to jeffreyschoch who basically wrote this code, with minor
//Edits by William Rindone
public class ReturnToStart : MonoBehaviour
{

    private Vector3 initialLocalPosition;
    private Quaternion initialLocalRotation;
    private ExtraGrabbable grabbable;
    private Rigidbody rb;

    private void Awake()
    {
        // get the grabbable component on this object
        grabbable = GetComponent<ExtraGrabbable>();
        rb = GetComponent<Rigidbody>();
    }

    // Unity function called once when the game starts
    private void Start()
    {
        initialLocalPosition = transform.localPosition;
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

    public void OnReleased()
    {
        transform.position = initialLocalPosition;
        transform.localRotation = initialLocalRotation;
        rb.velocity = Vector3.zero;
        rb.freezeRotation = true;
    }

    public void OnGrabbed()
    {

    }

}