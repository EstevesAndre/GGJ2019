using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;


public class Pause : MonoBehaviour
{
    public GameObject element;
    public GameObject camera;

    public bool paused = false;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            PauseTrigger();
        }
    }

    public void PauseTrigger()
    {
        paused = !paused;
        element.SetActive(paused);
        MouseLook cam = GameObject.Find("FPSController").GetComponent<FirstPersonController>().m_MouseLook;
        if (paused) { Time.timeScale = 0f; cam.XSensitivity = 0; cam.YSensitivity = 0; } else { Time.timeScale = 1f; cam.XSensitivity = 2; cam.YSensitivity = 2; }
    }
    
}
