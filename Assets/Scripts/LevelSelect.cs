using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Tobii.Gaming;
using UnityEngine;
using UnityEngine.Windows.Speech;
using UnityEngine.SceneManagement;

public class LevelSelect : MonoBehaviour
{
    //Speech Recognition
    private Dictionary<string, Action> keywordActions = new Dictionary<string, Action>();
    private KeywordRecognizer keywordRecognizer;

    [SerializeField] private GameObject oneObject;
    private GazeAware oneGazeAware;

    [SerializeField] private GameObject twoObject;
    private GazeAware twoGazeAware;

    [SerializeField] private GameObject threeObject;
    private GazeAware threeGazeAware;

    [SerializeField] private GameObject fourObject;
    private GazeAware fourGazeAware;

    [SerializeField] private GameObject menuObject;
    private GazeAware menuGazeAware;

    // Start is called before the first frame update
    void Start()
    {
        oneGazeAware = oneObject.GetComponent<GazeAware>();
        twoGazeAware = twoObject.GetComponent<GazeAware>();
        threeGazeAware = threeObject.GetComponent<GazeAware>();
        fourGazeAware = fourObject.GetComponent<GazeAware>();
        menuGazeAware = menuObject.GetComponent<GazeAware>();

        //Speech Keywords
        keywordActions.Add("one", One);
        keywordActions.Add("two", Two);
        keywordActions.Add("three", Three);
        keywordActions.Add("four", Four);
        keywordActions.Add("menu", Menu);

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

    }

    private void One()
    {
        if (oneGazeAware.HasGazeFocus)
        {
            SceneManager.LoadScene(1);
        }
    }

    private void Two()
    {
        if (twoGazeAware.HasGazeFocus)
        {
            SceneManager.LoadScene(3);
        }
    }

    private void Three()
    {
        if(threeGazeAware.HasGazeFocus)
        {
            SceneManager.LoadScene(5);
        }
    }

    private void Four()
    {
        if(fourGazeAware.HasGazeFocus)
        {
            SceneManager.LoadScene(7);
        }
    }

    private void Menu()
    {
        if(menuGazeAware.HasGazeFocus)
        {
            SceneManager.LoadScene(0);
        }
    }
}