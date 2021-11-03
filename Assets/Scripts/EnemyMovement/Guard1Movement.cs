using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Guard1Movement : MonoBehaviour
{
    private Animator anim;

    private float speed = 2f;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float inputX = Input.GetAxisRaw("Horizontal");
        float inputY = Input.GetAxisRaw("Vertical");

        bool isWalking = (Mathf.Abs(inputX) + Mathf.Abs(inputY)) > 0;

        anim.SetBool("is_walking", isWalking);

        if (isWalking)
        {
            anim.SetFloat("input_x", inputX);
            anim.SetFloat("input_y", inputY);

            if (Input.GetKey(KeyCode.LeftShift))
            {
                transform.position += new Vector3(inputX, inputY, 0).normalized * Time.deltaTime * speed;
            }
            else
            {
                transform.position += new Vector3(inputX, inputY, 0).normalized * Time.deltaTime;
            }

        }

    }
}
