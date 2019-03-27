using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterEmotionController : MonoBehaviour
{
    public Sprite[] homeView;
    public Sprite[] streetView;
    public Sprite[] ballView;

    private Sprite[] _currentView;
    private string _currentViewString;
    public string currentView{
        get {return _currentViewString;}
        set {
            if(value == "home"){
                _currentView = homeView;
            } else if(value == "street"){
                _currentView = streetView;
            } else {
                _currentView = ballView;
            }
            _currentViewString = value;
            print(_currentViewString);
            print(homeView[5]);
            print(_currentView[5]);
        }
    }
    private int _emotion;
    public int emotion{
        get {return _emotion;}
        set {
            _emotion = value;
            img.sprite = _currentView[value];
        }
    }
    private int _scale = 100;
    public int scale{
        get {return _scale;}
        set {
            _scale = value;
            tf.sizeDelta = new Vector2(value*3, value*3);
        }
    }
    Image img;
    RectTransform tf;

    void Awake()
    {
        img = this.gameObject.GetComponent<Image>();
        tf = transform as RectTransform;
    }
}
