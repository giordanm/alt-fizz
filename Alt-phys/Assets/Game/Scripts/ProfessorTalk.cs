using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProfessorTalk : MonoBehaviour {

    AudioSource aristotle;
    PlayMakerFSM playMakerFsm;
    bool sentSignal = false;

    void Start () {
        aristotle = GetComponent<AudioSource>();
        playMakerFsm = GetComponent<PlayMakerFSM>();
    }
	
	void FixedUpdate () {
        if (!aristotle.isPlaying && !sentSignal)
        {
            playMakerFsm.SendEvent("ShutUp");
        }
	}
}
