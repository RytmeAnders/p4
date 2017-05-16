using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Swoosh : MonoBehaviour
{
    //TODO Removed orientationNew, using just ard.orientation, should work

    public bool dynamicSound;

    //---- Parameters inside Unity
    [Range(0f, 20f)]
    public float staticThreshold;          //Threshold determining when the static sample will play (8-9 seems good)
    [Range(0, 2000)]
    public int staticFreq;                  //The frequency cut off for the static sample
    [Range(-1f, 1f)]
    public float offset;                   //offset slider with range -1:1 (range defined above)
    public int lowCut, scalar;
    //----------------------------

    float orientationOld, orientationDiff, dynamicDiff;     //Orientation values to measure a difference over time
    float accelerationOld, accelerationDiff;                //Acceleration values from GY-85

    System.Random rand = new System.Random();               //A class with a method for generating random values
    AudioLowPassFilter lowPassFilter;
    PlayerControls pc;
    ReadingArduino ard;
    AudioSource myAudio;
    Staticsound ST;

    void OnAudioFilterRead (float[] data, int channels)
    {                //White noise generation
        for (int i = 0; i < data.Length; i++)
        {
            data[i] = (float)(rand.NextDouble() * 2.0 - 1.0 + offset);  //Fills float array with random floats -1:1
        }
    }

    void Start()
    {
        ST = GameObject.Find("PlayerStatic").GetComponent<Staticsound>();
        pc = GameObject.Find("Player").GetComponent<PlayerControls>(); //Object of the ReadingArduino script
        ard = GameObject.Find("Player").GetComponent<ReadingArduino>();
        lowPassFilter = GetComponent<AudioLowPassFilter>();             //Object of the LowPassFilter component
        myAudio = GetComponent<AudioSource>();                          //Object of the AudioSource

        orientationOld = pc.newOrientation;                               //Initial orientation value
        accelerationOld = ard.acceleration;                             //Initial acceleration value
    }

    void Update()
    {
        dynamicDiff = Mathf.Max(CalculateOrientation(),CalculateAcceleration());        //Find the biggest change

        if (dynamicSound) {
            ST.GetComponent<AudioReverbFilter>().enabled = true;
            //print("Diff Ori: " + orientationDiff + " Raw Ori: " + pc.newOrientation + " | Diff Acc: " + accelerationDiff + " Raw Acc: " + ard.acceleration);
            lowPassFilter.cutoffFrequency = lowCut + dynamicDiff * scalar;              //LPF freq changing based on change
        }
        else { //Static sound
            ST.GetComponent<AudioReverbFilter>().enabled = false;

            if (dynamicDiff > staticThreshold) {        //If difference is > threshold, play a static sound sample
                print("Sound activated!");
                ST.playSwoosh();
            }
            else {
                print("Sound Inactive!");
                lowPassFilter.cutoffFrequency = 0; //If no difference over time, filter out all freqs (play no sound)
            }
        }
    }

    float CalculateOrientation()
    {
        //Reading the difference in orientation over time
        orientationDiff = Mathf.Abs(pc.newOrientation - orientationOld);
        orientationOld = pc.newOrientation;

        return orientationDiff;
    }
    float CalculateAcceleration()
    {
        //Reading the difference in acceleration over time
        accelerationDiff = Mathf.Abs(ard.acceleration - accelerationOld);
        accelerationOld = ard.acceleration;

        return accelerationDiff;
    }
}
