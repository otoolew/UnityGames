using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSpawn : MonoBehaviour {

    public GameObject coin;
    public int Count { get; set; }
    void Start()
    {
        Count = 0;
        Vector3 position = new Vector3(-45f, 2f, 45f);
        for (int col = -45; col <= 45; col+=10)
        {
            for (int row = 45; row >=-45; row-=10)
            {
                GameObject coinClone = Instantiate(coin, new Vector3(col, 2f, row), Quaternion.identity);
                Count++;
            }
        }                                                 
    }
          
}
