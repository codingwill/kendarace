using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CekColTanah2 : MonoBehaviour
{
    CarMovement carControl;
    public bool diTanah;
    // Start is called before the first frame update
    void Start()
    {
        carControl = transform.parent.GetComponent<CarMovement>();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            diTanah = true;
        }
    }
    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            
            diTanah = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        carControl.diJalan = diTanah;
    }
}
