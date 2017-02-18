using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUDManagerUI : MonoBehaviour {
    [Header("UIs")]
    public Text instructionsUI;
    public Text statsUI;

	// Use this for initialization
	void Start () {

    }
	
	// Update is called once per frame
	void Update () {
		
	}
    public void ChangeInstructionsText(string change) 
    {
        instructionsUI.text = change;
    }
    public void ChangeStatsText(Text change)
    {
        statsUI = change;
    }
}
