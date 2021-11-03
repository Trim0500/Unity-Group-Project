using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeBasementCamera : MonoBehaviour
{
    public GameObject transitionBlock;
    public GameObject camera;
    private GameObject player;
    private Vector3[] roomPositions;
    private Vector3[] playerPositions;
    public static bool isTransitioning = false;

    // Start is called before the first frame update
    void Start()
    {
        roomPositions = new Vector3[2];
        roomPositions[0] = new Vector3(28, 32, -10);
        roomPositions[1] = new Vector3(56, 32, -10);

        playerPositions = new Vector3[2];
        playerPositions[0] = new Vector3(16.5f, 36.5f, -2);
        playerPositions[1] = new Vector3(67.5f, 36.5f, -2);

        camera = GameObject.Find("Main Camera");
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(Input.GetKey(KeyCode.O))
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
                    case "secretPath":
                        if (currentPosition != roomPositions[0])
                        {
                            break;
                        }
                        StartCoroutine(TransitionCamera(roomPositions[1], .75f));
                        player.GetComponent<Transform>().position = playerPositions[1];
                        break;
                    case "secretPath2":
                        if (currentPosition != roomPositions[1])
                        {
                            break;
                        }
                        StartCoroutine(TransitionCamera(roomPositions[0], .75f));
                        player.GetComponent<Transform>().position = playerPositions[0];
                        break;
                }
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
