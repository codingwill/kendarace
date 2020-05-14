using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExpBarPos : MonoBehaviour
{
    GameObject thisText;
    // Start is called before the first frame update
    void Start()
    {
        thisText = this.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        thisText.transform.position = new Vector3(thisText.transform.position.x, Screen.height * 0.07f, thisText.transform.position.z);
    }
}
