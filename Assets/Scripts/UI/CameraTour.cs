using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTour : MonoBehaviour
{
    public GameObject camera;

    // Start is called before the first frame update
    void Start()
    {
        camera = GameObject.FindGameObjectWithTag("MainCamera");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            camera.GetComponent<Transform>().position = new Vector3(28, 0, -10);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            camera.GetComponent<Transform>().position = new Vector3(0, 16, -10);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            camera.GetComponent<Transform>().position = new Vector3(28, 16, -10);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            camera.GetComponent<Transform>().position = new Vector3(0, -16, -10);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            camera.GetComponent<Transform>().position = new Vector3(0, -32, -10);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha6))
        {
            camera.GetComponent<Transform>().position = new Vector3(28, -32, -10);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha0))
        {
            camera.GetComponent<Transform>().position = new Vector3(0, 0, -10);
        }
    }
}
