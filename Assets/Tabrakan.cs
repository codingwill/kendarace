using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Tabrakan : MonoBehaviour
{
    Rigidbody2D mobil;
    public int health = 100;
    public bool meledak = false;
    Component[] mobilJoints;
    JointMotor2D ban;
    // Start is called before the first frame update
    void Start()
    {
        mobil = GameObject.Find("badan").GetComponent<Rigidbody2D>();
        mobilJoints = GetComponents(typeof(WheelJoint2D));
        ban.motorSpeed = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (health <= 0)
        {
            GameObject.Find("Sistem").GetComponent<SistemUtama>().GAGAL = true;
            health = 0;
            meledak = true;
            GetComponent<CarMovement>().enabled = false;
            mobil.bodyType = RigidbodyType2D.Static;
            foreach (WheelJoint2D joint in mobilJoints)
            {
                joint.motor = ban;
                joint.enabled = false;
            }

            GameObject.Find("car-body").GetComponent<SpriteRenderer>().enabled = false;
            //GameObject.Find("car-body").GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
            GameObject.Find("badan").GetComponent<PolygonCollider2D>().enabled = false;
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            
            health -= (int)(1 * Math.Round(Math.Sqrt(Math.Pow(mobil.velocity.x, 2) + Math.Pow(mobil.velocity.y, 2))));
            Debug.Log("HEALTH = " + health);
        }
        
    }
}
