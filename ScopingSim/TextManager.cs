using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextManager : MonoBehaviour {
    public static string instructionText;
    public static string trainingAreaText;
    public Text text;

    private void Awake()
    {
        text.GetComponent<Text>();
    }
    void Start()
    {
        instructionText = "Welcome to level 1! \n You will need to find 10 numbers to complete the training";
        text.text = instructionText;
        StartCoroutine(FirstInstruction());
    }
    IEnumerator FirstInstruction()
    {
        yield return new WaitForSecondsRealtime(3);
        instructionText = "Drive the scope forward into the training area and find the number 12";
        trainingAreaText = "The training area is just above the clock face.";
    }
    // Update is called once per frame
    void Update()
    {
        text.text = trainingAreaText + "\n" + instructionText;
    }
    public void NextInstruction()
    {
        instructionText = "Find Number "+ClockNumber.number;
    }
    public void InTrainingArea()
    {
        trainingAreaText = "You are at the correct position";
    }
    public void OutTrainingArea()
    {
        trainingAreaText = "You are NOT in the correct position!";
    }
}
