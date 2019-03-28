using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleScreenController : MonoBehaviour
{
    public void launchMainScene(){
        SceneManager.LoadScene("Main Scene");
    }

    public void quitGame(){
        Application.Quit();
    }
}
