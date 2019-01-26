using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordAttack : MonoBehaviour
{
    [SerializeField] private Player player;
    private float playerDamage;
    // Start is called before the first frame update
    void Start()
    {
        player = GetComponentInParent<Player>();
        playerDamage = player.damage;
    }

    private void OnCollisionStay(Collision other)
    {
        Debug.Log(other.gameObject.tag + " " + player.hitCooldown);
        if (other.gameObject.tag == "Enemy" && player.hitCooldown) {
            other.gameObject.GetComponent<Enemy>().OnHit(playerDamage);
        }
    }

    
}
