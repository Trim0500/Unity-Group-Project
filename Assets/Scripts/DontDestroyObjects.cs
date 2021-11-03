using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroyObjects : MonoBehaviour
{
    public static DontDestroyObjects dontDestroy;

    // Start is called before the first frame update
    void Start()
    {
        if (dontDestroy != null)
        {
            Destroy(gameObject);
        }
        else
        {
            dontDestroy = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
