using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooting : MonoBehaviour {
    public Rigidbody projectile;
    public Transform barrelEnd;
    public GameObject player;
    public float launchForce = 20f;
    public float range = 20f;
    bool inRange = false;
    float shotTime;
                                                
    void Awake () {
        player = GameObject.FindGameObjectWithTag("Player");
    }
	
	// Update is called once per frame
	void FixedUpdate () {
        
        inRange = Vector3.Distance(transform.position, player.transform.position) < range;
        float time = Time.time;
        if (inRange && (time > shotTime+2) && player.activeInHierarchy)
        {
            Shoot();
        }
    }
    void Shoot()
    {
        shotTime = Time.time;
        if (inRange)
        {
            Rigidbody bullet = (Rigidbody)Instantiate(projectile, barrelEnd.position, barrelEnd.rotation) as Rigidbody;
            // Set the projectile's velocity to the launch force in the fire position's forward direction.
            bullet.velocity = launchForce * barrelEnd.forward;
        }
    }
}
