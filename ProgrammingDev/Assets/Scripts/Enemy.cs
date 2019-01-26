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
    public float rotationSpeed = 10f;

    public float hitReach = 2.0f;
    public float pursuitRange = 4.0f;

    private NavMeshAgent agent;
    private Player playerScript;
    private bool hitCooldown = false;
    private Attack swordScript;
    private Transform target;

    // Start is called before the first frame update
    void Start()
    {
        swordScript = GetComponentInChildren<Attack>();
        agent = this.gameObject.GetComponent<NavMeshAgent>();
        player = GameObject.FindGameObjectWithTag("Player");
        playerScript = player.GetComponent<Player>();
    }

    public void SetTarget(Transform _target) {
        target = _target;
    }

    private void Update()
    {
        Vector3 vec = this.gameObject.transform.position - player.transform.position;
        transform.LookAt(player.transform);

        if (vec.magnitude >= pursuitRange) {
            agent.SetDestination(target.position);
        }
        else if (vec.magnitude >= hitReach)
        {            
            agent.SetDestination(player.transform.position);
        }
        else if (!hitCooldown)
        {
            swordScript.DoesAttack();
            playerScript.OnHit(damage);
            StartCoroutine("HitCooldown");
        }
    }

    public void OnHit(float rec_damage) {
        Debug.Log("Enemy Hit for " + rec_damage + ". Initial Health: " + health);
        health -= rec_damage;
        if (health <= 0) {
            Die();
        }
    }

    void Die() {
        //TODO: Play animation
        //TODO: Play sound
        Debug.Log("Dead!");
        Destroy(gameObject);
    }

    IEnumerator HitCooldown() {
        hitCooldown = true;
        yield return new WaitForSeconds(hitCoolTime);
        hitCooldown = false;
    }

}
