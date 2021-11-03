using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class ResizeScale : MonoBehaviour
{
    public GameObject titleText;
    public GameObject synopsisText;
    public GameObject startButton;
    public float duration = 10f;
    public float durationS = 10f;
    private Vector3 scaleLimit;
    private bool resizeFinished = false;
    private Vector3 synopsisLimit;

    // Start is called before the first frame update
    void Start()
    {
        scaleLimit = new Vector3(0.0f, 0.0f, 0.0f);
        synopsisLimit = new Vector3(0.0f, 966.0f, 0.0f);

        StartCoroutine(ResizeScaleToZero(scaleLimit, duration));

        //StartCoroutine(ScrollText(synopsisLimit, durationS));
    }

    private void Update()
    {
        if(resizeFinished)
        {
            synopsisText.SetActive(true);
            startButton.SetActive(true);
        }
    }

    /*private IEnumerator ScrollText(Vector3 targetPosition, float duration)
    {
        yield return new WaitForSeconds(7f);

        float time = 0;
        Vector3 startPosition = synopsisText.GetComponent<Transform>().position;
        Debug.Log("The start position of the text is: " + startPosition);
        Debug.Log("The limit of the scrolling is: " + targetPosition);

        if (resizeFinished)
        {
            while (time < duration)
            {
                synopsisText.GetComponent<Transform>().position = Vector3.Lerp(startPosition, targetPosition, time / duration);
                time += Time.deltaTime;
                yield return null;
            }
        }

        startButton.SetActive(true);
    }*/

    private IEnumerator ResizeScaleToZero(Vector3 targetPosition, float duration)
    {
        float time = 0;
        Vector3 startPosition = titleText.GetComponent<Transform>().localScale;

        while (time < duration)
        {
            titleText.GetComponent<Transform>().localScale = Vector3.Lerp(startPosition, targetPosition, time / duration);
            time += Time.deltaTime;
            yield return null;
        }

        resizeFinished = true;
    }

    public void startGame()
    {
        SceneManager.LoadScene("Floor1");
    }
}
