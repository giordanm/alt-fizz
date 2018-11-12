using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This code is more or less completely made by owner of FusedVR youtube channel
//Updated by William Rindone to work with the Oculus SDK

public class ArrowManager : MonoBehaviour
{

    public static ArrowManager Instance;

    //Supposedly Going to track the remote
    public GameObject trackedObj;

    private GameObject currentArrow;

    public GameObject stringAttachPoint;

    public GameObject arrowStartPoint;

    public GameObject stringStartPoint;
    
    public GameObject arrowPrefab;

    private bool isAttached = false;

    private void Awake()
    {
        if(Instance == null){
            Instance = this;
        }
    }

    private void OnDestroy()
    {
        if (Instance == this)
        {
            Instance = null;
        }
    }

    // Use this for initialization
    void Start () {
		
	}

    void Update()
    {
        AttachArrow();
        PullString();
    }

    private void PullString(){
        if(isAttached){
            currentArrow.transform.localPosition = arrowStartPoint.transform.localPosition;
            currentArrow.transform.localRotation = arrowStartPoint.transform.localRotation;
            float dist = (stringStartPoint.transform.position - trackedObj.transform.position).magnitude;
            stringAttachPoint.transform.localPosition = stringStartPoint.transform.localPosition + new Vector3(5f*dist, 0f, 0f);

            //See Arrow for more on this thing...
            if (OVRInput.GetUp(OVRInput.Button.One, OVRInput.Controller.RTouch))
            {
                Fire();
            }
        }
    }

    private void Fire(){
        float dist = (stringStartPoint.transform.position - trackedObj.transform.position).magnitude;
        currentArrow.transform.parent = null;
        currentArrow.GetComponent<Arrow>().Fired();
        Rigidbody r = currentArrow.GetComponent<Rigidbody>();
        r.velocity = currentArrow.transform.forward * 10f * dist;
        r.useGravity = true;

        stringAttachPoint.transform.position = stringStartPoint.transform.position;

        currentArrow = null;
        isAttached = false;
    }

    private void AttachArrow(){
        if(currentArrow == null){
            currentArrow = Instantiate(arrowPrefab);
            //Tracks the movement of the arrow to the movement of the remote
            currentArrow.transform.parent = trackedObj.transform;
            currentArrow.transform.localPosition = new Vector3(0f, 0f, .342f);
            currentArrow.transform.localRotation = Quaternion.identity;
        }
    }

    public void AttachBowToArrow(){
        currentArrow.transform.parent = stringAttachPoint.transform;
        currentArrow.transform.localPosition = arrowStartPoint.transform.localPosition;
        currentArrow.transform.localRotation = arrowStartPoint.transform.localRotation;

        isAttached = true;
    }
}
