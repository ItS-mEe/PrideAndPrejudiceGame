using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextMessageController : MonoBehaviour
{
    
    public Text text;

    public void SetText(string msg){
        text.text = msg;
    }

}
