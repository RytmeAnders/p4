using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitFeedback : MonoBehaviour {

    [Range(0, 100)] public float score;
    AudioSource ding;

    void Start () {
        ding = GetComponent<AudioSource>();
	}
	
	void Update () {
        ding.pitch = .1F + (score/100);
	}
}
