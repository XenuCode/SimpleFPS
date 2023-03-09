using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;

public class AmmoBox : MonoBehaviour
{
    // Start is called before the first frame update
    public int ammoCount;
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
            other.gameObject.GetComponentInChildren<Strzelanie>().ammoCount += 30;
            Destroy(gameObject);
        }
    }
}
