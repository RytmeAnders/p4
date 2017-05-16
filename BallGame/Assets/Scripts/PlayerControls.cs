using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls : MonoBehaviour {

    public GameObject ballInstance;
    GameObject ballPhys, spawnPoint;
    Rigidbody rb;
    ReadingArduino arduino;
    Staticsound ST;
    Swoosh swoosh;

    public float newOrientation;
    int u, angle; //Initial Velocity u (Science notation) and angle

    // Use this for initialization
    void Start () {
        arduino = GetComponent<ReadingArduino>();
        spawnPoint = GameObject.Find("BallSpawnPoint");
        ST = GameObject.Find("PlayerStatic").GetComponent<Staticsound>();
        swoosh = GameObject.Find("PlayerAudio").GetComponent<Swoosh>();

        newOrientation = 0f;
        u = 10; // Initial velocity in m/s
        angle = 70; // Angle in degrees
    }

    // Update is called once per frame
    void Update () {
        if (arduino.state == 0 && arduino.state1 == 0)
        {
            RotatePlayer(arduino.orientation); // Calls for rotations based off orientation received from arduino
        }
        if (arduino.state == 1 && arduino.state1 == 0)
        {
            arduino.state1 = 1;
        }
        if (arduino.state == 1 && arduino.state1 == 1)
        {
            if (arduino.acceleration > arduino.accHigh)
            {
                arduino.accHigh = arduino.acceleration;
            }
        }
        if (arduino.state == 0 && arduino.state1 == 1)
        {
            LaunchBall(arduino.accHigh * 5f);
        }
    }

    public void RotatePlayer(float yOrientation)
    {
        newOrientation = newOrientation + (-1*yOrientation/9f);
        transform.localEulerAngles = new Vector3(0, newOrientation, 0); // Rotate player
    }

    void LaunchBall(float acceleration)
    {
        if (!swoosh.dynamicSound) { //Static sound, play chirp
            ST.playChirp();
        }
        arduino.state1 = 0;
        ballPhys = Instantiate(ballInstance, spawnPoint.transform.position, transform.rotation);
        rb = ballPhys.GetComponent<Rigidbody>();
        Vector3 direction = spawnPoint.transform.forward;
        direction.y = 0;
        direction.Normalize();
        direction.y = Mathf.Sin(angle * Mathf.Deg2Rad);
        rb.AddForce(direction.normalized * (u + acceleration));
        arduino.accHigh = 0;
    }
}
