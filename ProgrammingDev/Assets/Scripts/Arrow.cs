using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    private Rigidbody rb;
    public int thrust;
    public int arrowDamage;

    // Start is called before the first frame update
    void Start()
    {
    }

    public void StartForce(int side)
    {
        rb = GetComponent<Rigidbody>();
        rb.AddForce(new Vector3(side, 1, 0) * thrust);
    }

    // Update is called once per frame
    void Update()
    {
        if (rb.velocity.magnitude >= 1.2)
            transform.rotation = Quaternion.LookRotation(rb.velocity, Vector3.up);
    }
    
    void OnCollisionEnter(Collision other)
    {
        rb.velocity = Vector3.zero;
        rb.constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezeRotationZ;

        if(other.gameObject.tag == "Enemy")
        {
            other.gameObject.GetComponent<Enemy>().OnHit(arrowDamage);
        }
        else if(other.gameObject.tag == "Player")
        {
            other.gameObject.GetComponent<Player>().OnHit(arrowDamage);
        }
    }
}
