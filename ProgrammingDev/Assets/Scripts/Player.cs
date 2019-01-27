using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float health = 100f;
    public float damage = 10f;
    public float swingCooldown = 1f;
    public bool hitCooldown = false;

public float castleMaxHealth = 1000f;
public float castleHealth = 1000f;

    private Animator anim;
    private AudioSource swordMiss;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        swordMiss = GetComponent<AudioSource>();
        castleHealth = castleMaxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1") && !hitCooldown)
        {
            if (swordMiss.isPlaying)
            {
                swordMiss.Stop();
            }
            
            anim.SetTrigger("Attack");
            StartCoroutine("SwingCooldown");
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

    public void CastleHit(float rec_damage) {
        Debug.Log("Castle Hit");
        health -= rec_damage;
        if (health <= 0) {
            Die();              // Necessary?
        }
    }

    void Die() {
        //TODO: Play animation
        //TODO: Play sound
    }

    IEnumerator SwingCooldown() {
        hitCooldown = true;
        yield return new WaitForSeconds(swingCooldown);
        hitCooldown = false;
    }
}
