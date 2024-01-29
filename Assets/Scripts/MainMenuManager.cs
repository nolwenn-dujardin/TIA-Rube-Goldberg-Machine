using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    public void easyMode(){
        StaticClass.IsEasyMode = true;
        SceneManager.LoadScene("MainCourse");
    }

    public void hardMode(){
        StaticClass.IsEasyMode = false;
        SceneManager.LoadScene("MainCourse");
    }

    public void quit(){
        Application.Quit();
    }
}
