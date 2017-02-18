using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnManager : MonoBehaviour {
    public List<Transform> spawnPos;
    public GameObject zombiePrefab;
    public int zombiesPerWave;
    public AudioSource EnemySpawnAudio;
    public AudioClip EnemySpawnClip;

    // Use this for initialization
    void Start () {
        StartCoroutine(Spawn());
    }
	
    IEnumerator Spawn()
    {
        yield return new WaitForSecondsRealtime(10f);
        WaveCounter.wave++;
        EnemySpawnAudio.Play();
        for (int i = 0; i < zombiesPerWave; i++)
        {
            foreach (Transform point in spawnPos)
            {
                
                ZombieCounter.zombieCount++;
                GameObject zombieClone = (GameObject)Instantiate(zombiePrefab, point.position, point.rotation);
                yield return new WaitForSecondsRealtime(0.5f);
            }
        }
        if (WaveCounter.wave <= 3)
        {
            StartCoroutine(Spawn());
        }else
        {
            StopCoroutine(Spawn());
        }      
            
    }
}
