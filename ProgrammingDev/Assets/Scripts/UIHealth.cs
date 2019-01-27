using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIHealth : MonoBehaviour
{

    public Image greenHealth;
    public Image redHealth;
    public Player player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        SetLife();
    }

    void SetLife() {
        redHealth.fillAmount = player.health * 0.01f;
        greenHealth.fillAmount = player.castleHealth / player.castleMaxHealth;
    }
}
