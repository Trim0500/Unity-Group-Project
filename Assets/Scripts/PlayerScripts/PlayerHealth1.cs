using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth1 : MonoBehaviour
{
    private static int maxHealth;
    [HideInInspector]
    public static int currentHealth;
    private static GameObject[] healthHUDs;

    private void Start()
    {
        maxHealth = 12;
        currentHealth = 12;
        healthHUDs = GameObject.FindGameObjectsWithTag("HealthDisplay");

        UpdateHealthHUD(currentHealth); //For testing & debugging
        /*foreach(GameObject temp in healthHUDs)
        {
            temp.GetComponent<Image>().sprite = Resources.Load<Sprite>("full_heart");
        }*/

        /*Debug.Log("The player's max health is: " + maxHealth + " & their current health is: " + currentHealth);
        Debug.Log("The health image of heart 6 is: " + healthHUDs[5].GetComponent<Image>().sprite.name);*/
    }

    private void Update()
    {
        
    }

    public static void RecoverHealth(int regenValue)
    {
        //Debug.Log("The value of this health pickup is: " + regenValue);

        if(currentHealth == 11 && regenValue == 2)
        {
            regenValue = 1;

            currentHealth += regenValue;

            //Debug.Log("The player's health is now: " + currentHealth);
        }
        else if((currentHealth <= 10 && currentHealth < maxHealth && regenValue == 2) || (currentHealth <= 11 && currentHealth < maxHealth && regenValue == 1))
        {
            currentHealth += regenValue;

            //Debug.Log("The player's health is now: " + currentHealth);
        }
    }

    public static void UpdateHealthHUD(int currentHealth)
    {
        bool isEven = currentHealth % 2 == 0 ? true : false;

        //Debug.Log("Is the player's current health even?: " + isEven);

        switch(isEven)
        {
            case true:
                if(currentHealth == 12)
                {
                    foreach (GameObject temp in healthHUDs)
                    {
                        temp.GetComponent<Image>().sprite = Resources.Load<Sprite>("full_heart");
                    }
                }
                else if(currentHealth == 10) {
                    for (int i = 0; i < 5; i++)
                    {
                        healthHUDs[i].GetComponent<Image>().sprite = Resources.Load<Sprite>("full_heart");
                    }
                    healthHUDs[5].GetComponent<Image>().sprite = Resources.Load<Sprite>("empty_heart");
                }
                else if (currentHealth == 8)
                {
                    for (int i = 0; i < 4; i++)
                    {
                        healthHUDs[i].GetComponent<Image>().sprite = Resources.Load<Sprite>("full_heart");
                    }
                    for (int i = 4; i <= 5; i++)
                    {
                        healthHUDs[i].GetComponent<Image>().sprite = Resources.Load<Sprite>("empty_heart");
                    }
                }
                else if (currentHealth == 6)
                {
                    for (int i = 0; i < 3; i++)
                    {
                        healthHUDs[i].GetComponent<Image>().sprite = Resources.Load<Sprite>("full_heart");
                    }
                    for (int i = 3; i <= 5; i++)
                    {
                        healthHUDs[i].GetComponent<Image>().sprite = Resources.Load<Sprite>("empty_heart");
                    }
                }
                else if (currentHealth == 4)
                {
                    for (int i = 0; i < 2; i++)
                    {
                        healthHUDs[i].GetComponent<Image>().sprite = Resources.Load<Sprite>("full_heart");
                    }
                    for (int i = 2; i <= 5; i++)
                    {
                        healthHUDs[i].GetComponent<Image>().sprite = Resources.Load<Sprite>("empty_heart");
                    }
                }
                else if (currentHealth == 2)
                {
                    for (int i = 0; i < 1; i++)
                    {
                        healthHUDs[i].GetComponent<Image>().sprite = Resources.Load<Sprite>("full_heart");
                    }
                    for (int i = 1; i <= 5; i++)
                    {
                        healthHUDs[i].GetComponent<Image>().sprite = Resources.Load<Sprite>("empty_heart");
                    }
                }
                break;
            case false:
                if (currentHealth == 11)
                {
                    for (int i = 0; i <= 5; i++)
                    {
                        if(i == 5)
                        {
                            healthHUDs[i].GetComponent<Image>().sprite = Resources.Load<Sprite>("half_heart");
                            break;
                        }
                        healthHUDs[i].GetComponent<Image>().sprite = Resources.Load<Sprite>("full_heart");
                    }
                }
                else if (currentHealth == 9)
                {
                    for (int i = 0; i <= 4; i++)
                    {
                        if (i == 4)
                        {
                            healthHUDs[i].GetComponent<Image>().sprite = Resources.Load<Sprite>("half_heart");
                            break;
                        }
                        healthHUDs[i].GetComponent<Image>().sprite = Resources.Load<Sprite>("full_heart");
                    }
                    healthHUDs[5].GetComponent<Image>().sprite = Resources.Load<Sprite>("empty_heart");
                }
                else if (currentHealth == 7)
                {
                    for (int i = 0; i <= 3; i++)
                    {
                        if (i == 3)
                        {
                            healthHUDs[i].GetComponent<Image>().sprite = Resources.Load<Sprite>("half_heart");
                            break;
                        }
                        healthHUDs[i].GetComponent<Image>().sprite = Resources.Load<Sprite>("full_heart");
                    }
                    for (int i = 4; i <= 5; i++)
                    {
                        healthHUDs[i].GetComponent<Image>().sprite = Resources.Load<Sprite>("empty_heart");
                    }
                }
                else if (currentHealth == 5)
                {
                    for (int i = 0; i <= 2; i++)
                    {
                        if (i == 2)
                        {
                            healthHUDs[i].GetComponent<Image>().sprite = Resources.Load<Sprite>("half_heart");
                            break;
                        }
                        healthHUDs[i].GetComponent<Image>().sprite = Resources.Load<Sprite>("full_heart");
                    }
                    for (int i = 3; i <= 5; i++)
                    {
                        healthHUDs[i].GetComponent<Image>().sprite = Resources.Load<Sprite>("empty_heart");
                    }
                }
                else if (currentHealth == 3)
                {
                    for (int i = 0; i <= 1; i++)
                    {
                        if (i == 1)
                        {
                            healthHUDs[i].GetComponent<Image>().sprite = Resources.Load<Sprite>("half_heart");
                            break;
                        }
                        healthHUDs[i].GetComponent<Image>().sprite = Resources.Load<Sprite>("full_heart");
                    }
                    for (int i = 2; i <= 5; i++)
                    {
                        healthHUDs[i].GetComponent<Image>().sprite = Resources.Load<Sprite>("empty_heart");
                    }
                }
                else if (currentHealth == 1)
                {
                    healthHUDs[0].GetComponent<Image>().sprite = Resources.Load<Sprite>("half_heart");
                    for (int i = 1; i <= 5; i++)
                    {
                        healthHUDs[i].GetComponent<Image>().sprite = Resources.Load<Sprite>("empty_heart");
                    }
                }
                break;
            default:
                foreach (GameObject temp in healthHUDs)
                {
                    temp.GetComponent<Image>().sprite = Resources.Load<Sprite>("full_heart");
                }
                break;
        }

        if(currentHealth == 0)
        {
            foreach (GameObject temp in healthHUDs)
            {
                temp.GetComponent<Image>().sprite = Resources.Load<Sprite>("empty_heart");
            }
        }
    }
}
