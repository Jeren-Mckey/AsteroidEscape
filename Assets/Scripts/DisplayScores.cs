using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
		
	}
}
