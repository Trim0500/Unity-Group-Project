using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScenes : MonoBehaviour
{
    public Object scene;
    public Object currentScene;
    public GameObject player;
    public GameObject camera;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (camera == null || player == null)
        {
            camera = GameObject.FindGameObjectWithTag("MainCamera");
            player = GameObject.FindGameObjectWithTag("Player");
        }
        //Debug.Log(camera);
        //Debug.Log(player);

        if (currentScene.name == "Floor1")
        {
            switch (scene.name)
            {
                case "BasementFloor":
                    player = GameObject.FindGameObjectWithTag("Player");
                    player.GetComponent<Transform>().position = new Vector3(38, 27, -2);
                    camera = GameObject.FindGameObjectWithTag("MainCamera");
                    camera.GetComponent<Transform>().position = new Vector3(28, 32, -10);
                    SceneManager.LoadScene("BasementFloor");
                    break;
                case "ServerRoom":
                    player = GameObject.FindGameObjectWithTag("Player");
                    player.GetComponent<Transform>().position = new Vector3(45, -35, -2);
                    camera = GameObject.FindGameObjectWithTag("MainCamera");
                    camera.GetComponent<Transform>().position = new Vector3(56, -32, -10);
                    SceneManager.LoadScene(scene.name);
                    break;
                case "UpperFloor":
                    player = GameObject.FindGameObjectWithTag("Player");
                    player.GetComponent<Transform>().position = new Vector3(-17, -33, -2);
                    camera = GameObject.FindGameObjectWithTag("MainCamera");
                    camera.GetComponent<Transform>().position = new Vector3(-28, -35, -10);
                    Debug.Log("The camera has now been placed to: " + camera.GetComponent<Transform>().position);
                    SceneManager.LoadScene(scene.name);
                    break;
                /*case "ExitRooms":
                    player = GameObject.FindGameObjectWithTag("Player");
                    player.GetComponent<Transform>().position = new Vector3(-17, -1, 0);
                    camera = GameObject.FindGameObjectWithTag("MainCamera");
                    camera.GetComponent<Transform>().position = new Vector3(-28, 0, -10);
                    SceneManager.LoadScene(scene.name);
                    break;*/
            }
        }
        else if (currentScene.name == "BasementFloor")
        {
            player = GameObject.FindGameObjectWithTag("Player");
            player.GetComponent<Transform>().position = new Vector3(38, 21, -2);
            camera = GameObject.FindGameObjectWithTag("MainCamera");
            camera.GetComponent<Transform>().position = new Vector3(28, 16, -10);
            SceneManager.LoadScene(scene.name);
        }
        else if (currentScene.name == "ServerRoom")
        {
            player = GameObject.FindGameObjectWithTag("Player");
            player.GetComponent<Transform>().position = new Vector3(39, -35, -2);
            camera = GameObject.FindGameObjectWithTag("MainCamera");
            camera.GetComponent<Transform>().position = new Vector3(28, -32, -10);
            SceneManager.LoadScene(scene.name);
        }
        else if (currentScene.name == "UpperFloor")
        {
            player = GameObject.FindGameObjectWithTag("Player");
            player.GetComponent<Transform>().position = new Vector3(-11, -35, -2);
            camera = GameObject.FindGameObjectWithTag("MainCamera");
            camera.GetComponent<Transform>().position = new Vector3(0, -32, -10);
            SceneManager.LoadScene(scene.name);
        }
        else if(currentScene.name == "ExitRooms")
        {
            player = GameObject.FindGameObjectWithTag("Player");
            player.GetComponent<Transform>().position = new Vector3(-10, -1, -2);
            camera = GameObject.FindGameObjectWithTag("MainCamera");
            camera.GetComponent<Transform>().position = new Vector3(0, 0, -10);
            SceneManager.LoadScene(scene.name);
        }

        //Debug.Log(camera);

        /*switch (scene.name)
        {
            case "BasementFloor":
                player = GameObject.FindGameObjectWithTag("Player");
                player.GetComponent<Transform>().position = new Vector3(38, 27, 0);
                SceneManager.LoadScene(scene.name);
                break;
            case "ServerRoom":
                player = GameObject.FindGameObjectWithTag("Player");
                player.GetComponent<Transform>().position = new Vector3(45, -35, 0);
                SceneManager.LoadScene(scene.name);
                break;
            case "UpperFloor":
                player = GameObject.FindGameObjectWithTag("Player");
                player.GetComponent<Transform>().position = new Vector3(-17, -33, 0);
                SceneManager.LoadScene(scene.name);
                break;
            case "Floor1":
                if (currentScene.name == "BasmentFloor")
                {

                }
        }*/
    }
}
