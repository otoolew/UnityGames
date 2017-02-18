using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour {
    public Dictionary<string,float> markedTimes = new Dictionary<string, float>();
    public Text scoreText;
    public float startTime;
    public float completionTime;
    int objectsFound = 0;
    int objectiveNumber = 1;
    string objectivesCompleted;
	// Use this for initialization
	void Start () {
        objectsFound = 0;
        startTime = Time.time;
	}
	
	// Update is called once per frame
	void Update () {
        scoreText.text = "Time: " + Time.time +"\n"+
            "Numbers Located: "+ objectsFound;

    }
    public void MarkTime()
    {
        float time = Time.fixedTime;
        string objectiveCompleted = ClockNumber.number+objectiveNumber;
        markedTimes.Add(objectiveCompleted,time);
    }
    public void IncrementObjectsFound()
    {
        objectsFound++;
    }
    public void IncrementObjective()
    {
        objectiveNumber++;
    }
}

