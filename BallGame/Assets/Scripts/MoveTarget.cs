using UnityEngine;
using System.Collections;

public class MoveTarget : MonoBehaviour {

    public int posCounter;

    public int increaseScore;
    int score;

    public GameObject targetSmall, targetLarge;
    public Vector3[] targetPos = new Vector3[6];

    public int currentTarget;
    public int[] missedTargetCount = new int[6];

    // Use this for initialization
    void Start () {
        MoveTargetOnArray();
        score = 0;
        currentTarget = 0;
    }


    void MoveTargetOnArray() // Sets positions target is to be moved to
    {
        posCounter = -1;
        targetSmall = GameObject.Find("Small Circle");
        targetSmall.transform.position = new Vector3(10f, 0.05f, 10f);
        targetLarge = GameObject.Find("Large Object");
        targetLarge.transform.position = new Vector3(10f, 0.05f, 10f);
        targetPos[0] = new Vector3(10f, 0.05f, 10f);
        targetPos[1] = new Vector3(-10f, 0.05f, -10f);
        targetPos[2] = new Vector3(30f, 0.05f, 30f);
        targetPos[3] = new Vector3(40f, 0.05f, 40f);
        targetPos[4] = new Vector3(50f, 0.05f, 50f);
        targetPos[5] = new Vector3(60f, 0.05f, 60f);
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
        targetLarge.transform.position = targetPos[posCounter];
        targetSmall.transform.position = targetPos[posCounter];
        print("Score is: " + score);

    }
}
