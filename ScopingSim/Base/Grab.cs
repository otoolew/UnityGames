using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grab : MonoBehaviour {
  
    public float range = 100f;
    Ray scopeRay = new Ray();
    RaycastHit scopeHit;
    int grabableMask;
    LineRenderer scopeLine;

    void Awake()
    {     
        grabableMask = LayerMask.GetMask("Grabable");
        scopeLine = GetComponent<LineRenderer>();
    }

    void Update()
    {        
        if (Input.GetButton("Fire1"))
        {           
            GrabObj();
        }      
    }

    public void DisableEffects()
    {       
        scopeLine.enabled = false;
    }

    void GrabObj()
    {       
        scopeLine.enabled = true;
        scopeLine.SetPosition(0, transform.position);      
        scopeRay.origin = transform.position;
        scopeRay.direction = transform.forward;
        if (Physics.Raycast(scopeRay, out scopeHit, range, grabableMask))
        {
            //TODO Handle GameObject Minipulation
            string forignObj = scopeHit.collider.name;
            // Try and find an EnemyHealth script on the gameobject hit.
            //Health enemyHealth = attackHit.collider.GetComponent<Health>();
            ////Debug.Log("EnemyHealth: " + enemyHealth);
            //// If the EnemyHealth component exist...
            //if (enemyHealth != null)
            //{
            //    // ... the enemy should take damage.
            //    enemyHealth.TakeDamage(damagePerHit, attackHit.point);
            //}
            Debug.Log("Object Name: "+ forignObj);
            scopeLine.SetPosition(1, scopeHit.point);
        }       
        else
        {          
            scopeLine.SetPosition(1, scopeRay.origin + scopeRay.direction * range);
        }
    }
}
