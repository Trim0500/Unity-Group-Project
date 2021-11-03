using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AnimationController : MonoBehaviour
{
    private Animator anim;
    public float force = 15;
    public int health;
    private bool isHit;
    private bool isWalking = true;
    private bool isRunning = true;

    public ForceMode forceMode = ForceMode.Impulse;
    AudioSource aud;
    Color color;

    [SerializeField]
    private float runSpeed = 4f;
    private float walkSpeed = 3f;
    void Start()
    {
        anim = GetComponent<Animator>();
        aud = GetComponent<AudioSource>();
        color = gameObject.GetComponent<SpriteRenderer>().material.color;
    }

    // Update is called once per frame
    void Update()
    {
        float inputX = Input.GetAxisRaw("Horizontal");
        float inputY = Input.GetAxisRaw("Vertical");

        bool isMoving = (Mathf.Abs(inputX) + Mathf.Abs(inputY)) > 0;

        anim.SetFloat("input_x", inputX);
        anim.SetFloat("input_y", inputY);

        if(isMoving) { 
            if (Input.GetKey(KeyCode.LeftShift))
            {
                anim.SetBool("is_walking", false);
                anim.SetBool("is_running", true);
                transform.position += new Vector3(inputX, inputY, 0).normalized * Time.deltaTime * runSpeed;
            }
            else
            {
                anim.SetBool("is_running", false);
                anim.SetBool("is_walking", true);
                transform.position += new Vector3(inputX, inputY, 0).normalized * Time.deltaTime * walkSpeed;
            }          
        }
        else
        {
            anim.SetBool("is_running", false);
            anim.SetBool("is_walking", false);
        }

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            //isWalking = false;
            //collision.gameObject.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Kinematic;
            Debug.Log("Collision");
            PlayerHealth1.currentHealth -= 2;
            //Check for death 
            if (PlayerHealth1.currentHealth <= 0)
            {
                //gameObject.SetActive(false);
                Debug.Log("Object to destroy is: " + GameObject.Find("DontDestroyOnLoad"));
                Destroy(GameObject.Find("Player"));
                Destroy(GameObject.Find("Main Camera"));
                Destroy(GameObject.Find("HUD"));
                Destroy(GameObject.Find("AudioManager"));
                SceneManager.LoadScene("GameOver");
            }
            else
            {
                float enemyX = collision.gameObject.transform.position.x;
                float enemyY = collision.gameObject.transform.position.y;

                float playerX = transform.position.x;
                float playerY = transform.position.y;

                var dir = new Vector2(playerX - enemyX, playerY - enemyY);

                GetComponent<Rigidbody2D>().AddForce(dir * force, (ForceMode2D)forceMode);

            anim.SetBool("is_running", false);
            anim.SetBool("is_moving", false);
            anim.SetBool("is_hit", true);

                StartCoroutine(SwitchColor(this.gameObject.GetComponent<SpriteRenderer>(), Color.red));

                PlayerHealth1.UpdateHealthHUD(PlayerHealth1.currentHealth);
            }
        }
        System.Collections.IEnumerator SwitchColor(Renderer renderer, Color newColor)
        {
            aud.Play();
            renderer.material.color = newColor;

            yield return new WaitForSeconds(.2f);

            anim.SetBool("is_hit", false);
            renderer.material.color = color;
        }
    }
}
