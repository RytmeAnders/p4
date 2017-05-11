using UnityEngine;
using System;

public class BallChirp : MonoBehaviour {
    //TODO frequency is based on acceleration
    public double frequency;
    public double gain;
    public AudioClip impact;

    private double increment;
    private double phase;
    private double sampling_frequency = 48000;
    private bool ballLanded;                    //Determining when the ball hits the ground

    Swoosh swoosh;                              //swoosh script for accessing the Dynamic Sound bool, so its global
    AudioSource myAudio;
    ReadingArduino ard;

    //TODO decayRate is based on distance
    private float decayRate;                    //How fast the chirp frequency will drop

    void OnAudioFilterRead(float[] data, int channels) {
        // update increment in case frequency has changed
        increment = frequency * 2 * Math.PI / sampling_frequency;
        for (var i = 0; i < data.Length; i = i + channels)
        {
            phase = phase + increment;
            // this is where we copy audio data to make them “available” to Unity
            data[i] = (float)(gain * Math.Sin(phase));
            // if we have stereo, we copy the mono data to each channel
            if (channels == 2) data[i + 1] = data[i];
            if (phase > 2 * Math.PI) phase = 0;
        }
    }

    void Start() {
        swoosh = GameObject.Find("PlayerAudio").GetComponent<Swoosh>();
        ard = GameObject.Find("Player").GetComponent<ReadingArduino>();
        myAudio = GetComponent<AudioSource>();
    }

    void Update () {
        if (frequency <= 100)
        {
            frequency = 0;
        }
        else
        {
            frequency -= 4;
        }
    }
}