using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InfectedManager : MonoBehaviour {

    public static int infected;
    Text text;

    void Awake()
    {
        text = GetComponent<Text>();
        infected = 0;
    }

    void Update()
    {
        text.text = "Infected Patients: " + infected;
    }
}
