using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Soundtrack : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        int i = SceneManager.GetActiveScene().buildIndex;

        AudioSource m_MyAudioSource = GetComponent<AudioSource>();

        if (i == 3)
        {
            m_MyAudioSource.Stop();
        }
        else if(!m_MyAudioSource.isPlaying)
        {
            m_MyAudioSource.Play(0);
        }
    }
}
