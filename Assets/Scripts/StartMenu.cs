using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using Tobii.Gaming;
using UnityEngine;

public class StartMenu : MonoBehaviour
{
    [SerializeField] GameObject startButton;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(startButton.GetComponent<GazeAware>().HasGazeFocus)
        {
            Debug.Log("Start");
        }
    }
}
