using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextMessageControllerController : MonoBehaviour
{

    public GameObject textMessagePrefab;
    public void recieveText(string msg){
        GameObject textMessage = Instantiate(textMessagePrefab);
        textMessage.transform.parent = this.transform;
        textMessage.GetComponent<TextMessageController>().SetText(msg);
    }
}
