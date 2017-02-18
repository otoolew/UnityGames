using UnityEngine;
using System.Collections;
using System;
using UnityEngine.UI;

public class Weapon : MonoBehaviour, IShoot
{
    public float FireRate = 0.2f;
    public int Damage = 10;
    public LayerMask whatToHit;
    public Transform HitPrefab;
    float timeToSpawnEffect = 0;
    public float effectSpawnRate = 10;
    float cooldown = 0.8f;
    float semiautoRate = 0.45f;
    Transform firePoint;
    public static int TotalAmmo = 120;
    public int weaponMagazineSize = 10;
    public int ammoInMagazine = 10;
    public AudioSource playerAudio;
    public AudioClip gunShotAudio;
    public AudioClip emptyAudio;
    public AudioClip reloadAudio;

    // Use this for initialization
    void Awake()
    {
        firePoint = transform.FindChild("FirePoint");

        if (firePoint == null)
        {
            Debug.LogError("No firePoint");
        }

    }

    void Update()
    {
        if (Input.GetButtonDown("Fire1") && Time.time >= cooldown && ammoInMagazine>0)
        {
            cooldown = Time.time + semiautoRate;
            Shoot();
        }

        if (Input.GetButtonDown("Fire1") && Time.time >= cooldown && ammoInMagazine <= 0)
        {
            DryFire();
        }
        
        if (Input.GetButtonDown("Reload")&& TotalAmmo>0)
        {
            Reload();
        }
    }

    void Effect(Vector3 hitPos, Vector3 hitNormal)
    {
        Transform trail = Instantiate(HitPrefab, firePoint.position, firePoint.rotation) as Transform;
        LineRenderer lr = trail.GetComponent<LineRenderer>();
        if (lr != null)
        {
            lr.SetPosition(0, firePoint.position);
            lr.SetPosition(1, hitPos);
        }
        Destroy(trail.gameObject, 0.05f);

        if (hitNormal != new Vector3(9999, 9999, 9999))
        {
            Transform hitParticle = Instantiate(HitPrefab, hitPos, Quaternion.FromToRotation(Vector3.right, hitNormal)) as Transform;
            Destroy(hitParticle.gameObject, 1f);
        }
    }
    public void Reload()
    {
        TotalAmmo -= 10;
        ammoInMagazine = 10;
        playerAudio.clip = reloadAudio;
        playerAudio.Play();
    }
    public void Shoot()
    {
        Vector2 mousePosition = new Vector2(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y);
        Vector2 firePointPosition = new Vector2(firePoint.position.x, firePoint.position.y);
        RaycastHit2D hit = Physics2D.Raycast(firePointPosition, mousePosition - firePointPosition, 100, whatToHit); //Add weapon range here

        if (Time.time >= timeToSpawnEffect && ammoInMagazine > 0)
        {
            Vector3 hitPos;
            Vector3 hitNormal;

            if (hit.collider == null)
            {
                hitPos = ( mousePosition - firePointPosition ) * 50;
                hitNormal = new Vector3(9999, 9999, 9999);
            }
            else
            {
                hitPos = hit.point;
                hitNormal = hit.normal;
                EnemyController enemyHealth = hit.collider.GetComponent<EnemyController>();
                if (enemyHealth != null)
                {
                    enemyHealth.TakeDamage(Damage);
                }
            }

            Effect(hitPos, hitNormal);
            timeToSpawnEffect = Time.time + 1 / effectSpawnRate;
            ammoInMagazine--;
            AmmoManager.bulletTotal--;
            playerAudio.clip = gunShotAudio;
            playerAudio.Play();

        }
    }
    void DryFire()
    {
        playerAudio.clip = emptyAudio;
        playerAudio.Play();
    }
    public void AddAmmo(int amount)
    {
        TotalAmmo += amount;
        AmmoManager.bulletTotal += amount;
    }
    public void DecreaseAmmo(int amount)
    {
        TotalAmmo -= amount;
        AmmoManager.bulletTotal -= amount;
    }
}

