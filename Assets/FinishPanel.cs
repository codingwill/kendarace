using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class FinishPanel : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject finishPanel;
    public bool finish;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        finishPanel.transform.position = new Vector3(Screen.width * 0.5f, Screen.height * 0.75f, finishPanel.transform.position.z);
        finish = GameObject.Find("Sistem").GetComponent<SistemUtama>().FINISH;
        if (finish)
            finishPanel.GetComponent<Image>().enabled = true;
    }
}
