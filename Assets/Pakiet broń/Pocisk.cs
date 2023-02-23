using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pocisk : MonoBehaviour
{
    // Start is called before the first frame update
    public float life = 3;
    void Awake()
    {
        Destroy(gameObject, life);
    }

    void OnCollisionEnter(Collision Enemy)
    {
        if (Enemy.gameObject.tag == "Enemy")
        {
            Destroy(Enemy.gameObject);
            Destroy(gameObject);
        }

    }
}
