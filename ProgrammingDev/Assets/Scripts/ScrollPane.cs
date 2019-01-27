using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScrollPane : MonoBehaviour
{
    public Text pane;
    public float inc;

    // Update is called once per frame
    void Update()
    {
        pane.transform.Translate(0f,inc, 0f);
    }
}
