using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NilaiRambuIndicator : MonoBehaviour
{
    public GameObject sistem;
    // Start is called before the first frame update
    void Start()
    {
        sistem = GameObject.Find("Sistem");
    }

    // Update is called once per frame
    void Update()
    {
        this.GetComponent<UnityEngine.UI.Text>().text = "Nilai Taat: " + sistem.GetComponent<SistemUtama>().nilaiKetaatan;
       
    }
}
