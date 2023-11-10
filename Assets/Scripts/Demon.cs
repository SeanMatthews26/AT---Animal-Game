using System.Collections;
using System.Collections.Generic;
using Tobii.Gaming;
using UnityEngine;

public class Demon : MonoBehaviour
{
    private GazeAware gazeAware;

    // Start is called before the first frame update
    void Start()
    {
        gazeAware = GetComponent<GazeAware>();
    }

    // Update is called once per frame
    void Update()
    {
        if (gazeAware.HasGazeFocus)
        {
            Debug.Log("DEMON!");
            Time.timeScale = 0;
        }
    }
}
