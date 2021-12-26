using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class CoinSpawner : MonoBehaviour
{
    public GameObject Coin;   
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter(Collider c)
    {
        FloorSpawner.sc += 1;
        Destroy(this.Coin);
    }
}
