using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    Rigidbody rb;
    ReadingArduino arduino;

    int u, angle; //Initial Velocity u (Science notation) and angle

    // Use this for initialization
    void Start () {
        rb = GameObject.Find("Ball").GetComponent<Rigidbody>(); // Getting the rigidbody component of the ball
        arduino = GetComponent<ReadingArduino>();

        u = 100; // Initial velocity in m/s
        angle = 30; // Angle in degrees
    }

    // Update is called once per frame
    void Update () {
        RotatePlayer(arduino.orientation); // Calls for rotations based off orientation received from arduino
        if (arduino.state == 1 && arduino.state1 == 0)
        {
            arduino.state1 = 1;
        }
        if (arduino.state == 0 && arduino.state1 == 1)
        {
            LaunchBall(arduino.accHigh * 100f);
        }
    }

    public void RotatePlayer(float yOrientation)
    {
        transform.localEulerAngles = new Vector3(0, yOrientation, 0); // Rotate player
    }

    void LaunchBall(float acceleration)
    {
        Vector3 direction = Quaternion.AngleAxis(angle, Vector3.forward) * Vector3.right;
        rb.AddForce(direction * (u + (acceleration * Time.deltaTime)));
        print(direction * (u + (acceleration * Time.deltaTime)));
        rb.useGravity = true;
        arduino.state1 = 0;
        arduino.accHigh = 0;
    }
}
