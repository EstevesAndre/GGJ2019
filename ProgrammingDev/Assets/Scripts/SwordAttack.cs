using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordAttack : MonoBehaviour
{
    private float playerDamage;
    private AudioSource swordHit;
    // Start is called before the first frame update
    void Start()
    {
        playerDamage = GetComponentInParent<Player>().damage;
        swordHit = GetComponent<AudioSource>();

    }

    private void OnCollisionEnter(Collision other)
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
