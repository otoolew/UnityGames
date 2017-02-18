using UnityEngine;

public class ThrowItem : MonoBehaviour {

    public GameObject grenadePrefab;
    float ammo;
    float cooldown = 0.8f;
    float semiautoRate = 2f;
    float setTime;
    public static int TotalAmmo = 1;

    void Start()
    {
        setTime = Time.time;
        //AmmoManager.grenadeTotal = TotalAmmo;
    }
    void FixedUpdate()
    {
        if (Input.GetButtonDown("Fire2") && Time.time >= cooldown && TotalAmmo > 0)
        {
            cooldown = Time.time + semiautoRate;
            ThrowObject();
        }
    }
    void ThrowObject()
    {
        setTime = Time.time-2f;
        GameObject itemClone = (GameObject)Instantiate(grenadePrefab, transform.position, transform.rotation);
        TotalAmmo -= 1;               
    }
    public void AddAmmo(int amount)
    {
        TotalAmmo += amount;
        AmmoManager.grenadeTotal += amount;
    }
    public void DecreaseAmmo(int amount)
    {
        TotalAmmo -= amount;
        AmmoManager.grenadeTotal -= amount;
    }
}
