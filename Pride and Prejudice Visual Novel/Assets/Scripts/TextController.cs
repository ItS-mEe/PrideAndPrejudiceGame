using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextController : MonoBehaviour
{
    Text text;
    public int framesBetweenEachCharacter = 1;
    bool expedite = false, _isDoneWithText = true, paused = false;
    public bool isDoneWithText{
        get {return _isDoneWithText;}
    }
    void Start()
    {
        text = this.gameObject.GetComponent<Text>();
        say("rip x\nmore text!!!1!!!1!1!!!one!");
        if(!PlayerPrefs.HasKey("framesToDelay")){
            PlayerPrefs.SetInt("framesToDelay", 3);
        } else{
            framesBetweenEachCharacter = PlayerPrefs.GetInt("framesToDelay");
        }
    }

    public void expediteText(){
        expedite = true;
    }

    public void say(string words){
        text.fontStyle = FontStyle.Normal;
        StartCoroutine(WriteTextCoroutine(words));
    }

    public void think(string words){
        text.fontStyle = FontStyle.Italic;
        StartCoroutine(WriteTextCoroutine(words));
    }

    IEnumerator WriteTextCoroutine(string words){
        _isDoneWithText = false;
        text.text = "";
        for(int i = 0; i<=words.Length; i++){
            text.text = words.Substring(0,i);
            for(int frame = 0; (frame<framesBetweenEachCharacter && !expedite) || paused; frame++) yield return null;
        }
        expedite = false;
        _isDoneWithText = true;
    }

    public void SetDelay(int framesToDelay){
        framesBetweenEachCharacter = framesToDelay;
        PlayerPrefs.SetInt("framesToDelay", framesToDelay);
    }
}
