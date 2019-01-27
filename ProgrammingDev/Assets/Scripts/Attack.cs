using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    public GameObject animGO;
    private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        anim = animGO.GetComponent<Animator>();
    }

    public void DoesAttack()
    {
        anim.SetTrigger("Attack");
    }

}
