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
    AudioSource dyn;
    Swoosh swoosh;

	void Start () {
        aud = GetComponent<AudioSource>();
        dyn = GameObject.Find("Audio Chirp").GetComponent<AudioSource>();
        swoosh = GameObject.Find("PlayerAudio").GetComponent<Swoosh>();
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
        dyn.Stop();
        if (!dyn.isPlaying) {
            dyn.PlayOneShot(staticChirp);
        }
    }
}
