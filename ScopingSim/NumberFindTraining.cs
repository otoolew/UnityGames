using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Number
{
    public string Name { get; set; }   
    public Quaternion Direction { get; set; }
    public Number(string name, Quaternion dir)
    {
        Name = name;
        Direction = dir;
    }
}

public class NumberFindTraining : MonoBehaviour {
    Random rand;
    bool correctDepth;
    public UnityEvent OnNumberChange;
    public UnityEvent InStagingArea;
    public UnityEvent OutStagingArea;
    public GameObject number;
    public Number[] Numbers = {
            new Number("Twelve", Quaternion.Euler(new Vector3(0, 180, 0))),
            new Number("One",Quaternion.Euler(new Vector3(0, 150, 0))),
            new Number("Two",Quaternion.Euler(new Vector3(0, 120, 0))),
            new Number("Three",Quaternion.Euler(new Vector3(0, 90, 0))),
            new Number("Four",Quaternion.Euler(new Vector3(0, 60, 0))),
            new Number("Five",Quaternion.Euler(new Vector3(0, 30, 0))),
            new Number("Six",Quaternion.Euler(new Vector3(0, 0, 0))),
            new Number("Seven",Quaternion.Euler(new Vector3(0, -30, 0))),
            new Number("Eight",Quaternion.Euler(new Vector3(0, -60, 0))),
            new Number("Nine",Quaternion.Euler(new Vector3(0, -90, 0))),
            new Number("Ten",Quaternion.Euler(new Vector3(0, -120, 0))),
            new Number("Eleven",Quaternion.Euler(new Vector3(0, -150, 0)))};

    // Use this for initialization
    void Start()
    {  
        Number startingNum = Numbers[0];
        gameObject.transform.rotation = startingNum.Direction;
    }
    public void NextNumber()
    {      
        Number newNumber = Numbers[Random.Range(0, Numbers.Length)];
        ClockNumber.number = newNumber.Name;
        gameObject.transform.rotation = newNumber.Direction;
        OnNumberChange.Invoke();
    }
    private void OnTriggerStay(Collider other)
    {
        correctDepth = true;
        InStagingArea.Invoke();
    }
    private void OnTriggerExit(Collider other)
    {
        correctDepth = false;
        OutStagingArea.Invoke();
    }

}
