using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeechBoxController : MonoBehaviour
{
    public TextController textController;
    public BackgroundImageController backgroundImageController;

    public void onClick(){
        if(textController.isDoneWithText){
            // advance to next text
            textController.think("these are my thoughts:\n    BOLT OF BRILLIANCE!!");
            backgroundImageController.location = 1 - backgroundImageController.location;
        }
        else{
            textController.expediteText();
        }
    }

}
