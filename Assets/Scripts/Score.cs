using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{
    [SerializeField] GameObject speechRecognition;
    private SpeechRecognition speechRecognitionScript;

    public int score = 0;
    [SerializeField] TextMeshProUGUI scoreText;

    [SerializeField] private int scoreNeeded;
    [SerializeField] TextMeshProUGUI scoreNeededText;

    [SerializeField] GameObject nextLevelObject;
    [SerializeField] GameObject menuObject;

    [SerializeField] GameObject winText;

    // Start is called before the first frame update
    void Start()
    {
        speechRecognitionScript = speechRecognition.GetComponent<SpeechRecognition>();

        scoreNeededText.text =  "/" + scoreNeeded.ToString();
        scoreText.text = score.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddToScore()
    {
        score++;
        scoreText.text = score.ToString();

        if (score >= scoreNeeded)
        {
            Time.timeScale = 0;
            speechRecognitionScript.SetPaused();

            nextLevelObject.SetActive(true);
            menuObject.SetActive(true);

            winText.SetActive(true);

            GetComponent<Canvas>().enabled = false;
        }
    }
}
