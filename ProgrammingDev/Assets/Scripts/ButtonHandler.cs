using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityStandardAssets.Characters.FirstPerson;

public class ButtonHandler : MonoBehaviour
{
    public Image blackScreen;
    public GameObject Element;

    public void quit()
    {
        Application.Quit();
    }

    public void play()
    {
        SceneManager.LoadScene("Pause_Menu_Level");
    }

    public void resume()
    {
        bool paused = GameObject.Find("Pause Menu").GetComponent<Pause>().paused;
        paused = !paused;
        GameObject.Find("Pause Menu").GetComponent<Pause>().paused = paused;
        Element.SetActive(paused);
        MouseLook cam = GameObject.Find("FPSController").GetComponent<FirstPersonController>().m_MouseLook;
        if (paused) { Time.timeScale = 0f; cam.XSensitivity = 0; cam.YSensitivity = 0; } else { Time.timeScale = 1f; cam.XSensitivity = 2; cam.YSensitivity = 2; }
    }

    public void credits()
    {
        StartCoroutine("DelayedCredits");
        Color black = blackScreen.color;
        black.a = 1;
        blackScreen.color = black;
        blackScreen.CrossFadeAlpha(0.0f, 0f, true);
        blackScreen.CrossFadeAlpha(1.0f, 2f, false);
    }

    public void mainMenu()
    {
        StartCoroutine("DelayedMainMenu");
        MouseLook cam = GameObject.Find("FPSController").GetComponent<FirstPersonController>().m_MouseLook;
        Time.timeScale = 1f;
        cam.XSensitivity = 2; cam.YSensitivity = 2; cam.lockCursor = false;
        Color black = blackScreen.color;
        black.a = 1;
        blackScreen.color = black;
        blackScreen.CrossFadeAlpha(0.0f, 0f, true);
        blackScreen.CrossFadeAlpha(1.0f, 2f, false);
    }

    IEnumerator DelayedCredits()
    {
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene("Credits");
    }

    IEnumerator DelayedMainMenu()
    {
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene("MainMenu");
    }
}
