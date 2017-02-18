using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController: MonoBehaviour, ITakeDamage
{
    Transform target;               // Reference to the player's position.
    public float curHP;
    public float maxHP;
    public float attackDmg;
    public float speed;
    Animator anim;
    bool died = false;
    public AudioSource ZombieAudio;
    public AudioClip ZombieDeath;
    public AudioClip ZombieAttack;
    public AudioClip HospitalAttack;

    void Awake()
    {
        target = GameObject.FindGameObjectWithTag("Hospital").transform;     
        anim = GetComponent<Animator>();
    }

    void FixedUpdate()
    {        
        if (died)
        {
            anim.SetBool("IsMoving", false);
        }
        else if(!died)
        {
            anim.SetBool("IsMoving", true);
            float z = Mathf.Atan2(
                    ( target.transform.position.y - transform.position.y ),
                    ( target.transform.position.x - transform.position.x )
                  ) * Mathf.Rad2Deg - 90;

            transform.eulerAngles = new Vector3(0, 0, z);
            GetComponent<Rigidbody2D>().AddForce(gameObject.transform.up * speed);
                 
        }        
    }

    IEnumerator Death()
    {
        anim.SetTrigger("Die");
        GetComponent<BoxCollider2D>().enabled = false;
        GetComponent<CircleCollider2D>().enabled = false;
        ScoreManager.kills++;
        ZombieCounter.zombieCount--;
        ZombieAudio.clip = ZombieDeath;
        ZombieAudio.Play();
        yield return new WaitForSecondsRealtime(5);
        Destroy(gameObject);
    }

    public void TakeDamage(int amount)
    {
        curHP -= amount;
        if (curHP <= 0f)
        {
            died = true;
            StartCoroutine(Death());
        }          
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<Health>().TakeDamage(100);
            ZombieAudio.clip = ZombieAttack;
            ZombieAudio.Play();
        }
           
        if (collision.gameObject.tag == "Hospital")
        {
            InfectedManager.infected++;
            ZombieAudio.clip = HospitalAttack;
            ZombieAudio.Play();
            Destroy(gameObject,2);
        }
                                
    }
}

         
