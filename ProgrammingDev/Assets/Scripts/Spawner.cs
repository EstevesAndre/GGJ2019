using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject enemy;
    public float minSpawnPerSec = 0.3f;
    public float maxSpawnPerSec = 2f;
    public Transform enemyFolder;
    public Transform targetPosition;
    private bool active = true;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("SpawnEnemies");
    }

    public void stopSpawning() 
    {
        active = false;
    }

    IEnumerator SpawnEnemies() {
        while (active) {
            GameObject enemyGO = Instantiate(enemy, this.transform.position, this.transform.rotation, enemyFolder);
            enemyGO.GetComponent<Enemy>().SetTarget(targetPosition);
            yield return new WaitForSeconds(Random.Range(minSpawnPerSec, maxSpawnPerSec));
        }
    }


}
