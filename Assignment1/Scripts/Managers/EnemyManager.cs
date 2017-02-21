using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour {

    public GameObject enemy;                // The enemy prefab to be spawned.
    public float spawnTime = 5f;            // How long between each spawn.
    public Transform spawnPoint;         // An array of the spawn points this enemy can spawn from.
    public int maxEnemyCount = 5;

    void Start()
    {
        // Call the Spawn function after a delay of the spawnTime and then continue to call after the same amount of time.
        InvokeRepeating("Spawn", spawnTime, spawnTime);
    }

    void Spawn()
    {
        if (GameObject.FindGameObjectsWithTag("Enemy").Length < maxEnemyCount)       
            Instantiate(enemy, spawnPoint.position, spawnPoint.rotation);                     
    }
}
