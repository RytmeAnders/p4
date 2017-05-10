using UnityEngine;
using System;
using System.Collections;
using System.IO.Ports;
using System.Text.RegularExpressions;

public class ReadingArduino : MonoBehaviour {

    SerialPort stream; // Sets streaming port arduino communicates through


    string str;
    string[] accData = new string[3];
    public float acceleration, accHigh;
    public float orientation, state, state1;
    
	// Use this for initialization
	void Start () {
        string[] ports = SerialPort.GetPortNames();
        for (int i = 0; i < ports.Length; i++)
        {
            Debug.Log(ports[i]);
        }
        stream = new SerialPort("COM7", 9600);
        accHigh = 0;
        state1 = 0;
        //Opens stream
        stream.Open();
        stream.ReadTimeout = 100; // Sets timeout to 100 milliseconds, so it doesn't overload

        
    }

    // Update is called once per frame
    void Update () {

        if(stream.IsOpen)
        {
            try
            {
                // Reads data to string
                str = stream.ReadLine();
                accData = str.Split('_'); // Splits string
                acceleration = float.Parse(accData[0]); //Parsing the split string into floats
                orientation = float.Parse(accData[1]);
                state = float.Parse(accData[2]);
                if (acceleration > accHigh)
                {
                    accHigh = acceleration;
                    //print(accHigh);
                }
                
            }
            catch (TimeoutException){
            }
        }
	}
}
