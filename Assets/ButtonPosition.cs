using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonPosition : MonoBehaviour
{
    RectTransform button;
    public RectTransform otherButton;
    private float jarakUI;
    // Start is called before the first frame update
    void Start()
    {
        button = this.GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void Update()
    {
        jarakUI = (otherButton.GetComponent<RectTransform>().sizeDelta.x * 1.15f) + Screen.width * 0.066f;
        button.transform.position = new Vector3(button.transform.position.x , Screen.height - otherButton.transform.position.x , button.transform.position.z);
    }
}
