using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Movement : MonoBehaviour
{
    public GameObject sistem;

    //public Vector3 jarak = new Vector3(2, 0, 0);
    public Vector3 kecepatan;
    public float multiplier = 1;
    public Vector2 jumpForce = new Vector2(0, 100f);
    public bool canJump = false;
    private Vector3 gravity = new Vector3(0, -5.0f, 0);
    private Vector3 vJump, vAwal = new Vector3(0, 150f, 0);
    public Vector3 posAwal, posPlayer, posBaru;
    private Vector3 setengah = new Vector3(0.5f, 0.5f, 0.5f);
    private float velSum = 0, velMax = 70;
    private Vector2 vel;
    //public bool isKiri = false, isKanan = true;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void OnCollisionStay2D(Collision2D collision)
    {
            GetComponent<Animator>().SetBool("playerGlide", false);
            //canJump = true;
            posAwal = GetComponent<Transform>().position;
            vJump = vAwal;
            GetComponent<Animator>().SetBool("playerJump", false);
            velSum = 0;
    }
    void OnCollisionExit2D(Collision2D collision)
    {
        GetComponent<Animator>().SetBool("playerGlide", false);
        //canJump = true;
        posAwal = GetComponent<Transform>().position;
        vJump = vAwal;
        GetComponent<Animator>().SetBool("playerJump", false);
    }

    // Update is called once per frame
    void Update()
    {
        posPlayer = GetComponent<Transform>().position;
        posBaru = posPlayer - posAwal;
        
        //Movement
        //if (animator.SetTrigger("Play"))

        if (Input.GetKey(KeyCode.D))
        {
            if (transform.localScale.x < 0)
            {
                transform.localScale = new Vector3(transform.localScale.x * -1.0f, transform.localScale.y, transform.localScale.z);
                // isKiri = false; isKanan = true;
            }
            kecepatan = new Vector3(Input.GetAxis("Horizontal") + multiplier, 0, 0);
            GetComponent<Transform>().position += kecepatan * Time.deltaTime;
            GetComponent<Animator>().SetBool("playerRun", true);

        }
        else if (Input.GetKeyUp(KeyCode.D))
        {
            GetComponent<Animator>().SetBool("playerRun", false);
        }
        else if (Input.GetKey(KeyCode.A))
        {
            if (transform.localScale.x > 0)
            {
                transform.localScale = new Vector3(transform.localScale.x * -1.0f, transform.localScale.y, transform.localScale.z);
                // isKiri = true; isKanan = false;
            }
            GetComponent<Transform>().position -= kecepatan * Time.deltaTime;
            GetComponent<Animator>().SetTrigger("playerRun");
        }
        else if (Input.GetKeyUp(KeyCode.A))
        {
            GetComponent<Animator>().ResetTrigger("playerRun");
            GetComponent<Animator>().SetTrigger("playerIdle");
        }
        
        if (canJump)
        {
            if (Input.GetKey(KeyCode.Space))
            {
                GetComponent<Animator>().SetBool("playerJump", true);
                if (velSum < velMax)
                {
                    GetComponent<Rigidbody2D>().velocity = new Vector2(0.0f, 5.5f);
                    vel = GetComponent<Rigidbody2D>().velocity;
                    velSum += vel.y;
                } 
                else
                {
                    canJump = false;
                    velSum = 0;
                }
                    
            }
        }
        if (Input.GetKeyDown(KeyCode.I))
            Debug.Log("vel is " + velSum + "canJump = " + canJump);
        vel = GetComponent<Rigidbody2D>().velocity;
        if (vel.y == 0)
            canJump = true;

    }
}
