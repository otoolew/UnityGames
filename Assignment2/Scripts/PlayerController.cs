using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour, IMove {
    public float speed;
    private Vector3 mouse_pos;
    private Vector3 object_pos;
    private float angle;
    public Animator anim;
    Health health;
    public static bool dead;
    public AudioSource SurvivorAudio;
    public AudioClip SurvivorDies;

    void Awake()
    {   
        anim =  GetComponentInChildren<Animator>();
        health = GetComponent<Health>();
    }
    void Update()
    {

    }
    void FixedUpdate()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        if (!Dead())
        {            
            Move(h, v);
            Turning();
            Animating(h, v);
        }
        if (Dead())
        {
            dead = true;
        }             
    }

    public void Move(float h, float v)
    {
        Vector2 movement = new Vector2(h, v);


        GetComponent<Rigidbody2D>().velocity = movement * speed;
        GetComponent<Rigidbody2D>().position = new Vector2
        (
            GetComponent<Rigidbody2D>().position.x,
            GetComponent<Rigidbody2D>().position.y
        );
    }

    void Turning()
    {
        mouse_pos = Input.mousePosition;
        mouse_pos.z = -20;
        object_pos = Camera.main.WorldToScreenPoint(transform.position);
        mouse_pos.x = mouse_pos.x - object_pos.x;
        mouse_pos.y = mouse_pos.y - object_pos.y;
        angle = Mathf.Atan2(mouse_pos.y, mouse_pos.x) * Mathf.Rad2Deg + -90;
        transform.rotation = Quaternion.Euler(0, 0, angle);
    }
    
    void Animating(float h, float v)
    {
        // Create a boolean that is true if either of the input axes is non-zero.
        bool moving = h != 0f || v != 0f;

        // Tell the animator whether or not the player is walking.
        anim.SetBool("IsMoving", moving);
    }

    public bool Dead()
    {
        if (health.curHP <= 0)
        {
            SurvivorAudio.clip = SurvivorDies;
            SurvivorAudio.Play();
            return true;
        }
        else
        {
            return false;
        }
    }

}
