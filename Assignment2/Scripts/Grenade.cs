using System.Collections;
using UnityEngine;

public class Grenade : MonoBehaviour
{
    public float lifetime;
    public float speed;
    Rigidbody2D rigBod;
    public enum CollisionType { ColliderVsCollider, TriggerVsCollider, TriggerVsTrigger }
    public CollisionType CollisionMode = CollisionType.TriggerVsCollider;
    CircleCollider2D circCollider;
    public LayerMask layerToHit;
    public AudioSource grenadeAudio;
    public AudioClip grenadeExplode;
    // Use this for initialization

    void Awake()
    {
        rigBod = GetComponent<Rigidbody2D>();
        circCollider = GetComponent<CircleCollider2D>();
        circCollider.enabled = false;
    }
    void Start()
    {
        rigBod.AddForce(transform.up * speed);
        StartCoroutine(Explode());
    }  
    IEnumerator Explode()
    {
        yield return new WaitForSecondsRealtime(5);
        Animator anim = GetComponent<Animator>();       
        anim.SetTrigger("Explosion");
        GetComponent<ParticleSystem>().Play();
        grenadeAudio.clip = grenadeExplode;
        grenadeAudio.Play();
        RaycastHit2D[] targetsHit = Physics2D.CircleCastAll(transform.position, 7f, transform.position, 0, layerToHit);
      
        foreach (var target in targetsHit)
        {          
            EnemyController enemy = target.collider.GetComponent<EnemyController>();
            Debug.Log("Enemy: " + enemy.tag);
            enemy.TakeDamage(100);
        }
        Destroy(gameObject, 1.5f);
    }
    
}
