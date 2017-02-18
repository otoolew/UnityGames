using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour {

    public static int kills;
    Text text;

    void Awake()
    {
        text = GetComponent<Text>();
        kills = 0;
    }

    void Update()
    {
        text.text = "Zombie Kills: " + kills;
    }
}
