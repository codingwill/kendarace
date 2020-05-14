using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoPosBasedOnRes : MonoBehaviour
{
    RectTransform joystick;
    // Start is called before the first frame update
    void Start()
    {
        joystick = this.GetComponent<RectTransform>();
        
    }

    // Update is called once per frame
    void Update()
    {
        joystick.transform.position = new Vector3(Screen.width * 0.82f, Screen.height * 0.175f, joystick.transform.position.z);
    }
}
