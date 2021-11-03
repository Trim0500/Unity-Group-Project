using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeExitRoomsCamera : MonoBehaviour
{
    public GameObject transitionBlock;
    public GameObject camera;
    public GameObject player;
    private Vector3[] roomPositions;
    private Vector3[] playerPosistions;
    public static bool isTransitioning = false;

    private void Awake()
    {
        camera = GameObject.FindGameObjectWithTag("MainCamera");
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Start is called before the first frame update
    void Start()
    {
        roomPositions = new Vector3[3];
        roomPositions[0] = new Vector3(-28, 0, -10);
        roomPositions[1] = new Vector3(-56, 0, -10);
        roomPositions[2] = new Vector3(-56, 16, -10);

        playerPosistions = new Vector3[3];
        playerPosistions[0] = new Vector3(-39, -1, -2);
        playerPosistions[1] = new Vector3(-45, -1, -2);
        playerPosistions[2] = new Vector3(-56, 11, -2);

        camera = GameObject.FindGameObjectWithTag("MainCamera");
        player = GameObject.FindGameObjectWithTag("Player");
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
        if (camera == null || player == null)
        {
            camera = GameObject.FindGameObjectWithTag("MainCamera");
            player = GameObject.FindGameObjectWithTag("Player");
        }
        Debug.Log("The camera object is: " + camera);
        Debug.Log("The player object is: " + player);

        Vector3 currentPosition = camera.GetComponent<Transform>().position;

        if(!isTransitioning && gameObject.GetComponent<ChangeExitRoomsCamera>().enabled)
        {
            switch(transitionBlock.name)
            {
                case "backRoom1":
                case "toNextRoom2":
                    if(currentPosition == roomPositions[1])
                    {
                        break;
                    }
                    player.GetComponent<Transform>().position = playerPosistions[1];
                    StartCoroutine(TransitionCamera(roomPositions[1], .75f)); 
                    break;
                case "toNextRoom1":
                    if (currentPosition == roomPositions[0])
                    {
                        break;
                    }
                    player.GetComponent<Transform>().position = playerPosistions[0];
                    StartCoroutine(TransitionCamera(roomPositions[0], .75f));
                    break;
                case "backRoom2":
                    if (currentPosition == roomPositions[2])
                    {
                        break;
                    }
                    player.GetComponent<Transform>().position = playerPosistions[2];
                    StartCoroutine(TransitionCamera(roomPositions[2], .75f));
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

        Debug.Log("The new camera position is: " + camera.GetComponent<Transform>().position);

        isTransitioning = false;
    }
}
