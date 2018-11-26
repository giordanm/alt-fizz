using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This code is more or less completely made by owner of FusedVR youtube channel
//Updated by William Rindone to work with the Oculus SDK (OVR more specifically)
//If future people are using this code. Hi, there are probably better ways to do this, but
//This way is pretty cool too.

//For proper usage, after making a base VR controller character using the methods
//taught in class, you want to attach this script to RightHandAnchor, and set it to not active
//and set the values as the following:
//Tracked Obj = RightHandAnchor
//Current Arrow = None
//String Attach Point = String
//Arrow Start Point = ArrowStart
//String Start Point = String
//Arrow Prefab (This can be different, it's just the way we set it up)
//  size = 4
//  Element 0 = EarthArrow
//  Element 1 = WaterArrow
//  Element 2 = AirArrow
//  Element 3 = FireArrow
//Type Number = 0

public class ArrowManager : MonoBehaviour
{
    //makes this a singleton class
    public static ArrowManager Instance;

    //The object the arrow is going to track while not actively attached to the bow
    //or fired (In our case, the righthand anchor)
    public GameObject trackedObj;

    //The currentArrow (I made this public because I couldn't find a good way to destroy
    //the arrow otherwise. The tutorial normally has this set to private. If you're using
    //this specific version of the code, you basically do not want to put anything
    //in this public slot
    public GameObject currentArrow;

    //The string of the bow (tells the arrow to track to this when attached)
    public GameObject stringAttachPoint;

    //The starting point of the arrow (because the arrow is actually part of the bow
    //model, this keeps track of where the arrow is in location to its starting point)
    public GameObject arrowStartPoint;

    //The starting point of the string (used to animate the string)
    public GameObject stringStartPoint;
    
    //An array, holding the different types of arrows that can be fired from the bow
    public GameObject[] arrowPrefab;

    //What type of arrow you want to fire from the bow
    public int typeNumber;

    //Tells the manager whether the arrow should be attached to the bow or not
    private bool isAttached = false;

    //When created, tests that typeNumber is valid (sets to 0 if it isn't)
    //Then initiates this object as a singleton (only one can be active at
    //any time
    private void Awake()
    {
        if(typeNumber < 0 || typeNumber > arrowPrefab.Length - 1)
        {
            typeNumber = 0;
        }
        if(Instance == null){
            Instance = this;
        }
    }

    //Closing of singleton
    private void OnDestroy()
    {
        if (Instance == this)
        {
            Instance = null;
        }
    }

    //Does these 3 tests on every frame:
    //1. If the user presses the X button on the Left Occulus controller,
    //   and the arrow is not attached, then change
    //   the current arrow type to the next type of arrow in the prefabs
    //2. See if a new arrow needs to be spawned
    //3. Update the string (if it is being pulled)
    void Update()
    {
        if (!isAttached && OVRInput.GetUp(OVRInput.Button.One, OVRInput.Controller.LTouch))
        {
            Destroy(currentArrow);
            if(typeNumber < arrowPrefab.Length - 1)
            {
                typeNumber++;
            } else
            {
                typeNumber = 0;
            }
        }
        AttachArrow();
        PullString();
    }

    //handles how the string works
    private void PullString(){
        //If the arrow is attached to the bow...
        if(isAttached){
            //Makes sure the CurrentArrow follows along with the bow
            currentArrow.transform.localPosition = arrowStartPoint.transform.localPosition;
            currentArrow.transform.localRotation = arrowStartPoint.transform.localRotation;

            //Calculates how far to pull the string back based on difference in distance
            //between hands
            float dist = (stringStartPoint.transform.position - trackedObj.transform.position).magnitude;

            //And moves the string
            stringAttachPoint.transform.localPosition = stringStartPoint.transform.localPosition + new Vector3(5f*dist, 0f, 0f);

            //When stop holding the button holding the arrow, fires the arrow
            if (OVRInput.GetUp(OVRInput.Button.One, OVRInput.Controller.RTouch))
            {
                Fire();
            }
        }
    }

    //Fires the arrow
    private void Fire(){
        //How far back the arrow is pulled
        float dist = (stringStartPoint.transform.position - trackedObj.transform.position).magnitude;
        
        //tells arrow to stop following the bow, and to tell the arrow that it's been fired
        currentArrow.transform.parent = null;
        currentArrow.GetComponent<Arrow>().Fired();

        //Gets the arrow's rigid body and tells it to shoot at velocity based
        //on how far it's pulled back (multiplied by a value, in this case 10f,
        //but that can be changed on preference
        Rigidbody r = currentArrow.GetComponent<Rigidbody>();
        r.velocity = currentArrow.transform.forward * 10f * dist;

        //Also tells arrow to start being effected similarly to how the elements are
        Element test = currentArrow.GetComponent<Element>();
        test.enabled = true;

        //Tells the string to return to normal
        stringAttachPoint.transform.position = stringStartPoint.transform.position;

        //Says that we need another arrow, and that no arrow is attached
        currentArrow = null;
        isAttached = false;
    }

    //Spawns an arrow if one is needed.
    private void AttachArrow(){
        if(currentArrow == null){
            currentArrow = Instantiate(arrowPrefab[typeNumber]);
            //Tracks the movement of the arrow to the movement of the right hand
            currentArrow.transform.parent = trackedObj.transform;
            currentArrow.transform.localPosition = new Vector3(0f, 0f, .342f);
            currentArrow.transform.localRotation = Quaternion.identity;
        }
    }

    //If given the call from the current arrow, attaches the arrow to the bow.
    public void AttachBowToArrow(){
        //Tells the arrow to start following the bow
        currentArrow.transform.parent = stringAttachPoint.transform;
        currentArrow.transform.localPosition = arrowStartPoint.transform.localPosition;
        currentArrow.transform.localRotation = arrowStartPoint.transform.localRotation;

        //sets isAttached to true.
        isAttached = true;
    }
}
