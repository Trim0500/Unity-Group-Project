using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGame : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(EndGameApp());
    }

    private IEnumerator EndGameApp()
    {
        yield return new WaitForSeconds(5f);

        Application.Quit();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
