using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BackgroundImageController : MonoBehaviour
{
    
    public Sprite[] locations;
    private int _location;
    public int location{
        get {return _location;}
        set {
            _location = value;
            img.sprite = locations[value];
        }
    }
    Image img;

    void Start()
    {
        img = this.gameObject.GetComponent<Image>();
    }

}
