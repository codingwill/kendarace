using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class IsTouchingIntersection : MonoBehaviour
{
    public GameObject tilemapAtas, tilemapBawah;
    protected bool diDalam = false;
    public bool pilihAtas = false;
    // Start is called before the first frame update
    void Start()
    {
        //tilemapAtas = GameObject.Find("TilemapFull");
    }

    void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.name == "badan")
        {
            if (Input.GetKeyDown(KeyCode.W))
            {
                pilihAtas = true;
            }
            else if (Input.GetKeyDown(KeyCode.S))
            {
                pilihAtas = false;
            }


        }
        if (pilihAtas)
        {
            
            tilemapAtas.GetComponent<TilemapCollider2D>().enabled = true;
            tilemapAtas.GetComponent<Tilemap>().color = new Color(1f, 1f, 1f, 1f);
        }
        else
        {
            
            tilemapAtas.GetComponent<TilemapCollider2D>().enabled = false;
            tilemapAtas.GetComponent<Tilemap>().color = new Color(1f, 1f, 1f, 0.5f);
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
