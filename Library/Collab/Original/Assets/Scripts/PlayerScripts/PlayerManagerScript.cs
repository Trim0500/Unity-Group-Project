using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManagerScript : MonoBehaviour
{
    //This is Tristan's comment

    public static PlayerManagerScript playerManager;

    // Start is called before the first frame update
    void Start()
    {
        if (playerManager != null)
        {
            Destroy(gameObject);
        }
        else
        {
            playerManager = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
