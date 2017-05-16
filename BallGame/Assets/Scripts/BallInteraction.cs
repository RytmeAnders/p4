using System.Collections;
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
            MT.missedTargetCount[MoveTarget.currentTarget] += 1;
            if (swoosh.dynamicSound) {
                float dist = Vector3.Distance(ball.transform.position, MT.targets.transform.position);
                ST.GetComponent<AudioReverbFilter>().reverbLevel = (dist / 100);
                ST.playMiss();
                Destroy(this.gameObject);
                print("Current Target: " + MoveTarget.currentTarget + ", Miss: " + MT.missedTargetCount[MoveTarget.currentTarget]);
                print("Distance: " + dist);
                ST.GetComponent<AudioReverbFilter>().reverbLevel = -10000;
            }
            if (!swoosh.dynamicSound) {
                ST.playMiss();
                Destroy(this.gameObject);
                print("Current Target: " + MoveTarget.currentTarget + ", Miss: " + MT.missedTargetCount[MoveTarget.currentTarget]);
            }
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        ST.aud.Stop();
        if (swoosh.dynamicSound) {
            ST.aud.pitch = .3f + ((MT.increaseScore * 1.5f) / 10);
            ST.playScore();
            Destroy(this.gameObject);
        }
        if (!swoosh.dynamicSound) {
            ST.playScore();
            Destroy(this.gameObject);
        }
    }
}
