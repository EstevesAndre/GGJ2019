using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    private Rigidbody rb;
    public int thrust;

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
    
    void OnCollisionEnter()
    {
        rb.velocity = Vector3.zero;
        rb.constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezeRotationZ;
    }
}
