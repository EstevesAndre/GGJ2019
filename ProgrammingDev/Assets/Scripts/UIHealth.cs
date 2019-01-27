using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIHealth : MonoBehaviour
{

    public Image greenHealth;
    public Image redHealth;
    public GameObject player;
	private Player pl;

	void Start() {
		pl = player.GetComponent<Player>();
	}

    void Update()
    {
        SetLife();
    }

    void SetLife() {
        redHealth.fillAmount = pl.health * 0.01f;
        greenHealth.fillAmount = pl.castleHealth / pl.castleMaxHealth;
    }
}
