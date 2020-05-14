using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CekColTanah : MonoBehaviour
{
    //public bool diTanah;
    // Start is called before the first frame update
    void Start()
    {
        //bool diTanah;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            //diTanah = true;
        }
    }
    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            //diTanah = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
