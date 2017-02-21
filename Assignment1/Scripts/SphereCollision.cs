using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereCollision : MonoBehaviour {

    public Collider[] colliders;
    public float radius = 2f;   
    bool collision;

    void LateUpdate()
    {
        colliders = Physics.OverlapSphere(transform.position, radius);
        foreach (Collider col in colliders)
        {
            // The code block below was commented out, but remains useful if you want to handle it a differnt way.
            if (col.gameObject.CompareTag("Wall"))
            {
                Debug.Log("Hit a Wall!");
                Destroy(gameObject);
            }            
        }
    }
}
