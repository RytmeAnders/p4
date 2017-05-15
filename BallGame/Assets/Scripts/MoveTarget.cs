using UnityEngine;
using System.Collections;

public class MoveTarget : MonoBehaviour {

    public int posCounter;

    public int increaseScore;
    int score;

    public GameObject targets;
    public Vector3[] targetPos = new Vector3[6];

    public int currentTarget;
    public int[] missedTargetCount = new int[6];

    Staticsound ST;
    Swoosh swoosh;

    // Use this for initialization
    void Start () {
        MoveTargetOnArray();
        score = 0;
        currentTarget = 0;
        ST = GameObject.Find("PlayerStatic").GetComponent<Staticsound>();
        swoosh = GameObject.Find("PlayerAudio").GetComponent<Swoosh>();
    }


    void MoveTargetOnArray() // Sets positions target is to be moved to
    {
        posCounter = -1;
        targets = GameObject.Find("Targets");
        targets.transform.position = new Vector3(10f, 0.05f, 10f);
        targetPos[0] = new Vector3(15f, 0.05f, -23f);
        targetPos[1] = new Vector3(-40f, 0.05f, 35f);
        targetPos[2] = new Vector3(-17f, 0.05f, -32f);
        targetPos[3] = new Vector3(-40f, 0.05f, 0f);
        targetPos[4] = new Vector3(-30f, 0.05f, -30f);
        targetPos[5] = new Vector3(6f, 0.05f, 23f);
    }

    void OnCollisionEnter(Collision collision) // Moves target when hit
    {
        score += increaseScore;
        posCounter++;
        currentTarget++;
        if (posCounter >= 6)
        {
            posCounter = 0;
        }
        targets.transform.position = targetPos[posCounter];
        print("Score is: " + score);

        //Play the score sound, pitch affected by increaseScore
        if (swoosh.dynamicSound) {
            ST.aud.Stop();
            ST.aud.pitch = .3f + ((increaseScore * 1.5f) / 10);
            ST.playScore();
        }

    }
}
