using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordAttack : MonoBehaviour
{
    private float playerDamage;
    // Start is called before the first frame update
    void Start()
    {
        playerDamage = GetComponentInParent<Player>().damage;
    }

    private void OnCollisionEnter(Collision other)
    {
        // Debug.Log(other.gameObject.tag);
        if (other.gameObject.tag == "Enemy") {
            other.gameObject.GetComponent<Enemy>().OnHit(playerDamage);
        }
    }
}
