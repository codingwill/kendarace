using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarMovement : MonoBehaviour
{
    GameObject sistem;
    public Component[] mobil;
    public JointMotor2D ban;
    protected Joystick joystick;
    protected Joybutton joybutton;
    public bool diJalan = false;
    public int maxSpeed = 0, maxBanSpeed = 0;
    public bool pilihAtas = false;
    //Collider2D banbel = GameObject.Find("banbelakang").GetComponent<Collider2D>;
    //Collider2D bandepan = GameObject.Find("bandepan").GetComponent<Collider2D>;

    // Start is called before the first frame update
    void Start()
    {
        
        sistem = GameObject.Find("Sistem");
        joystick = FindObjectOfType<Joystick>();
        mobil = GetComponents(typeof(WheelJoint2D));
        foreach (WheelJoint2D joint in mobil)
            ban = joint.motor;
    }

    void OnTriggerStay2D(Collider2D collision)
    {
        //Debug.Log("Lagi bersetubuh");
        if (collision.gameObject.tag == "Rambu")
        {
            GameObject.Find("UpButton").GetComponent<UpButton>().bolehPencet = true;
            if (pilihAtas)
            {
                collision.GetComponent<IsTouchingIntersection>().pilihAtas = true;
            }
            else
            {
                collision.GetComponent<IsTouchingIntersection>().pilihAtas = false;
            }
            
        }
    }
    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Rambu")
        {
            GameObject.Find("UpButton").GetComponent<UpButton>().bolehPencet = false;
        }
    }
    void Awake()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        if (!sistem.GetComponent<SistemUtama>().PAUSE || !sistem.GetComponent<SistemUtama>().FINISH)
        {
            Rigidbody2D rigidbody;
            rigidbody = GetComponent<Rigidbody2D>();
            //rigidbody.angularVelocity = 0;
            //if (ban.motorSpeed > -5000) 
            //Debug.Log("ban.motorSpeed = " + ban.motorSpeed);

            if (diJalan)
            {
                if (Input.GetButton("Horizontal") || Input.GetMouseButton(0))
                {
                    if (((joystick.Horizontal >= -1 && joystick.Horizontal <= -0.8) || (joystick.Horizontal <= 1 && joystick.Horizontal >= 0.8)) || ((Input.GetAxis("Horizontal") >= -1 && Input.GetAxis("Horizontal") <= -0.8) || (Input.GetAxis("Horizontal") <= 1 && Input.GetAxis("Horizontal") >= 0.8)))
                        maxSpeed = 10;
                    else if (((joystick.Horizontal > -0.6 && joystick.Horizontal <= -0.4) || (joystick.Horizontal < 0.6 && joystick.Horizontal >= 0.4)) || ((Input.GetAxis("Horizontal") > -0.6 && Input.GetAxis("Horizontal") <= -0.4) || (Input.GetAxis("Horizontal") < 0.6 && Input.GetAxis("Horizontal") >= 0.4)))
                        maxSpeed = 6;
                    else if (((joystick.Horizontal > -0.8 && joystick.Horizontal <= -0.6) || (joystick.Horizontal < 0.8 && joystick.Horizontal >= 0.6)) || ((Input.GetAxis("Horizontal") > -0.8 && Input.GetAxis("Horizontal") <= -0.6) || (Input.GetAxis("Horizontal") < 0.8 && Input.GetAxis("Horizontal") >= 0.6)))
                        maxSpeed = 8;
                    else if (((joystick.Horizontal > -0.4 && joystick.Horizontal <= -0.2) || (joystick.Horizontal < 0.4 && joystick.Horizontal >= 0.2)) || ((Input.GetAxis("Horizontal") > -0.4 && Input.GetAxis("Horizontal") <= -0.2) || (Input.GetAxis("Horizontal") < 0.4 && Input.GetAxis("Horizontal") >= 0.2)))
                        maxSpeed = 4;
                    else if (((joystick.Horizontal > -0.2 && joystick.Horizontal <= 0) || (joystick.Horizontal < 0.2 && joystick.Horizontal >= 0)) || ((Input.GetAxis("Horizontal") > -0.2 && Input.GetAxis("Horizontal") <= 0) || (Input.GetAxis("Horizontal") < 0.2 && Input.GetAxis("Horizontal") >= 0)))
                        maxSpeed = 2;
                }

                //Debug.Log("joystick.Hr = " + Input.GetAxis("Horizontal"));
                rigidbody = GetComponent<Rigidbody2D>();
                if (rigidbody.velocity.x > maxSpeed)
                    rigidbody.velocity = new Vector2(maxSpeed, rigidbody.velocity.y);
                else if (rigidbody.velocity.x < -maxSpeed)
                    rigidbody.velocity = new Vector2(-maxSpeed, rigidbody.velocity.y);
                else if (rigidbody.velocity.x < 0.0001f && rigidbody.velocity.x > -0.0001f)
                    rigidbody.velocity = new Vector2(0f, 0f);
                else
                    rigidbody.velocity = new Vector2(rigidbody.velocity.x + (joystick.Horizontal + Input.GetAxis("Horizontal")) * 0.22f, rigidbody.velocity.y); ;
            }

            maxBanSpeed = 5000;
            if (ban.motorSpeed >= -maxBanSpeed && ban.motorSpeed <= maxBanSpeed)
            {
                ban.motorSpeed += joystick.Horizontal * -150;
                if (ban.motorSpeed > maxBanSpeed)
                    ban.motorSpeed = maxBanSpeed;
                else if (ban.motorSpeed < -maxBanSpeed)
                    ban.motorSpeed = -maxBanSpeed;
            }




            if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow) ||
                Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
            {
                //Debug.Log("true");
                if (ban.motorSpeed > -maxBanSpeed && ban.motorSpeed < maxBanSpeed)
                    ban.motorSpeed -= Input.GetAxis("Horizontal") * 150;
            }
            else if (joystick.Horizontal == 0)
            {
                if (ban.motorSpeed != 0)
                {
                    if (ban.motorSpeed >= -100 && ban.motorSpeed <= 100)
                        ban.motorSpeed = 0;
                    else
                    {
                        if (ban.motorSpeed > 0)
                            ban.motorSpeed -= 100;
                        else
                            ban.motorSpeed += 100;
                    }

                }

            }

            foreach (WheelJoint2D joint in mobil)
                joint.motor = ban;
        }
        

    }
}
