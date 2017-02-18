﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class HitBox2D : MonoBehaviour {
    public enum CollisionType { ColliderVsCollider, TriggerVsCollider, TriggerVsTrigger }
    public CollisionType CollisionMode = CollisionType.TriggerVsCollider;
    [Tooltip("The cooldown time between collision events.")]
    public float Cooldown = 1f;
    public List<string> CollidesWithTags = new List<string>();
    public float MinCollisionForce = 0f;
    public UnityEvent OnHit;

    float currentCooldown = 0f;

    void Update()
    {
        if (currentCooldown > 0)
            currentCooldown -= Time.deltaTime;
    }

    public void TestHit()
    {
        Debug.Log("Test Hit.");
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (CollisionMode == CollisionType.ColliderVsCollider && currentCooldown <= 0)
        {
            for (int i = 0; i < CollidesWithTags.Count; i++)
            {
                if (col.gameObject.tag == CollidesWithTags[i])
                {
                    Debug.Log("Collision Velocity: " + col.relativeVelocity.magnitude);
                    if (col.relativeVelocity.magnitude >= MinCollisionForce)
                    {
                        currentCooldown = Cooldown;
                        OnHit.Invoke();
                    }
                }
            }
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (CollisionMode != CollisionType.ColliderVsCollider && currentCooldown <= 0)
        {
            for (int i = 0; i < CollidesWithTags.Count; i++)
            {
                if (col.gameObject.tag == CollidesWithTags[i])
                {
                    currentCooldown = Cooldown;
                    OnHit.Invoke();
                }
            }
        }
    }
}
