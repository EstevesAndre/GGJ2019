using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ButtonHandler : MonoBehaviour
{
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
        
    }

    public void mainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
    
}
