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
    public float corpseTime = 10f;

    private NavMeshAgent agent;
    private Player playerScript;
    private bool hitCooldown = false;
    // private Attack swordScript;
    private Transform target;
    private Animator anim;
    private bool dead = false;

    // Start is called before the first frame update
    void Start()
    {
        // swordScript = GetComponentInChildren<Attack>();
        agent = this.gameObject.GetComponent<NavMeshAgent>();
        player = GameObject.FindGameObjectWithTag("Player");
        playerScript = player.GetComponent<Player>();
        anim = GetComponentInChildren<Animator>();
    }

    public void SetTarget(Transform _target) {
        target = _target;
    }

    private void Update()
    {
        if (dead) return;
        Vector3 vec = this.gameObject.transform.position - player.transform.position;
        Vector3 vecGate = transform.position - target.position;
        // transform.LookAt(player.transform);

        if (vec.magnitude >= pursuitRange) {
            if (vecGate.magnitude >= hitReach)
                agent.SetDestination(target.position);
            else {
                anim.SetTrigger("Melee");
                //TODO: damage the walls
            }
        }
        else if (vec.magnitude >= hitReach)
        {            
            agent.SetDestination(player.transform.position);
        }
        else if (!hitCooldown)
        {
            anim.SetTrigger("Melee");
            // swordScript.DoesAttack();
            playerScript.OnHit(damage);
            StartCoroutine("HitCooldown");
        }
    }

    public void OnHit(float rec_damage) {
        Debug.Log("Enemy Hit for " + rec_damage + ". Initial Health: " + health);
        health -= rec_damage;
        if (health <= 0) {
            Die();
        } else {
            //TODO: got hit but not dead animation.
        }
    }

    void Die() {
        anim.SetTrigger("Death");
        //TODO: Play sound
        Debug.Log("Dead!");
        dead = true;
        Rigidbody dead_rb = GetComponent<Rigidbody>();
        dead_rb.velocity = Vector3.zero;
        dead_rb.angularVelocity = Vector3.zero;
        GetComponent<NavMeshAgent>().enabled = false;
        GetComponent<CapsuleCollider>().enabled = false;
        StartCoroutine("CorpseVanish");
    }

    IEnumerator HitCooldown() {
        hitCooldown = true;
        yield return new WaitForSeconds(hitCoolTime);
        hitCooldown = false;
    }

    IEnumerator CorpseVanish() {
        yield return new WaitForSeconds(corpseTime);
        Destroy(gameObject);
    }
}
