using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ButtonHandler : MonoBehaviour
{
    public Image blackScreen;

    public void quit()
    {
        Application.Quit();
    }

    public void play()
    {
        SceneManager.LoadScene("Level_teste_Sa");
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
