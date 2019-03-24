using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsUIController : MonoBehaviour
{
    public GameObject settingsPopup;
    public TextController speech;
    public Slider delaySlider;

    public void Save(){
        PlayerPrefs.Save();
        settingsPopup.SetActive(false);
        speech.SetDelay((int)delaySlider.value);
    }
    public void Open(){
        settingsPopup.SetActive(true);
        delaySlider.value = speech.framesBetweenEachCharacter;
    }
}
