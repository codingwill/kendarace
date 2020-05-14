using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseButtonPos : MonoBehaviour
{
    RectTransform button;
    // Start is called before the first frame update
    void Start()
    {
        button = this.GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void Update()
    {
        button.transform.position = new Vector3(button.transform.position.x, Screen.height - button.transform.position.x, button.transform.position.z);
    }
}
