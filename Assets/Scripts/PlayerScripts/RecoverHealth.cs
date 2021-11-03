using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecoverHealth : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Enemy")
        {
            return;
        }
        else if(collision.gameObject.tag == "Player") 
        {
            if (gameObject.tag == "FullRegen")
            {
                PlayerHealth1.RecoverHealth(2);
                PlayerHealth1.UpdateHealthHUD(PlayerHealth1.currentHealth);

                Destroy(this.gameObject);
            }
            else if (gameObject.tag == "HalfRegen")
            {
                PlayerHealth1.RecoverHealth(1);
                PlayerHealth1.UpdateHealthHUD(PlayerHealth1.currentHealth);

                Destroy(this.gameObject);
            }
        }
    }
}
