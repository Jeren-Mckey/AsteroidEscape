﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExplosionScript : MonoBehaviour {

    private Animator anim;
    private AnimatorStateInfo info;
    private bool hasPlayed;
    private bool gameOver;
	// Use this for initialization
	void Start ()
    {
        anim = gameObject.GetComponent<Animator>();
        anim.SetTrigger("StartExplosion");
        hasPlayed = false;
    }

    // Update is called once per frame
    void Update ()
    {
        info = anim.GetCurrentAnimatorStateInfo(0);
        if (info.IsName("Explosion") && !hasPlayed)
        {
            hasPlayed = true;
        }
        if (info.IsName("Default") && hasPlayed && gameOver)
        {
            SceneManager.LoadScene("EndScene");
        }
        else if (info.IsName("Default") && hasPlayed && !gameOver)
        {
            Destroy(gameObject);
        }
    }

    void secondary(bool val)
    {
        gameOver = val;
    }
}
