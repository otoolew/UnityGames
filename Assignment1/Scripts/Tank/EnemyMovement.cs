using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour {

    Transform player;   // Reference to the player's position.
    EnemyHealth playerHealth;    // Reference to the player's health.
    EnemyHealth enemyHealth; // Reference to this enemy's health.
    UnityEngine.AI.NavMeshAgent nav;    // Reference to the nav mesh agent.


    void Awake()
    {
        // Set up the references.
        player = GameObject.FindGameObjectWithTag("Player").transform;
        playerHealth = player.GetComponent<EnemyHealth>();
        enemyHealth = GetComponent<EnemyHealth>();
        nav = GetComponent<UnityEngine.AI.NavMeshAgent>();
    }


    void Update()
    {    
        // set the destination of the nav mesh agent to the player.
        nav.SetDestination(player.position);              
    }
}
