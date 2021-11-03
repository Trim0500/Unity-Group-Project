using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseBehaviour : MonoBehaviour
{
    [SerializeField]
    private GameObject pauseMenuCanvas;
    [SerializeField]
    private GameObject optionsMenuCanvas;
    [SerializeField]
    private GameObject controlsMenuCanvas;
    public bool gamePaused = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) //If statement to check if the escape key was pressed once
        { 
            if (!gamePaused)
            {
                Pause();
            }
            else
            {
                Resume();
            }
        }
    }

    public void Pause()
    {
        Time.timeScale = 0f; //timeScale causes the game to freeze if set to 0
        pauseMenuCanvas.SetActive(true); //Display the canvas
        gamePaused = true; //Set the boolean field to true
    }

    public void Resume()
    {
        pauseMenuCanvas.SetActive(false);
        Time.timeScale = 1f;
        gamePaused = false;
    }

    public void ShowOptions()
    {
        pauseMenuCanvas.SetActive(false);
        optionsMenuCanvas.SetActive(true);
    }

    public void ShowControls()
    {
        pauseMenuCanvas.SetActive(false);
        controlsMenuCanvas.SetActive(true);
    }

    public void Quit()
    {
        if (Application.isPlaying && !Application.isEditor)
        {
            Application.Quit();
        }
        #if false //To use it in the editor, set to true
        else
        {
            UnityEditor.EditorApplication.isPlaying = false;
        }
        #endif
    }

    public void GoBack(GameObject currentMenu)
    {
        currentMenu = GameObject.FindGameObjectWithTag("SubMenu");
        currentMenu.SetActive(false);
        pauseMenuCanvas.SetActive(true);
    }

    public void Restart()
    {
        SceneManager.LoadScene("Floor1");
    }
}
