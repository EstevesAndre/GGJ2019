﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float health = 100f;
    public float damage = 10f;

    private bool hitCooldown = false;
    private Animator anim;
    private AudioSource swordMiss;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        swordMiss = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            if (swordMiss.isPlaying)
            {
                swordMiss.Stop();
            }
            
            anim.SetTrigger("Attack");
            //Debug.Log("animation called");
            swordMiss.Play(0);
        }
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
