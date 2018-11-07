using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//Edits by William Rindone
public class HandMagic : MonoBehaviour
{

    [SerializeField]
    protected GameObject hand;
    [SerializeField]
    protected GameObject otherhand;
    [SerializeField]
    protected GameObject arrowthing;
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

    public void OnReleased()
    {
        arrowthing.GetComponent<ArrowManager>().enabled = false;
        hand.SetActive(true);
        otherhand.SetActive(true);
    }

    public void OnGrabbed()
    {
        arrowthing.GetComponent<ArrowManager>().enabled = true;
        hand.SetActive(false);
        otherhand.SetActive(false);
    }

}