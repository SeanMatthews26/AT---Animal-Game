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
    [SerializeField] private GameObject retryObject;
    [SerializeField] private GameObject nextLevelObject;
    
    [SerializeField] private GameObject demonText;

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

        keywordActions.Add("Duck", Duck);
        keywordActions.Add("Chicken", Chicken);
        keywordActions.Add("Swan", Swan);

        keywordActions.Add("Horse", Horse);
        keywordActions.Add("Goat", Goat);
        keywordActions.Add("Pig", Pig);

        keywordActions.Add("Flamingo", Flamingo);
        keywordActions.Add("Fox", Fox);
        keywordActions.Add("Hedgehog", Hedgehog);

        //Other functions called by speech
        keywordActions.Add("Pause", Pause);
        keywordActions.Add("Play", Play);
        keywordActions.Add("Menu", Menu);
        keywordActions.Add("Retry", Retry);

        keywordRecognizer = new KeywordRecognizer(keywordActions.Keys.ToArray());
        keywordRecognizer.OnPhraseRecognized += OnKeywordsRecognised;
        keywordRecognizer.Start();
    }

    private void Hedgehog()
    {

    }

    private void Fox()
    {
        
    }

    private void Flamingo()
    {
       
    }

    private void Pig()
    {
        
    }

    private void Goat()
    {
       
    }

    private void Horse()
    {
        
    }

    private void Swan()
    {
       
    }

    private void Chicken()
    {
        
    }

    private void Duck()
    {
        
    }

    private void OnKeywordsRecognised(PhraseRecognizedEventArgs args)
    {
        //Debug.Log("Keyword: " + args.text);
        keywordActions[args.text].Invoke();

        if(args.text == "Pause" ||
            args.text == "Play" ||
            args.text == "Menu" ||
            args.text == "Retry")
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

        if(paused && nextLevelObject.GetComponent<GazeAware>().HasGazeFocus)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }

    private void Menu()
    {
        if (paused && menuObject.GetComponent<GazeAware>().HasGazeFocus)
        {
            SceneManager.LoadScene(0);
        }
    }

    private void Retry()
    {
        if (paused && retryObject.GetComponent<GazeAware>().HasGazeFocus)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    public void LookedAtDemon()
    {
        if(!paused)
        {
            Time.timeScale = 0;
            paused = true;

            retryObject.SetActive(true);
            menuObject.SetActive(true);
            demonText.SetActive(true);
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
        /*//Pause button colours
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

            //RetryButton
            if (retryObject.GetComponent<GazeAware>().HasGazeFocus)
            {
                retryObject.GetComponentInChildren<SpriteRenderer>().color = Color.red;
            }
            else
            {
                retryObject.GetComponentInChildren<SpriteRenderer>().color = Color.white;
            }
        }*/
    }

    public void SetPaused()
    {
        paused = true;
    }
}
