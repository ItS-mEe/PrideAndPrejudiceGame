using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class FaceShower : MonoBehaviour
{
    
    private Image img;

    void Start(){
        img = this.GetComponent<Image>();
    }

    public void setFace(CharacterEmotionController cec){
        img.sprite = cec.GetComponent<Image>().sprite;
    }

}
