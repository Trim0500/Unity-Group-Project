﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadSecondFloor : MonoBehaviour
{
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
        if (collision.gameObject.tag == "Player")
        {
            if (camera == null || player == null)
            {
                camera = GameObject.FindGameObjectWithTag("MainCamera");
                player = GameObject.FindGameObjectWithTag("Player");
            }

            player = GameObject.FindGameObjectWithTag("Player");
            player.GetComponent<Transform>().position = new Vector3(-17, -33, -2);
            camera = GameObject.FindGameObjectWithTag("MainCamera");
            camera.GetComponent<Transform>().position = new Vector3(-28, -35, -10);
            SceneManager.LoadScene("UpperFloor");
        }
    }
}
