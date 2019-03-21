using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Movement : MonoBehaviour
{
    public float speed=10;
    float rotSpeed= 80;
    float gravity =8;
    float rot = 0f;
    public GameObject pickupEffect;
    Vector3 moveDir = Vector3.zero;
    public AudioClip walkingfx;
    public AudioSource walksource;
    public AudioClip musicfx;
    public AudioSource musicsource;
    bool walkingsound = false;
    float jump;

    CharacterController controller;
    Animator anim;

    void Start()
    {
        controller = GetComponent<CharacterController>();
        anim = GetComponent<Animator>();
        walksource.clip = walkingfx;
        musicsource.clip = musicfx;
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            musicsource.Play();
        }
        if (controller.isGrounded)
        {
            if (Input.GetKey(KeyCode.W))
            {
                anim.SetInteger("condition", 1);
                moveDir = new Vector3(0, 0, 1);
                moveDir *= speed;
                moveDir = transform.TransformDirection(moveDir);
                walkingsound = true;
                if (Input.GetKeyDown(KeyCode.W) && walkingsound == true)
                {
                    walksource.Play();
                }else if (Input.GetKeyUp(KeyCode.W))
                {
                    walkingsound = false;
                }
            }
            else if (Input.GetKey(KeyCode.LeftShift) && GameVariables.stamina<50)
            {
                anim.SetInteger("condition", 1);
                moveDir = new Vector3(0, 0, 1);
                moveDir *= speed*3;
                moveDir = transform.TransformDirection(moveDir);
                GameVariables.stamina += 1;
            }
            else if (Input.GetKey(KeyCode.S))
            {
                anim.SetInteger("condition", 1);
                moveDir = new Vector3(0, 0, -1);
                moveDir *= speed;
                moveDir = transform.TransformDirection(moveDir);
            }
            else if (Input.GetKey(KeyCode.I))
            {
                moveDir = new Vector3(0, 5, -5);
            }
            else if (Input.GetKey(KeyCode.K))
            {
                moveDir = new Vector3(0, 5, 5);
            }
            else if (Input.GetKey(KeyCode.J))
            {
                moveDir = new Vector3(5, 5, 0);
            }
            else if (Input.GetKey(KeyCode.L))
            {
                moveDir = new Vector3(-5, 5, 0);
            }
            else
            {
                anim.SetInteger("condition",0);
                moveDir = new Vector3(0, 0, 0);
            }
        }

        rot += Input.GetAxis("Horizontal") * rotSpeed * Time.deltaTime;
        rot = Input.mousePosition.x-Screen.width/2;

        transform.eulerAngles = new Vector3(0, rot, 0);
        moveDir.y -= gravity * Time.deltaTime;
        controller.Move(moveDir * Time.deltaTime);

        if(Input.GetKey(KeyCode.R))
        {
            FindObjectOfType<GameManager>().EndGame();
        }

        if (Input.GetKey(KeyCode.Q))
        {
            SceneManager.LoadScene("Game Over");
        }
        if (GameVariables.health == 0)
        {
            SceneManager.LoadScene("Menu");
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Slime"))
        {
            collision.gameObject.SetActive(false);
        }
    }

    void OnTriggerStay(Collider other)
    {
         if (Input.GetKey(KeyCode.E) && other.gameObject.CompareTag("Pick Up"))
         {
                other.gameObject.SetActive(false);
            Instantiate(pickupEffect, transform.position, transform.rotation);
                gameObject.GetComponent<Animator>().Play("pickup");
                GameVariables.count = GameVariables.count + 1;
        }

    }
}
