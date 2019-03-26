using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class SpeechBoxController : MonoBehaviour
{
    public TextController textController;
    public Text characterBox; 
    public BackgroundImageController backgroundImageController;
    public ChoiceController choiceController;

    
    public GameObject 
    catherinePrefab, elizabethPrefab, 
    georgianaPrefab, janePrefab, 
    lydiaPrefab, msBingleyPrefab, 
    mrBingleyPrefab, mrGardinerPrefab, 
    mrDarcyPrefab, mrsBennetPrefab, 
    wickhamPrefab, mrBennetPrefab;

    public GameObject 
    catherine, elizabeth, 
    georgiana, jane, 
    lydia, msBingley, 
    mrBingley, mrGardiner, 
    mrDarcy, mrsBennet, 
    wickham, mrBennet;


    private IEnumerator script;
    private bool choosing;
    private int choice;

    void Start(){
        script = GetScript();
        Invoke("moveNext", 0.1f);
    }

    private void moveNext(){
        script.MoveNext();
    }
    public void onClick(){
        if(choosing){
            return;
        }

        if(textController.isDoneWithText){
            // advance to next text
            script.MoveNext();
        }
        else{
            textController.expediteText();
        }
    }

    public void makeChoice(int choice){
        choosing = false;
        this.choice = choice;
        this.onClick();
    }

    private IEnumerator GetScript(){
        // Mr Bingley asks Mr Darcy to go with him to the party
      backgroundImageController.location = 1; // TODO: change this
        characterBox.text = "Mr Bingley";
        textController.say("Hey Darcy, want to go to the Tim Cook's social with me? There will be cute girls I swear, and anyways, we are visiting the Apple headquarters in Cupertino anyways.");
        choiceController.offerChoices("I would rather stay in the hotel and read.", "I will go with you, but only to meet new connections.", "Only if you go as my date.");
        choosing = true;
        yield return null;
      
        if(choice == 1){
            //dialogue for choice 1
            characterBox.text = "Mr. Bingley";
            textController.say("Reading? You’re so old fashioned. Come on. Please. Please. I’ll be lonely.");
            yield return null;

            characterBox.text = "Mr. Darcy";
            textController.say("Fine. Whatever.");
            yield return null;

        } else if (choice == 2) {
            //dialogue for choice 2
        } else {
            //dialogue for choice 3
        }

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
