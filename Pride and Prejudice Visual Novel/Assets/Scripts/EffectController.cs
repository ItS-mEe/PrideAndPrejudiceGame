﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EffectController : MonoBehaviour
{

    Image img;

    void Start()
    {
        img = this.gameObject.GetComponent<Image>();
        img.color = new Color32(0, 0, 0, 0);
    }

    public void fadeToBlack(GameObject toNotify){
        StartCoroutine(fadeToBlackCor(toNotify));
    }

    private IEnumerator fadeToBlackCor(GameObject toNotify){
        byte rate = 6;
        
        while(img.color.a*255 < 255-rate){
            img.color = new Color32(0, 0, 0, (byte)(img.color.a*255 + rate));
            yield return null;
        }

        img.color = new Color32(0, 0, 0, 255);
        yield return new WaitForSeconds(0.5f);

        while(img.color.a*255 > rate){
            img.color = new Color32(0, 0, 0, (byte)(img.color.a*255 - rate));
            yield return null;
        }

        img.color = new Color32(0, 0, 0, 0);
        yield return null;

        toNotify.SendMessage("transitionDone");
    }

    public void startRoseFilter(){
        img.color = new Color32(255,182,193,100);
    }

    public void stopRoseFilter(){
        img.color = new Color32(0, 0, 0, 0);
    }

}
