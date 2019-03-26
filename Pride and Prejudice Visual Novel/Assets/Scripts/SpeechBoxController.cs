using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class SpeechBoxController : MonoBehaviour
{
    public TextController textController;
    public Text characterBox; 
    public BackgroundImageController backgroundImageController;
    
    
    public GameObject 
    catherinePrefab, elizabethPrefab, 
    georgianaPrefab, janePrefab, 
    lydiaPrefab, msBingleyPrefab, 
    mrBingleyPrefab, mrGardinerPrefab, 
    mrDarcyPrefab, mrsBennetPrefab, 
    wickhamPrefab;

    public GameObject 
    catherine, elizabeth, 
    georgiana, jane, 
    lydia, msBingley, 
    mrBingley, mrGardiner, 
    mrDarcy, mrsBennet, 
    wickham;


    private IEnumerator script;

    void Start(){
        script = GetScript();
        Invoke("moveNext", 0.1f);
    }

    private void moveNext(){
        script.MoveNext();
    }
    public void onClick(){
        if(textController.isDoneWithText){
            // advance to next text
            script.MoveNext();
        }
        else{
            textController.expediteText();
        }
    }

    private IEnumerator GetScript(){
        // Mr Bingley asks Mr Darcy to go with him to the party


        // SOCIAL PARTY #1
        backgroundImageController.location = 1; // TODO: change this
        characterBox.text = "Miss Bingley";
        textController.say("Hey, Mr. Darcy. You made it. How do you like the party?");
        yield return null;
        characterBox.text = "Mr. Darcy";
        textController.say("It’s ok.");
        yield return null;
    }

}
