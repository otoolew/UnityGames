using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AmmoManager : MonoBehaviour {

    public static int bulletTotal;
    public static int grenadeTotal;
    Text text;

    void Awake()
    {
        text = GetComponent<Text>();
    }

    void Update()
    {
        text.text = "Bullets: " + Weapon.TotalAmmo + "   Grenades: " + ThrowItem.TotalAmmo;
    }
}
