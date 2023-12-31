using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using Tobii.Gaming;
using UnityEngine;

public class StartMenu : MonoBehaviour
{
    [SerializeField] Button startButton;
    RectTransform rt;

    // Start is called before the first frame update
    void Start()
    {
        rt = startButton.GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void Update()
    {
        /*if(startButton.GetComponent<GazeAware>().HasGazeFocus)
        {
            Debug.Log("Start");
        }*/

        //Debug.Log(TobiiAPI.GetGazePoint().Screen);

        /*if (startButton.GetComponent<Rect>().Contains(TobiiAPI.GetGazePoint().Screen))
        {
            Debug.Log("Start");
        }*/

        Debug.Log(TobiiAPI.GetGazePoint().Screen);

        Rect r = new Rect(rt.position.x, rt.position.y, rt.rect.width, rt.rect.height);

        if (r.Contains(TobiiAPI.GetGazePoint().Screen))
        {
           Debug.Log("Start");
            startButton.image.color = Color.red;
        }
        else
        {
            startButton.image.color = Color.white;
        }
    }
}
