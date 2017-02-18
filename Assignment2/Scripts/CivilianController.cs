using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CivilianController : MonoBehaviour {
           
    public float speed;
    Animator anim;
    Health health;

    void Awake()
    {       
        anim = GetComponent<Animator>();
        health = GetComponent<Health>();
    }
    void FixedUpdate()
    {
        if (health.curHP<=0)
        {
            StartCoroutine(health.Death());
        }       
    }   
}
