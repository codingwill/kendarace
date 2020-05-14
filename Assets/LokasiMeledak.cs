using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LokasiMeledak : MonoBehaviour
{
    Transform mobilPos;
    Tabrakan mobilHealth;
    public bool sudahMeledak = false;
    public int deathCount = 0;
    // Start is called before the first frame update
    void Start()
    {
        mobilPos = GameObject.Find("badan").GetComponent<Transform>();
        mobilHealth = GameObject.Find("badan").GetComponent<Tabrakan>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (GetComponent<Animator>().IsInTransition(0))
        {
            this.GetComponent<SpriteRenderer>().enabled = false;
        }
        else if (mobilHealth.meledak && deathCount == 0)
        {
            this.transform.position = new Vector3(mobilPos.transform.position.x, mobilPos.transform.position.y, this.transform.position.z);
            this.GetComponent<SpriteRenderer>().enabled = true;
            deathCount++;
            if (!sudahMeledak)
            {
                this.GetComponent<Animator>().SetTrigger("meledak");
                sudahMeledak = true;
                //this.GetComponent<Animator>().SetBool("mati", true);
            }
               
        }
    }
}
