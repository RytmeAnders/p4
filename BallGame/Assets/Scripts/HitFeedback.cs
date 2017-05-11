using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitFeedback : MonoBehaviour {

    [Range(0, 100)] public float score;
    Swoosh swoosh;              //For accessing the Dynamic bool
    public AudioClip fail;      //Local sound when you miss
    public AudioClip hit;       //Local sound when you hit
    AudioSource myAudio;        //AudioSource attached to same GameObject

    void Start () {
        swoosh = GetComponent<Swoosh>();
        myAudio = GetComponent<AudioSource>();
	}
	
	void Update () {
        if (swoosh.dynamicSound) {
            if (score > 0 && score < 25) {
                myAudio.pitch = .1F;
                myAudio.PlayOneShot(hit, 0.7F);
            }
            else if (score > 25 && score < 50) {
                myAudio.pitch = .4F;
                myAudio.PlayOneShot(hit, 0.7F);
            }
            else if (score > 50 && score < 75) {
                myAudio.pitch = .8F;
                myAudio.PlayOneShot(hit, 0.7F);
            }
            else if (score > 75 && score < 100) {
                myAudio.pitch = 1.2F;
                myAudio.PlayOneShot(hit, 0.7F);
            }
            else if (score == 0) {
                myAudio.PlayOneShot(fail, 0.7F);
            }
        }
        else { //Static
            if (score > 0) {
                myAudio.pitch = 1F;
                myAudio.PlayOneShot(hit, 0.7F);
            }
            else {
                myAudio.PlayOneShot(fail, 0.7F);
            }
        }
    }
}
