using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpButton : MonoBehaviour
{
    public bool bolehPencet;
    public GameObject mobil;
    // Start is called before the first frame update
    void Start()
    {
        bolehPencet = false;
    }

    public void UpPressed()
    {
        Debug.Log("bolehPencet = " + bolehPencet);
        if (bolehPencet)
        {
            if (!GameObject.Find("badan").GetComponent<CarMovement>().pilihAtas)
               GameObject.Find("badan").GetComponent<CarMovement>().pilihAtas = true;
            else
                GameObject.Find("badan").GetComponent<CarMovement>().pilihAtas = false;
        }
    }

    public void DownPressed()
    {
        Input.GetKeyDown(KeyCode.S);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
