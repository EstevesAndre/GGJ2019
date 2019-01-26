﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordAttack : MonoBehaviour
{
    [SerializeField] private Player player;
    private float playerDamage;
    private AudioSource swordHit;
    // Start is called before the first frame update
    void Start()
    {
        player = GetComponentInParent<Player>();
        playerDamage = player.damage;
        swordHit = GetComponent<AudioSource>();

    }

    private void OnCollisionStay(Collision other)
    {
        //Debug.Log(other.gameObject.tag);
        if (other.gameObject.tag == "Enemy") {
            if (swordHit.isPlaying)
            {
                swordHit.Stop();
            }
            other.gameObject.GetComponent<Enemy>().OnHit(playerDamage);
            swordHit.Play(0);
        }
    }

    
}
