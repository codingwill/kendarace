using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class HealthIndicator : MonoBehaviour
{
    Rigidbody2D mobil;
    UnityEngine.UI.Text speedMeter;
    RectTransform textPos;
    public float speedNumMultiplier;

    // Start is called before the first frame update
    void Start()
    {
        mobil = GameObject.Find("badan").GetComponent<Rigidbody2D>();
        speedMeter = this.GetComponent<UnityEngine.UI.Text>();
        textPos = this.GetComponent<RectTransform>();
        
    }

    // Update is called once per frame
    void Update()
    {
        //textPos.transform.position = new Vector3(Screen.width * 0.875f, Screen.height * 0.95f, textPos.transform.position.z);
        if (mobil.velocity.x > 0)
            speedMeter.text = "Speed: " + Math.Floor(mobil.velocity.x * speedNumMultiplier);
        if (mobil.velocity.x < 0)
            speedMeter.text = "Speed: " + Math.Ceiling(mobil.velocity.x * speedNumMultiplier);
    }
}
