using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patroling : MonoBehaviour
{
    private Animator anim;

    [SerializeField]
    public float speed = 2f;
    public float runSpeed = 2.5f;

    //public bool isChasing;
    public Transform target;
    public float minX;
    public float maxX;
    public float minY;
    public float maxY;
    public float startWaitTime;
    public bool isMoving;
    public bool isChasing;


    // Start is called before the first frame update
    void Start()
    {
        target.position = new Vector2(Random.Range(minX, maxX), Random.Range(minY, maxY));
        anim = GetComponent<Animator>();
        bool isMoving = false;
    }

    // Update is called once per frame
    void Update()
    {
        anim.SetBool("is_walking", isMoving);
        ChooseAnimation(transform, target, anim);

        if (Vector2.Distance(transform.position, target.position) < 0.2f)
        {
            isMoving = false;
            target.position = new Vector2(Random.Range(minX, maxX), Random.Range(minY, maxY));
        }
        else
        {
            transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
            isMoving = true;
        }

        if (isChasing)
        {
            target.position = GameObject.FindGameObjectWithTag("Player").transform.position;
            transform.position = Vector2.MoveTowards(transform.position, target.position, runSpeed * Time.deltaTime);
            isMoving = true;
        }
        changeZ();        
    }

    private void changeZ()
    {
    
        float myX = transform.position.x;
        float myY = transform.position.y;
        float myZ = transform.position.z;

        if (target.position.y > myY)
        {
            myZ = (float)-2.1;
        }
        else
        {
            myZ = (float)-1.9;
        }

        transform.position = new Vector3(myX, myY, myZ);
    
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            
            //target.position = collision.transform.position;
            //transform.position = Vector2.MoveTowards(transform.position, target.position, runSpeed * Time.deltaTime);
            isChasing = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            target.position = new Vector2(Random.Range(minX, maxX), Random.Range(minY, maxY));
            isChasing = false;
        }
    }

    public void ChooseAnimation(Transform currentPoint, Transform destinationPoint, Animator animator)
    {
        var currY = currentPoint.position.y;
        var currX = currentPoint.position.x;
        var destY = destinationPoint.position.y;
        var destX = destinationPoint.position.x;

        var deltaX = destX - currX;
        var deltaY = destY - currY;

        var inputX = 0;
        var inputY = 0;
        if (deltaX > 0) { inputX = 1; }
        if (deltaY > 0) { inputY = 1; }
        if (deltaX < 0) { inputX = -1; }
        if (deltaY < 0) { inputY = -1; }


        animator.SetFloat("input_x", inputX);
        animator.SetFloat("input_y", inputY);

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "ConsumableProjectile" || collision.gameObject.tag == "ConsumableMelee")
        {
            Destroy(this.gameObject);
            Destroy(collision.gameObject);
        }
    }
}
