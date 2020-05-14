using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGBuilding: MonoBehaviour
{
    Transform target, bg;
    private Vector3 pos;
    // Start is called before the first frame update
    void Awake()
    {
        bg = this.GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        target = GameObject.Find("badan").GetComponent<Transform>();
        pos = target.position;
        bg.position = new Vector3((pos.x + 24) * 0.9f, (pos.y) * 0.95f + 4.0f, -3.1f);
    }
}
