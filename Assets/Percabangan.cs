using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Percabangan : MonoBehaviour
{

    private Collider2D percabangan;
    // Start is called before the first frame update
    void Start()
    {
        percabangan = this.GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            percabangan.enabled = true;
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            percabangan.enabled = false;
        }
    }
}
