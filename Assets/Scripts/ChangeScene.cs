using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour {

    public GameObject sound;
    public void changeScene(string sceneName)
    {
        if (SceneManager.GetActiveScene().name == "MenuScene" && sceneName == "TutorialScene")
        {
           DontDestroyOnLoad(sound);
        }
        SceneManager.LoadScene(sceneName);
    }

    public void endGame()
    {
        Application.Quit();
    }
}
