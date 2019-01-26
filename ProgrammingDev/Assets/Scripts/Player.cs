using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float health = 100f;
    public float damage = 10f;
    public float swingCooldown = 1f;

    public bool hitCooldown = false;
    private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1") && !hitCooldown)
        {
            anim.SetTrigger("Attack");
            StartCoroutine("SwingCooldown");
            //Debug.Log("animation called");
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

    IEnumerator SwingCooldown() {
        hitCooldown = true;
        yield return new WaitForSeconds(swingCooldown);
        hitCooldown = false;
    }
}
