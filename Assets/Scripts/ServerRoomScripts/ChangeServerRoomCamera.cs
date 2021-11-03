using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeServerRoomCamera : MonoBehaviour
{
    public GameObject transitionBlock;
    public GameObject camera;
    private Vector3[] roomPositions;
    public static bool isTransitioning = false;

    // Start is called before the first frame update
    void Start()
    {
        roomPositions = new Vector3[3];
        roomPositions[0] = new Vector3(56, -32, -10);
        roomPositions[1] = new Vector3(56, -16, -10);
        roomPositions[2] = new Vector3(56, 0, -10);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag != "Player")
        {
            return;
        }
        if (camera == null)
        {
            camera = GameObject.Find("Main Camera");
        }
        Debug.Log("The camera object is: " + camera);

        Vector3 currentPosition = camera.GetComponent<Transform>().position;

        if (!isTransitioning)
        {
            Debug.Log("Hit the transition block " + transitionBlock.name);
            Debug.Log("The current camera position is: " + currentPosition);
            switch (transitionBlock.name)
            {
                case "toNextSection":
                case "goBackSection":
                    if (currentPosition == roomPositions[1])
                    {
                        break;
                    }
                    StartCoroutine(TransitionCamera(roomPositions[1], 1.5f));
                    break;
                case "toNextSection2":
                    if (currentPosition == roomPositions[2])
                    {
                        break;
                    }
                    StartCoroutine(TransitionCamera(roomPositions[2], 1.5f));
                    break;
                case "goBackSection2":
                    if (currentPosition == roomPositions[0])
                    {
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

        Debug.Log("The current camera position is: " + camera.GetComponent<Transform>().position);

        isTransitioning = false;
    }
}
