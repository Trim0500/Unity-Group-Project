using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeCameraPosition : MonoBehaviour
{
    public GameObject transitionBlock;
    public GameObject camera;
    private Vector3[] roomPositions;
    public static bool isTransitioning = false;

    // Start is called before the first frame update
    void Start()
    {
        roomPositions = new Vector3[7];
        roomPositions[0] = new Vector3(0, 0, -10);
        roomPositions[1] = new Vector3(0, 16, -10);
        roomPositions[2] = new Vector3(28, 16, -10);
        roomPositions[3] = new Vector3(0, -16, -10);
        roomPositions[4] = new Vector3(0, -32, -10);
        roomPositions[5] = new Vector3(28, -32, -10);
        roomPositions[6] = new Vector3(28, 0, -10);
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Vector3 currentPosition = camera.GetComponent<Transform>().position;

        if (!isTransitioning)
        {
            Debug.Log(collision.name);
            Debug.Log(transitionBlock.name);
            switch (transitionBlock.name)
            {
                case "toBasement1":
                case "backBasement":
                    //camera.GetComponent<Transform>().position = roomPositions[1];
                    if (currentPosition == roomPositions[1])
                    {
                        break;
                    }
                    StartCoroutine(TransitionCamera(roomPositions[1], 1.5f));
                    break;
                case "toBasement2":
                    //camera.GetComponent<Transform>().position = roomPositions[2];
                    if (currentPosition == roomPositions[2])
                    {
                        break;
                    }
                    StartCoroutine(TransitionCamera(roomPositions[2], 1.5f));
                    break;
                case "toSecondFloor1":
                case "backSecondFloor":
                    //camera.GetComponent<Transform>().position = roomPositions[3];
                    if (currentPosition == roomPositions[3])
                    {
                        break;
                    }
                    StartCoroutine(TransitionCamera(roomPositions[3], 1.5f));
                    break;
                case "toSecondFloor2":
                case "backServerRoom":
                    //camera.GetComponent<Transform>().position = roomPositions[4];
                    if (currentPosition == roomPositions[4])
                    {
                        break;
                    }
                    StartCoroutine(TransitionCamera(roomPositions[4], 1.5f));
                    break;
                case "toServerRoom1":
                    //camera.GetComponent<Transform>().position = roomPositions[5];
                    if (currentPosition == roomPositions[5])
                    {
                        break;
                    }
                    StartCoroutine(TransitionCamera(roomPositions[5], 1.5f));
                    break;
                case "toExtraRoom":
                    //camera.GetComponent<Transform>().position = roomPositions[6];
                    if (currentPosition == roomPositions[6])
                    {
                        break;
                    }
                    StartCoroutine(TransitionCamera(roomPositions[6], 1.5f));
                    break;
                case "toMainRoom1":
                case "toMainRoom2":
                case "toMainRoom3":
                    //camera.GetComponent<Transform>().position = roomPositions[0];
                    if (currentPosition == roomPositions[0]) {
                        break;
                    }
                    StartCoroutine(TransitionCamera(roomPositions[0], 1.5f));
                    break;
            }
        }
        
    }

    private IEnumerator TransitionCamera(Vector3 targetPosition, float duration)
    {
        isTransitioning = true;

        float time = 0;
        Vector3 startPotition = camera.GetComponent<Transform>().position;

        while (time < duration)
        {
            camera.GetComponent<Transform>().position = Vector3.Lerp(startPotition, targetPosition, time / duration);
            time += Time.deltaTime;
            yield return null;
        }
        camera.GetComponent<Transform>().position = targetPosition;

        isTransitioning = false;
    }
}
