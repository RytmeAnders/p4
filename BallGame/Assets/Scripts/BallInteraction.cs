using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallInteraction : MonoBehaviour {

    GameObject ball;

	// Use this for initialization
	void Start () {
        ball = this.gameObject;
	}
	
	// Update is called once per frame
	void Update () {
        Reset();
	}

    private void Reset()
    {
       if (ball.transform.position.y < -2)
        {
            Destroy(this.gameObject);
        }
    } 
}
