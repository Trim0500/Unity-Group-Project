using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class OpenGate : MonoBehaviour
{
    private bool opened;
    private GameObject gateLeft;
    private GameObject gateRight;

    private float leftPosX;
    private float leftPosY;
    private float leftPosZ;
    private float rightPosX;
    private float rightPosY;
    private float rightPosZ;

    private Vector3 leftPos;
    private Vector3 newLeftPos;
    private Vector3 rightPos;
    private Vector3 newRightPos;

    void Start()
    {
        opened = false;
        gateLeft = GameObject.FindWithTag("GateLeft");
        gateRight = GameObject.FindWithTag("GateRight");

        leftPosX = gateLeft.transform.position.x;
        leftPosY = gateLeft.transform.position.y;
        leftPosZ = gateLeft.transform.position.z;

        rightPosX = gateRight.transform.position.x;
        rightPosY = gateRight.transform.position.y;
        rightPosZ = gateRight.transform.position.z;

        leftPos = new Vector3(leftPosX, leftPosY, leftPosZ);
        newLeftPos = new Vector3(leftPosX - 1, leftPosY, leftPosZ);

        rightPos = new Vector3(rightPosX, rightPosY, rightPosZ);
        newRightPos = new Vector3(rightPosX + 1, rightPosY, rightPosZ);
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (Input.GetKeyDown(KeyCode.O))
            {
                if (opened)
                {
                    gateLeft.transform.position = leftPos;
                    gateRight.transform.position = rightPos;
                    opened = false;
                }
                else
                {
                    gateLeft.transform.position = newLeftPos;
                    gateRight.transform.position = newRightPos;
                    opened = true;
                }
            }
        }
    }

}
