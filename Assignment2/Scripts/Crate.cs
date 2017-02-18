using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crate : MonoBehaviour {
    float supplyCount;
    float amountTaken = 30f;
	// Use this for initialization
	void Start () {
        supplyCount = Random.Range(10,30);
	}
}
