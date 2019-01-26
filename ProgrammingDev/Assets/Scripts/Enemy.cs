using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    public float health = 100f;
    public float damage = 10f;
    public GameObject player;
    public float hitCoolTime = 1f;

    private NavMeshAgent agent;
    private Player playerScript;
    private bool hitCooldown = false;

    // Start is called before the first frame update
    void Start()
    {
        agent = this.gameObject.GetComponent<NavMeshAgent>();
        playerScript = player.GetComponent<Player>();
    }

    private void Update()
    {
        Vector3 vec = this.gameObject.transform.position - player.transform.position;
        if (vec.magnitude >= 2.0f)
        {
            agent.SetDestination(player.transform.position);
        }
        else if (!hitCooldown) {
            playerScript.OnHit(damage);
            StartCoroutine("HitCooldown");
        }
    }

    public void OnHit(float rec_damage) {
        health -= rec_damage;
        if (health <= 0) {
            Die();
        }
    }

    void Die() {
        //TODO: Play animation
        //TODO: Play sound
    }

    IEnumerator HitCooldown() {
        hitCooldown = true;
        yield return new WaitForSeconds(hitCoolTime);
        hitCooldown = false;
    }

}
