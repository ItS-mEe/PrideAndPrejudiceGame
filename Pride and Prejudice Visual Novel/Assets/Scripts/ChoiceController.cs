using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class ChoiceController : MonoBehaviour
{

	public Text text1, text2, text3;
	public SpeechBoxController controller;
	public Button b1, b2, b3;
	

	public void offerChoices(string one, string two, string three){
		b1.gameObject.SetActive(true);
		text1.text = one;
		b2.gameObject.SetActive(true);
		text2.text = two;
		b3.gameObject.SetActive(true);
		text3.text = three;
	}

	public void clicked(int button){
		controller.makeChoice(button);
		b1.gameObject.SetActive(false);
		b2.gameObject.SetActive(false);
		b3.gameObject.SetActive(false);
	}

}
