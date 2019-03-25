using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Score : MonoBehaviour {

    public static float kilometers;

	// Use this for initialization
	void Start ()
    {
        kilometers = 0;
        DontDestroyOnLoad(this);
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (SceneManager.GetActiveScene().name == "MainScene") kilometers++;
        if (SceneManager.GetActiveScene().name == "MenuScene") kilometers = 0;
	}
}
