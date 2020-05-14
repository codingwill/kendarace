using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PausedText : MonoBehaviour
{
    public GameObject pausedText;
    public bool paused;
    
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        pausedText.transform.position = new Vector3(Screen.width * 0.5f, Screen.height * 0.75f, pausedText.transform.position.z);
        //paused = GameObject.Find("Sistem").GetComponent<SistemUtama>().PAUSE;
        //if (paused && !GameObject.Find("Sistem").GetComponent<SistemUtama>().FINISH)
            //pausedText.GetComponent<Text>().enabled = true;
    }
}
