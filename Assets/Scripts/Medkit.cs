using System;
using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;

public class Medkit : MonoBehaviour
{
    // Start is called before the first frame update
    public int healthCount; 
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.gameObject.GetComponent<Player>().AddHealthF();
            Destroy(gameObject);
        }
        
    }
}
