using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEditor;
using Tobii.Gaming;
using UnityEngine;
using UnityEngine.Windows.Speech;
using UnityEngine.SceneManagement;

public class SpeechRecognition : MonoBehaviour
{
    //Speech
    private Dictionary<string, Action> keywordActions = new Dictionary<string, Action>();
    private KeywordRecognizer keywordRecognizer;

    //Prefabs
    [SerializeField] private GameObject playObject;
    [SerializeField] private GameObject menuObject;

    private bool paused = false;

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;

        //Animals
        keywordActions.Add("Cow", Cow);
        keywordActions.Add("Bear", Bear);
        keywordActions.Add("Sheep", Sheep);
        keywordActions.Add("Moose", Moose);

        //Other functions called by speech
        keywordActions.Add("Pause", Pause);
        keywordActions.Add("Play", Play);
        keywordActions.Add("Menu", Menu);

        keywordRecognizer = new KeywordRecognizer(keywordActions.Keys.ToArray());
        keywordRecognizer.OnPhraseRecognized += OnKeywordsRecognised;
        keywordRecognizer.Start();
    }

    private void OnKeywordsRecognised(PhraseRecognizedEventArgs args)
    {
        //Debug.Log("Keyword: " + args.text);
        keywordActions[args.text].Invoke();

        if(args.text == "Pause" ||
            args.text == "Play" ||
            args.text == "Menu")
        {
            return;
        }

        //Catch Animals
        if(!paused)
        {
            GameObject[] animals = GameObject.FindGameObjectsWithTag(args.text);
            foreach (GameObject animal in animals)
            {
                animal.GetComponent<Animal>().CatchWithEyes();
            }
        }
    }

    private void Pause()
    {
        if(!paused)
        {
            Time.timeScale = 0;
            paused = true;

            playObject.SetActive(true);
            menuObject.SetActive(true);
        }
    }

    private void Play()
    {
        if(paused && playObject.GetComponent<GazeAware>().HasGazeFocus)
        {
            Time.timeScale = 1;
            paused = false;

            playObject.SetActive(false);
            menuObject.SetActive(false);
        }
    }

    private void Menu()
    {
        if (paused && menuObject.GetComponent<GazeAware>().HasGazeFocus)
        {
            SceneManager.LoadScene(0);
        }
    }

    private void Cow()
    {
        Debug.Log("Cow");
    }

    private void Bear()
    {
        Debug.Log("Bear");
    }

    private void Sheep()
    {
        Debug.Log("Sheep");
    }

    private void Moose()
    {
        Debug.Log("Moose");
    }

    // Update is called once per frame
    void Update()
    {
        //Pause button colours
        if(paused)
        {
            //PlayButton
            if (playObject.GetComponent<GazeAware>().HasGazeFocus)
            {
                playObject.GetComponentInChildren<SpriteRenderer>().color = Color.red;
            }
            else
            {
                playObject.GetComponentInChildren<SpriteRenderer>().color = Color.white;
            }

            //MenuButton
            if (menuObject.GetComponent<GazeAware>().HasGazeFocus)
            {
                menuObject.GetComponentInChildren<SpriteRenderer>().color = Color.red;
            }
            else
            {
                menuObject.GetComponentInChildren<SpriteRenderer>().color = Color.white;
            }
        }
    }
}
