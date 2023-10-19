using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.Windows.Speech;

public class SpeechRecognition : MonoBehaviour
{
    //Speech
    private Dictionary<string, Action> keywordActions = new Dictionary<string, Action>();
    private KeywordRecognizer keywordRecognizer;

    //Prefabs
    [SerializeField] private GameObject CowGameObject;

    // Start is called before the first frame update
    void Start()
    {
        keywordActions.Add("Cow", Cow);
        keywordActions.Add("Bear", Bear);
        keywordActions.Add("Sheep", Sheep);
        keywordActions.Add("Moose", Moose);

        keywordRecognizer = new KeywordRecognizer(keywordActions.Keys.ToArray());
        keywordRecognizer.OnPhraseRecognized += OnKeywordsRecognised;
        keywordRecognizer.Start();
    }

    private void OnKeywordsRecognised(PhraseRecognizedEventArgs args)
    {
        //Debug.Log("Keyword: " + args.text);
        //keywordActions[args.text].Invoke();

        GameObject[] animals = GameObject.FindGameObjectsWithTag(args.text);
        foreach (GameObject animal in animals)
        {
            animal.GetComponent<Animal>().Catch();
        }
    }

    private void Cow()
    {
        GameObject[] cows = GameObject.FindGameObjectsWithTag("Cow");
        foreach (GameObject cow in cows)
        {
            cow.GetComponent<Animal>().Catch();
        }
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
        
    }
}
