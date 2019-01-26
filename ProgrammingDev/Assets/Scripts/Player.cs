using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float health = 100f;
    public float damage = 10f;
    private bool hitCooldown = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnHit(float rec_damage) {
        Debug.Log("Hit");
        health -= rec_damage;
        if (health <= 0) {
            Die();
        }
    }

    void Die() {
        //TODO: Play animation
        //TODO: Play sound
    }
}
