using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGFollowPlayer : MonoBehaviour
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
        bg.position = new Vector3(pos.x + 3.0f * 1.0f, pos.y + 1.5f, -3.0f);
    }
}
