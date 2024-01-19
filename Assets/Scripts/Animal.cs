using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using Tobii.Gaming;
using UnityEngine;

public class Animal : MonoBehaviour
{
    private Vector2 mousePos;
    private BoxCollider2D boxCollider2D;

    private Canvas UICanvas;
    private Score score;

    private GazeAware gazeAware;

    // Start is called before the first frame update
    void Start()
    {
        gazeAware = GetComponent<GazeAware>();

        //UICanvas = FindObjectOfType<Canvas>();
        score = GameObject.FindAnyObjectByType<Score>();
    }

    private void OnEnable()
    {
        boxCollider2D = GetComponent<BoxCollider2D>();

    }

    // Update is called once per frame
    void Update()
    {
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        if(gazeAware.HasGazeFocus)
        {
            //Debug.Log("Gaze");
        }
    }

    public void Catch()
    {
        /*if(boxCollider2D == null)
        {
            Debug.Log("NoCollider");
            return;
        }

        if(boxCollider2D.OverlapPoint(mousePos))
        {
            //Debug.Log("Overlap");

            UICanvas.GetComponent<Score>().score++;
            Destroy(gameObject);*/

       
    }

    public void CatchWithEyes()
    {
        if (gazeAware.HasGazeFocus)
        {
            score.AddToScore();
            Destroy(gameObject);
        }
    }
}
