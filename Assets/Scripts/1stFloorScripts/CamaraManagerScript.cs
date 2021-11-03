using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamaraManagerScript : MonoBehaviour
{
    public static CamaraManagerScript camaraManager;

    // Start is called before the first frame update
    void Start()
    {
        if (camaraManager != null)
        {
            Destroy(gameObject);
        }
        else
        {
            camaraManager = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
