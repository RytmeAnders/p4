using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Staticsound : MonoBehaviour {

    public AudioClip staticSwoosh;
    public AudioClip staticChirp;
    public AudioClip staticThud;
    public AudioClip staticScore;
    public AudioClip staticMiss;

    public AudioSource aud;

	void Start () {
        aud = GetComponent<AudioSource>();
	}
	
	void Update () {
        if (Input.GetKeyDown(KeyCode.T)) {
            playSwoosh();
        }
        if (Input.GetKeyDown(KeyCode.Y)) {
            playChirp();
        }
        if (Input.GetKeyDown(KeyCode.U)) {
            playThud();
        }
        if (Input.GetKeyDown(KeyCode.I)) {
            playScore();
        }
        if (Input.GetKeyDown(KeyCode.O)) {
            playMiss();
        }
    }

    public void playSwoosh() { //T
        if (!aud.isPlaying) {
            aud.PlayOneShot(staticSwoosh);
        }
    }
    public void playChirp() { //Y
        if (!aud.isPlaying) {
            aud.PlayOneShot(staticChirp);
        }
    }
    public void playThud() { //U
        if (!aud.isPlaying) {
            aud.PlayOneShot(staticThud);
        }
    }
    public void playScore() { //I
        if (!aud.isPlaying) {
            aud.PlayOneShot(staticScore);
        }
    }
    public void playMiss() { //O
        if (!aud.isPlaying) {
            aud.PlayOneShot(staticMiss);
        }
    }
}
