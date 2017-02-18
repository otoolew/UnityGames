using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ZombieCounter : MonoBehaviour {

    public static int zombieCount;
    Text text;

    void Awake()
    {
        text = GetComponent<Text>();
        zombieCount = 0;
    }

    void Update()
    {
        text.text = "Zombies Alive: " + zombieCount;
    }
}
