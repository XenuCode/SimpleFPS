using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;

public class Pocisk : MonoBehaviour
{
    // Start is called before the first frame update
    public float life = 3;
    void Awake()
    {
        Destroy(gameObject, life);
    }

    void OnCollisionEnter(Collision enemy)
    {
        if (enemy.gameObject.CompareTag("Enemy"))
        {
            enemy.gameObject.GetComponent<TiktakScript>().Damage(40);
            Destroy(gameObject);
        }

    }
}
