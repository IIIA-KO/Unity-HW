using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainPanelScript : MonoBehaviour
{
    public TextAsset file;
    public Text uiText; 
    private Dictionary<string, string> zodiakDictionary; 
    private void Start()
    {
        var text = file.text;
        var zodiaks = text.Split('\n');
        zodiakDictionary = new Dictionary<string, string>();
        foreach (var zodiak in zodiaks)
        {
            string[] keyValue = zodiak.Split(':');
            zodiakDictionary.Add(keyValue[0], keyValue[1]);
        }
    }
    public void ShowText(string key)
    {
        uiText.text = zodiakDictionary[key];
    }
}
