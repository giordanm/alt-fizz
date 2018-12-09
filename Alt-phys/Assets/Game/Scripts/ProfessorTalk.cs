using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Code by William Rindone

// Attach this to an object that has a PlayMaker State Machine and an AudioSource
// When the AudioSource finishes, sends a signal to the State machine

public class ProfessorTalk : MonoBehaviour {

    AudioSource aristotle;
    PlayMakerFSM playMakerFsm;
    bool sentSignal = false;

    // Sets up variables
    void Start () {
        aristotle = GetComponent<AudioSource>();
        playMakerFsm = GetComponent<PlayMakerFSM>();
    }
	
    // Sends the signal out once.
	void FixedUpdate () {
        if (!aristotle.isPlaying && !sentSignal)
        {
            playMakerFsm.SendEvent("ShutUp");
            sentSignal = true;
        }
	}
}
