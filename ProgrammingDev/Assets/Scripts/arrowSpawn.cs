using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class arrowSpawn : MonoBehaviour
{
    [SerializeField] float spawnTime;

    public GameObject arrow;
    private int arrowsSpawned;
    public int arrowsLimit;
    public int side;
    private AudioSource war;
    public float repeatSoundTime = 60f;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Spawn", spawnTime, spawnTime);
        InvokeRepeating("PlayWarSound", spawnTime, repeatSoundTime);
    }

    void Spawn()
    {
        for (int i = 0; i < 6; i++)
        {
            if (arrowsSpawned < arrowsLimit)
            {
                int offset_z = Random.Range(-80, 80);
                int offset_y = Random.Range(-5, 5);
                int offset_x = Random.Range(-20, 40);
                arrowsSpawned++;

                Vector3 vetc = new Vector3(transform.position.x + offset_x, transform.position.y + offset_y, transform.position.z + offset_z);

                GameObject go = Instantiate(arrow, vetc, transform.rotation, this.transform);
                go.GetComponent<Arrow>().StartForce(side);
                go.GetComponent<Arrow>().sendSpawn(this);
            }
        }
    }

    public void removeOneArrow()
    {
        arrowsSpawned--;
        Debug.Log(arrowsSpawned);
    }

    public void PlayWarSound()
    {
        war = GetComponent<AudioSource>();
        war.Play(0);
    }

    // Update is called once per frame
    void Update()
    {
        if (arrowsSpawned == arrowsLimit)
        {
            CancelInvoke();
        }
    }
}
