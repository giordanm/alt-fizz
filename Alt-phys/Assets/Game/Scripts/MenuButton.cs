using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuButton : MonoBehaviour
{

    public UnityEngine.Object sceneToLoad;
    public Material[] states;
    Renderer rend;

    void Start()
    {
        rend = GetComponent<Renderer>();
        rend.enabled = true;
        rend.sharedMaterial = states[0];
    }

    private void OnEnable()
    {
        rend.sharedMaterial = states[0];
    }

    private void OnTriggerStay(Collider other)
    {
        rend.sharedMaterial = states[1];
        if (gameObject.CompareTag("QuitBox") && OVRInput.Get(OVRInput.Button.One, OVRInput.Controller.RTouch))
        {
            Application.Quit();
        }
        if (gameObject.CompareTag("TeleportBox") && OVRInput.Get(OVRInput.Button.One, OVRInput.Controller.RTouch))
        {
            SceneManager.LoadScene(sceneToLoad.name);
        }
        if (gameObject.CompareTag("StateBox") && OVRInput.Get(OVRInput.Button.One, OVRInput.Controller.RTouch))
        {
            gameObject.GetComponent<PlayMakerFSM>().SendEvent("Button Pressed");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        rend.sharedMaterial = states[1];
        if (gameObject.CompareTag("QuitBox") && OVRInput.Get(OVRInput.Button.One, OVRInput.Controller.RTouch))
        {
            Application.Quit();
        }
        if (gameObject.CompareTag("TeleportBox") && OVRInput.Get(OVRInput.Button.One, OVRInput.Controller.RTouch))
        {
            SceneManager.LoadScene(sceneToLoad.name);
        }
        if (gameObject.CompareTag("StateBox") && OVRInput.Get(OVRInput.Button.One, OVRInput.Controller.RTouch))
        {
            gameObject.GetComponent<PlayMakerFSM>().SendEvent("Button Pressed");
        }
    }

    private void OnTriggerExit()
    {
        rend.sharedMaterial = states[0];
    }

}