using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCamera : MonoBehaviour
{
    public float upLimit = 0f; // Limits of movement horizontally
    public float bottomLimit = -32f;
    public float speed = 5.0f; // Speed is adjustable via the inspector
    private int direction = 1;

    // Start is called before the first frame update
    void Start()
    {
        /*transform.Translate(new Vector3(3, 0, 0));

        transform.Translate(0, 1 * Time.deltaTime, 0, Space.World);*/
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y > upLimit)
        {
            direction = -1;
        }
        else if (transform.position.y < bottomLimit)
        {
            direction = 1;
        }

        transform.Translate(Vector2.up * direction * speed * Time.deltaTime); //Makes an object bounce left & right
    }
}
