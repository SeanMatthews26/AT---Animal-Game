using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Tobii.Gaming;
using UnityEngine;
using UnityEngine.Windows.Speech;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    //Speech Recognition
    private Dictionary<string, Action> keywordActions = new Dictionary<string, Action>();
    private KeywordRecognizer keywordRecognizer;

    [SerializeField] private GameObject playObject;
    private GazeAware playGazeAware;

    [SerializeField] private GameObject levelObject;
    private GazeAware levelGazeAware;

    // Start is called before the first frame update
    void Start()
    {
        playGazeAware = playObject.GetComponent<GazeAware>();
        levelGazeAware = levelObject.GetComponent<GazeAware>();

        //Speech Keywords
        keywordActions.Add("play", Play);
        keywordActions.Add("level", Level);

        keywordRecognizer = new KeywordRecognizer(keywordActions.Keys.ToArray());
        keywordRecognizer.OnPhraseRecognized += OnKeywordsRecognised;
        keywordRecognizer.Start();
    }

    private void OnKeywordsRecognised(PhraseRecognizedEventArgs args)
    {
        Debug.Log("Keyword: " + args.text);
        keywordActions[args.text].Invoke();

    }

    // Update is called once per frame
    void Update()
    {
        /*if(playGazeAware.HasGazeFocus)
        {
            playObject.GetComponentInChildren<SpriteRenderer>().color = Color.red;
        }
        else
        {
            playObject.GetComponentInChildren<SpriteRenderer>().color = Color.white;
        }*/
    }

    private void Play()
    {
        if(playGazeAware.HasGazeFocus)
        {
            SceneManager.LoadScene(1);
        }
    }

    private void Level()
    {
        if(levelGazeAware.HasGazeFocus)
        {
            SceneManager.LoadScene(9);
        }
    }
}
