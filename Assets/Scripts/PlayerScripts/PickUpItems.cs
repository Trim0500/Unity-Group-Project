using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PickUpItems : MonoBehaviour
{
    private Item cardKey, lettuceBomb, baguet;
    private Text cardKeyCount, breadCount, lettuceCount;
    public GameObject lettucePrefab, breadPrefab;
    private bool locked = true;
    private bool lockedRooms = true;
    private bool lockedRooms2 = true;

    // Start is called before the first frame update
    void Start()
    {
        cardKeyCount = GameObject.Find("CardkeyCounter").GetComponent<Text>();
        breadCount = GameObject.Find("BaguetCounter").GetComponent<Text>();
        lettuceCount = GameObject.Find("LettuceCounter").GetComponent<Text>();

        //Debug.Log("Card key UI text: " + cardKeyCount.text);
    }

    // Update is called once per frame
    void Update()
    {
        if((Input.GetKeyDown(KeyCode.I) && (lettuceBomb.getQuantity() == 0 || lettuceBomb == null)) || (Input.GetKeyDown(KeyCode.P) && (baguet.getQuantity() == 0 || baguet == null)))
        {
            return;
        }
        else if(Input.GetKeyDown(KeyCode.I) && lettuceBomb.getQuantity() > 0)
        {
            GameObject player = GameObject.FindGameObjectWithTag("Player");
            Vector3 playerPosition = player.GetComponent<Transform>().position;

            if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
            {
                GameObject thrownItem = Instantiate(lettucePrefab, new Vector3(playerPosition.x, playerPosition.y + 1.25f, playerPosition.z), Quaternion.identity);
                Rigidbody2D itemRB = thrownItem.GetComponent<Rigidbody2D>();
                itemRB.AddForce(new Vector3(0, 6, 0), ForceMode2D.Impulse);
                lettuceBomb.setQuantity(lettuceBomb.getQuantity() - 1);
                lettuceCount.text = "x" + lettuceBomb.getQuantity();
            }
            else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
            {
                GameObject thrownItem = Instantiate(lettucePrefab, new Vector3(playerPosition.x + 1.25f, playerPosition.y, playerPosition.z), Quaternion.identity);
                Rigidbody2D itemRB = thrownItem.GetComponent<Rigidbody2D>();
                itemRB.AddForce(new Vector3(6, 0, 0), ForceMode2D.Impulse);
                lettuceBomb.setQuantity(lettuceBomb.getQuantity() - 1);
                lettuceCount.text = "x" + lettuceBomb.getQuantity();
            }
            else if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
            {
                GameObject thrownItem = Instantiate(lettucePrefab, new Vector3(playerPosition.x, playerPosition.y - 1.25f, playerPosition.z), Quaternion.identity);
                Rigidbody2D itemRB = thrownItem.GetComponent<Rigidbody2D>();
                itemRB.AddForce(new Vector3(0, -6, 0), ForceMode2D.Impulse);
                lettuceBomb.setQuantity(lettuceBomb.getQuantity() - 1);
                lettuceCount.text = "x" + lettuceBomb.getQuantity();
            }
            else if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
            {
                GameObject thrownItem = Instantiate(lettucePrefab, new Vector3(playerPosition.x - 1.25f, playerPosition.y, playerPosition.z), Quaternion.identity);
                Rigidbody2D itemRB = thrownItem.GetComponent<Rigidbody2D>();
                itemRB.AddForce(new Vector3(-6, 0, 0), ForceMode2D.Impulse);
                lettuceBomb.setQuantity(lettuceBomb.getQuantity() - 1);
                lettuceCount.text = "x" + lettuceBomb.getQuantity();
            }
        }
        else if(Input.GetKeyDown(KeyCode.P) && baguet.getQuantity() > 0)
        {
            GameObject player = GameObject.FindGameObjectWithTag("Player");
            Vector3 playerPosition = player.GetComponent<Transform>().position;

            if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
            {
                GameObject thrownItem = Instantiate(breadPrefab, new Vector3(playerPosition.x, playerPosition.y + 1.25f, playerPosition.z), Quaternion.identity);
                Rigidbody2D itemRB = thrownItem.GetComponent<Rigidbody2D>();
                itemRB.AddForce(new Vector3(0, 6, 0), ForceMode2D.Impulse);
                baguet.setQuantity(baguet.getQuantity() - 1);
                breadCount.text = "x" + baguet.getQuantity();
            }
            else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
            {
                GameObject thrownItem = Instantiate(breadPrefab, new Vector3(playerPosition.x + 1.25f, playerPosition.y, playerPosition.z), Quaternion.identity);
                Rigidbody2D itemRB = thrownItem.GetComponent<Rigidbody2D>();
                itemRB.AddForce(new Vector3(6, 0, 0), ForceMode2D.Impulse);
                baguet.setQuantity(baguet.getQuantity() - 1);
                breadCount.text = "x" + baguet.getQuantity();
            }
            else if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
            {
                GameObject thrownItem = Instantiate(breadPrefab, new Vector3(playerPosition.x, playerPosition.y - 1.25f, playerPosition.z), Quaternion.identity);
                Rigidbody2D itemRB = thrownItem.GetComponent<Rigidbody2D>();
                itemRB.AddForce(new Vector3(0, -6, 0), ForceMode2D.Impulse);
                baguet.setQuantity(baguet.getQuantity() - 1);
                breadCount.text = "x" + baguet.getQuantity();
            }
            else if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
            {
                GameObject thrownItem = Instantiate(breadPrefab, new Vector3(playerPosition.x - 1.25f, playerPosition.y, playerPosition.z), Quaternion.identity);
                Rigidbody2D itemRB = thrownItem.GetComponent<Rigidbody2D>();
                itemRB.AddForce(new Vector3(-6, 0, 0), ForceMode2D.Impulse);
                baguet.setQuantity(baguet.getQuantity() - 1);
                breadCount.text = "x" + baguet.getQuantity();
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(!locked && collision.tag == "Door")
        {
            GameObject player = GameObject.FindGameObjectWithTag("Player");
            player.GetComponent<Transform>().position = new Vector3(-17, -1, -2);
            GameObject camera = GameObject.FindGameObjectWithTag("MainCamera");
            camera.GetComponent<Transform>().position = new Vector3(-28, 0, -10);

            SceneManager.LoadScene("ExitRooms");
        }
        else if (!lockedRooms && collision.name == "backRoom1")
        {
            GameObject room1 = GameObject.Find("backRoom1");
            room1.GetComponent<ChangeExitRoomsCamera>().enabled = true;

            GameObject room2 = GameObject.Find("toNextRoom1");
            room2.GetComponent<ChangeExitRoomsCamera>().enabled = true;
        }
        else if (!lockedRooms2 && collision.name == "backRoom2")
        {
            GameObject room1 = GameObject.Find("backRoom2");
            room1.GetComponent<ChangeExitRoomsCamera>().enabled = true;

            GameObject room2 = GameObject.Find("toNextRoom2");
            room2.GetComponent<ChangeExitRoomsCamera>().enabled = true;
        }

        else
        {
            return;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log(collision.name);

            if(collision.tag == "KeyItem")
            {
                if(cardKey == null)
                {
                    cardKey = new Item();
                    cardKey.setName("Card Key");
                    cardKey.setType("Key Item");
                    cardKey.setQuantity(1);
                    cardKey.setMt(0f);
                    cardKey.setOpenDoors(true);

                    /*Debug.Log("Item Object: " + cardKey.getName() + 
                        "\nType: " + cardKey.getType() + 
                        "\nQuantity: " + cardKey.getQuantity() + 
                        "\nMt: " + cardKey.getMt() + 
                        "\nCan Open Doors: " + cardKey.getOpenDoors());*/
                }
                else
                {
                    cardKey.setQuantity(cardKey.getQuantity() + 1);

                    //Debug.Log("Updated the Card Key Quantity. You now have " + cardKey.getQuantity() + " Card Key(s).");
                }

                cardKeyCount.text = "x" + cardKey.getQuantity();

                Destroy(GameObject.FindGameObjectWithTag("KeyItem"));
            }
            else if(collision.tag == "ConsumableMelee")
            {
                if (baguet == null)
                {
                    baguet = new Item();
                    baguet.setName("Baguet");
                    baguet.setType("Consumable");
                    baguet.setQuantity(1);
                    baguet.setMt(2f);
                    baguet.setOpenDoors(false);

                    /*Debug.Log("Item Object: " + baguet.getName() +
                        "\nType: " + baguet.getType() +
                        "\nQuantity: " + baguet.getQuantity() +
                        "\nMt: " + baguet.getMt() +
                        "\nCan Open Doors: " + baguet.getOpenDoors());*/
                }
                else
                {
                    baguet.setQuantity(baguet.getQuantity() + 1);

                    //Debug.Log("Updated the Baguet Quantity. You now have " + baguet.getQuantity() + " Baguet(s).");
                }

                breadCount.text = "x" + baguet.getQuantity();

                Destroy(GameObject.FindGameObjectWithTag("ConsumableMelee"));
            }
            else if (collision.tag == "ConsumableProjectile")
            {
                if (lettuceBomb == null)
                {
                    lettuceBomb = new Item();
                    lettuceBomb.setName("Lettuce Bomb");
                    lettuceBomb.setType("Consumable");
                    lettuceBomb.setQuantity(1);
                    lettuceBomb.setMt(4f);
                    lettuceBomb.setOpenDoors(false);

                    /*Debug.Log("Item Object: " + lettuceBomb.getName() +
                        "\nType: " + lettuceBomb.getType() +
                        "\nQuantity: " + lettuceBomb.getQuantity() +
                        "\nMt: " + lettuceBomb.getMt() +
                        "\nCan Open Doors: " + lettuceBomb.getOpenDoors());*/
                }
                else
                {
                    lettuceBomb.setQuantity(lettuceBomb.getQuantity() + 1);

                    //Debug.Log("Updated the Lettuce Bomb Quantity. You now have " + lettuceBomb.getQuantity() + " bombs(s).");
                }

                lettuceCount.text = "x" + lettuceBomb.getQuantity();

                Destroy(GameObject.FindGameObjectWithTag("ConsumableProjectile"));
            }
            else if (collision.tag == "Door")
            {
                //Debug.Log("Pressed space at the door.");
                int keys = cardKey.getQuantity();
                Debug.Log("You have " + keys + " at the door");

                if (locked && keys > 0)
                {
                    keys--;
                    cardKey.setQuantity(keys);
                    Debug.Log("Used a card key. You are now left with " + keys + " card keys.");

                    cardKeyCount.text = "x" + keys;
                    Debug.Log("Updated the keys HUD.");

                    GameObject player = GameObject.FindGameObjectWithTag("Player");
                    player.GetComponent<Transform>().position = new Vector3(-17, -1, -2);
                    GameObject camera = GameObject.FindGameObjectWithTag("MainCamera");
                    camera.GetComponent<Transform>().position = new Vector3(-28, 0, -10);

                    locked = false;

                    SceneManager.LoadScene("ExitRooms");
                }
            }
            else if(collision.name == "backRoom1" && lockedRooms)
            {
                Debug.Log("Pressed space at the door.");

                int keys = cardKey.getQuantity();
                Debug.Log("You currentyl have: " + keys + " keys");

                if (lockedRooms && keys > 0)
                {
                    keys--;
                    cardKey.setQuantity(keys);
                    Debug.Log("Used a card key. You are now left with " + keys + " card keys.");

                    cardKeyCount.text = "x" + keys;
                    Debug.Log("Updated the keys HUD.");

                    lockedRooms = false;

                    GameObject room1 = GameObject.Find("backRoom1");
                    room1.GetComponent<ChangeExitRoomsCamera>().enabled = true;

                    GameObject room2 = GameObject.Find("toNextRoom1");
                    room2.GetComponent<ChangeExitRoomsCamera>().enabled = true;
                }
            }
            else if (collision.name == "backRoom2" && lockedRooms2)
            {
                Debug.Log("Pressed space at the door.");

                int keys = cardKey.getQuantity();
                Debug.Log("You currentyl have: " + keys + " keys");

                if (lockedRooms2 && keys > 0)
                {
                    keys--;
                    cardKey.setQuantity(keys);
                    Debug.Log("Used a card key. You are now left with " + keys + " card keys.");

                    cardKeyCount.text = "x" + keys;
                    Debug.Log("Updated the keys HUD.");

                    lockedRooms2 = false;

                    GameObject room1 = GameObject.Find("backRoom2");
                    room1.GetComponent<ChangeExitRoomsCamera>().enabled = true;

                    GameObject room2 = GameObject.Find("toNextRoom2");
                    room2.GetComponent<ChangeExitRoomsCamera>().enabled = true;
                }
            }
            else
            {
                return;
            }
        }
    }
}
