using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayButtonpos : MonoBehaviour
{
    GameObject thisButton;
    // Start is called before the first frame update
    void Start()
    {
        thisButton = this.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        thisButton.transform.position = new Vector3(thisButton.transform.position.x, Screen.width - thisButton.transform.position.x, thisButton.transform.position.z);
    }
}
