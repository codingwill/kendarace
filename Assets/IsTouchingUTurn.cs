using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsTouchingUTurn : MonoBehaviour
{
    public GameObject sistem;
    protected bool sudahMasuk = false, enter = true;
    // Start is called before the first frame update
    void Start()
    {
        sistem = GameObject.Find("Sistem");
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (enter /*&& (this.transform.position.x < GameObject.Find("badan").GetComponent<Transform>().position.x)*/)
        {
            sudahMasuk = true;
            enter = false;
            Debug.Log("Keluar");
        }
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "badan")
        {
            if (sudahMasuk && (this.transform.position.x < GameObject.Find("badan").GetComponent<Transform>().position.x))
            {
                sistem.GetComponent<SistemUtama>().totalRambu++;
                sudahMasuk = false;
                enter = true;
                //Debug.Log("Nyentuh Rambu No U Turn");
            }
            else
            {
                enter = true;
            }
                
            
        }
    }
    // Update is called once per frame
    void Update()
    {
        //Debug.Log("RAMBU = " + this.transform.position.x + "MOBIL = " + GameObject.Find("badan").GetComponent<Transform>().position.x);
    }
}
