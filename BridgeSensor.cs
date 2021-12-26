using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Collider))]
public class BridgeSensor : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.transform.name == "viking")
        {
            Debug.Log("viking enter");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.transform.name == "viking")
        {
            Debug.Log("viking exit");
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
