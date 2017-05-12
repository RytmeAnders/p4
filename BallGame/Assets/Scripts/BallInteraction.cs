﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallInteraction : MonoBehaviour {

    MoveTarget MT;
    GameObject ball;
    Staticsound ST;
    Swoosh swoosh;

	// Use this for initialization
	void Start () {
        ball = this.gameObject;
        MT = GameObject.Find("Small Circle").GetComponent<MoveTarget>();
        ST = GameObject.Find("PlayerStatic").GetComponent<Staticsound>();
        swoosh = GameObject.Find("PlayerAudio").GetComponent<Swoosh>();
	}
	
	// Update is called once per frame
	void Update () {
        Reset();
	}

    private void Reset()
    {
       if (ball.transform.position.y < -2)
        {
            ST.aud.Stop();
            MT.missedTargetCount[MT.currentTarget] += 1;
            if (swoosh.dynamicSound) {
                //Dynamic
            }
            if (!swoosh.dynamicSound) {
                ST.playMiss();
                Destroy(this.gameObject);
                print("Current Target: " + MT.currentTarget + ", Miss: " + MT.missedTargetCount[MT.currentTarget]);
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        ST.aud.Stop();
        if (swoosh.dynamicSound) {
            //Dynamic
        }
        if (!swoosh.dynamicSound) {
            ST.playScore();
            Destroy(this.gameObject);
        }
    }
}
