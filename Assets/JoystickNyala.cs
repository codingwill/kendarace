using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JoystickNyala : MonoBehaviour
{
    GameObject joystick;
    // Start is called before the first frame update
    void Start()
    {
        joystick = GameObject.Find("FixedJoystick");
    }

    // Update is called once per frame
    void Update()
    {
        if (joystick.GetComponent<Joybutton>().Pressed == true)
        {
            this.GetComponent<UnityEngine.UI.Image>().color = new Color(this.GetComponent<UnityEngine.UI.Image>().color.r,
                                                                        this.GetComponent<UnityEngine.UI.Image>().color.g,
                                                                        this.GetComponent<UnityEngine.UI.Image>().color.b,
                                                                        0.85f);
        }
        else
        {
            this.GetComponent<UnityEngine.UI.Image>().color = new Color(this.GetComponent<UnityEngine.UI.Image>().color.r,
                                                                        this.GetComponent<UnityEngine.UI.Image>().color.g,
                                                                        this.GetComponent<UnityEngine.UI.Image>().color.b,
                                                                        0.5f);
        }

    }
}
