using System.Collections;
using System.Collections.Generic;
using Tobii.Gaming;
using UnityEngine;

public class Demon : MonoBehaviour
{
    private SpeechRecognition speechRecognition;

    private GazeAware gazeAware;
    private bool hasBeenSeen = false;

    // Start is called before the first frame update
    void Start()
    {
        speechRecognition = FindAnyObjectByType<SpeechRecognition>();

        gazeAware = GetComponent<GazeAware>();
    }

    // Update is called once per frame
    void Update()
    {
        if (gazeAware.HasGazeFocus && !hasBeenSeen)
        {
            speechRecognition.LookedAtDemon();
            hasBeenSeen = true;
        }
    }
}
