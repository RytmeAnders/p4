using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallInteraction : MonoBehaviour {

    MoveTarget MT;
    GameObject ball;

	// Use this for initialization
	void Start () {
        ball = this.gameObject;
        MT = GameObject.Find("Small Circle").GetComponent<MoveTarget>();
	}
	
	// Update is called once per frame
	void Update () {
        Reset();
	}

    private void Reset()
    {
       if (ball.transform.position.y < -2)
        {
            MT.missedTargetCount[MT.currentTarget] += 1;
            Destroy(this.gameObject);
            print("Current Target: " + MT.currentTarget + ", Miss: " + MT.missedTargetCount[MT.currentTarget]);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        Destroy(this.gameObject);
    }
}
