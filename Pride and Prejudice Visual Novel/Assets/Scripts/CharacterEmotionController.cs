using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterEmotionController : MonoBehaviour
{
    public Sprite[] emotions;
    private int _emotion;
    public int emotion{
        get {return _emotion;}
        set {
            _emotion = value;
            img.sprite = emotions[value];
        }
    }
    private int _scale = 100;
    public int scale{
        get {return _scale;}
        set {
            _scale = value;
            tf.sizeDelta = new Vector2(value, value*3);
        }
    }
    Image img;
    RectTransform tf;

    void Start()
    {
        img = this.gameObject.GetComponent<Image>();
        tf = transform as RectTransform;
    }
}
