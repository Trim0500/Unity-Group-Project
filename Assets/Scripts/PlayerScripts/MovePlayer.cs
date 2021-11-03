using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayer : MonoBehaviour
{
    public float spd = 2f;
    private Vector3 totalMovement = Vector3.zero;
    private Rigidbody2D player;

    // Start is called before the first frame update
    void Start()
    {
        player = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        totalMovement = new Vector3(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"), 0).normalized;
        transform.position = Vector2.MoveTowards(transform.position, transform.position + totalMovement, spd * Time.deltaTime);
    }
}
