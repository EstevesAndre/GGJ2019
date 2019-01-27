using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SpalshScreen : MonoBehaviour
{
    public Image blackScreen;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("DelayedScreen");
        blackScreen.CrossFadeAlpha(0.0f, 1f, false);
    }


    IEnumerator DelayedScreen()
    {
        yield return new WaitForSeconds(3f);

        Color black = blackScreen.color;
        black.a = 1;
        blackScreen.color = black;
        blackScreen.CrossFadeAlpha(0.0f, 0f, true);
        blackScreen.CrossFadeAlpha(1.0f, 1f, false);

        yield return new WaitForSeconds(1f);

        SceneManager.LoadScene("MainMenu");
    }
}
