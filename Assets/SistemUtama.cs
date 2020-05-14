using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class SistemUtama : MonoBehaviour
{
    public float timer, bgTimer = 0;
    public GameObject timerText;
    public float totalRambu, nilaiRambu;
    public float nilaiKetaatan;
    public GameObject flag, player, mobil, panelTengah;
    public bool FINISH = false;
    public bool PAUSE = false;
    public bool PLAYING = true;
    public bool GAGAL = false;
    public Component[] ban;
    private JointMotor2D speedBan;
    // Start is called before the first frame update
    void Start()
    {
        nilaiRambu = totalRambu;
        mobil = GameObject.Find("badan");
        ban = mobil.GetComponents<WheelJoint2D>();
        speedBan.motorSpeed = 0;
    }

    public void Pause()
    {
        if (!PAUSE)
            PAUSE = true;
        else
            PAUSE = false;
    }
    // Update is called once per frame
    void Update()
    {
        

        //Gagal
        if (GAGAL)
        {
            panelTengah.GetComponent<Image>().enabled = true;
            GameObject.Find("GagalText").GetComponent<Text>().enabled = true;
            bgTimer += Time.deltaTime;
            GameObject.Find("badan").GetComponent<Tabrakan>().health = 0;
            if (bgTimer >= 5)
                Time.timeScale = 0;
        }
        else
        {
            //Timer
            if (timer > 0)
                timer -= Time.deltaTime;
            else
            {
                if (FINISH == false)
                {
                    GAGAL = true;
                }
            }
        }

        timerText.GetComponent<Text>().text = "Timer: " + timer.ToString("0");
        //NilaiKetaatan
        nilaiKetaatan = (float)Math.Round(nilaiRambu / totalRambu * 100);
        //definisi STATE PLAYING
        if (PLAYING)
        {
            mobil.GetComponent<CarMovement>().enabled = true;
        }
        else
        {
            mobil.GetComponent<CarMovement>().enabled = false;
            foreach (WheelJoint2D joint in ban)
                joint.useMotor = false;
            if (mobil.GetComponent<Rigidbody2D>().velocity.x > 0 && mobil.GetComponent<Rigidbody2D>().velocity.x <= 0.3f)
            {
                mobil.GetComponent<Rigidbody2D>().velocity = new Vector2(0, mobil.GetComponent<Rigidbody2D>().velocity.y);
            }
            if (mobil.GetComponent<Rigidbody2D>().velocity.x > 0.3f)
            {
                mobil.GetComponent<Rigidbody2D>().velocity = new Vector2(mobil.GetComponent<Rigidbody2D>().velocity.x - 0.5f, mobil.GetComponent<Rigidbody2D>().velocity.y);
            }
            else if (mobil.GetComponent<Rigidbody2D>().velocity.x < 0)
            {
                mobil.GetComponent<Rigidbody2D>().velocity = new Vector2(mobil.GetComponent<Rigidbody2D>().velocity.x + 0.5f, mobil.GetComponent<Rigidbody2D>().velocity.y);
            }
        }

        //definisi STATE FINISH
        if (player.transform.position.x > flag.transform.position.x)
        {
            Debug.Log("Finish!");
            FINISH = true;
            PLAYING = false;
            //GameObject.Find("FinishText").GetComponent<Text>().enabled = true;
        }

        //set tombol PAUSE GAME
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (PAUSE == false)
                PAUSE = true;
            else
                PAUSE = false;
        }

        //definisi PAUSE GAME
        if (PAUSE && !FINISH && !GAGAL)
        {
            Debug.Log("test");
            Time.timeScale = 0;
            panelTengah.GetComponent<Image>().enabled = true;
            GameObject.Find("PausedText").GetComponent<Text>().enabled = true;
        }
        else if (!PAUSE && !FINISH && !GAGAL)
        {
            Time.timeScale = 1;
            panelTengah.GetComponent<Image>().enabled = false;
            GameObject.Find("PausedText").GetComponent<Text>().enabled = false;
        }
    }
}
