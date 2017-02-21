using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    ParticleSystem collectEffect;
    bool collected;
    MeshRenderer mesh;
    public int coinValue = 1;
    CoinSpawn coinSpawn;
    void Awake()
    {
        coinSpawn = FindObjectOfType<CoinSpawn>();
        collectEffect = GetComponentInChildren<ParticleSystem>();      
    }

    void Start()
    {
       
    }

    void Update()
    {
        transform.Rotate(Vector3.up * Time.deltaTime * 20, Space.World);
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            transform.Rotate(Vector3.up * Time.deltaTime * 40, Space.World);
            transform.DetachChildren();
            Destroy(gameObject);
            collectEffect.Play();
            Destroy(collectEffect.gameObject, collectEffect.main.duration);
            ScoreManager.score += coinValue;
            coinSpawn.Count--;
        }
               
    }
    
}
