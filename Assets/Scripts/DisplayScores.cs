using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DisplayScores : MonoBehaviour {

    private long score;
    public Text text;
	// Use this for initialization
	void Start ()
    {
        score = (long) Score.kilometers * 20;
        text.text = score.ToString();
    }
	
	// Update is called once per frame
	void Update ()
    {
		if (SceneManager.GetActiveScene().name == "MainScene")
        {
            score = (long)Score.kilometers * 20;
            text.text = score.ToString();
        }
	}
}
