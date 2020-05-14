using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FinishText : MonoBehaviour
{
    public GameObject finishText;
    public bool finish;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        finishText.transform.position = new Vector3(Screen.width * 0.5f, Screen.height * 0.75f, finishText.transform.position.z);
        finish = GameObject.Find("Sistem").GetComponent<SistemUtama>().FINISH;
        if (finish)
            finishText.GetComponent<Text>().enabled = true;
    }
}
