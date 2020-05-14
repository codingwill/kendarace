using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class SpeedIndicator : MonoBehaviour
{
    Tabrakan mobil;
    UnityEngine.UI.Text healthBar;
    RectTransform textPos;

    // Start is called before the first frame update
    void Start()
    {
        mobil = GameObject.Find("badan").GetComponent<Tabrakan>();
        healthBar = this.GetComponent<UnityEngine.UI.Text>();
        textPos = this.GetComponent<RectTransform>();
        
    }

    // Update is called once per frame
    void Update()
    {
        healthBar.text = "Health: " + mobil.health;
        //textPos.transform.position = new Vector3(Screen.width * 0.5f, Screen.height * 0.95f, textPos.transform.position.z);
    }
}
