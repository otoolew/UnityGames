using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScopeLookRay : MonoBehaviour {

    public float range = 100f;
    Ray scopeRay = new Ray();
    RaycastHit scopeHit;
    int grabableMask;
    LineRenderer scopeLine;
    public Text objectName;

    void Awake()
    {
        grabableMask = LayerMask.GetMask("Number");
        scopeLine = GetComponent<LineRenderer>();
        objectName = GetComponentInChildren<Text>();
    }

    void Update()
    {
        FindInView();
    }

    public void DisableEffects()
    {
        scopeLine.enabled = false;
    }
    public string FindInView()
    {
        string inView = "Nothing";
        scopeLine.enabled = true;
        scopeLine.SetPosition(0, transform.position);
        scopeRay.origin = transform.position;
        scopeRay.direction = transform.forward;
        if (Physics.Raycast(scopeRay, out scopeHit, range, grabableMask))
        {
            //TODO Handle GameObject Minipulation
            inView = scopeHit.collider.name;  
            Debug.Log("Object Name: " + inView);
            scopeLine.SetPosition(1, scopeHit.point);
            objectName.text = inView;
        }
        else
        {
            scopeLine.SetPosition(1, scopeRay.origin + scopeRay.direction * range);
        }
        return inView;
    }    
}
