using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    Transform target, camera;
    private Vector3 pos;
    // Start is called before the first frame update
    void Awake()
    {
        camera = this.GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        target = GameObject.Find("badan").GetComponent<Transform>();
        pos = target.position;
        camera.position = new Vector3(pos.x + 3.0f, pos.y + 1.5f, -10.0f);
    }
}
