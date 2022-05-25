using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Windows.Speech;

public class VoiceMovement : MonoBehaviour
{
    private KeywordRecognizer keywordRecognizer;
    private Dictionary<string, Action> actions = new Dictionary<string, Action>();

    private void Start()
    {
        Debug.Log("Starting VoiceMovement");
        actions.Add("forward", Forward);
        actions.Add("up", Up);
        actions.Add("down", Down);
        actions.Add("back", Backward);

        Debug.Log("Creating KeywordRecognizer");
        keywordRecognizer = new KeywordRecognizer(actions.Keys.ToArray());
        keywordRecognizer.OnPhraseRecognized += RecognizedSpeech;
        Debug.Log("Starting KeywordRecognizer");
        keywordRecognizer.Start();
    }

    private void RecognizedSpeech(PhraseRecognizedEventArgs speech)
    {
        Debug.Log(speech.text);
        actions[speech.text].Invoke();
    }

    private void Forward()
    {
        transform.Translate(1, 0, 0); // move forward in X axis
    }

    private void Backward()
    {
        transform.Translate(-1, 0, 0); // move backward in X axis
    }

    private void Up()
    {
        transform.Translate(0, 1, 0); // move up in Y axis
    }

    private void Down()
    {
        transform.Translate(0, -1, 0); // move down in Y axis
    }
}
