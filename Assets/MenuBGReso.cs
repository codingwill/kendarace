using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuBGReso : MonoBehaviour
{
    GameObject thisBG;
    // Start is called before the first frame update
    void Start()
    {
        thisBG = this.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        thisBG.GetComponent<RectTransform>().sizeDelta = new Vector2(GameObject.Find("CanvasMenu").GetComponent<RectTransform>().sizeDelta.x, GameObject.Find("CanvasMenu").GetComponent<RectTransform>().sizeDelta.y);
    }
}
