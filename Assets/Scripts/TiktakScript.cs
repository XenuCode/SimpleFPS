using System;
using System.Collections;
using UnityEngine;
using UnityEngine.AI;

namespace DefaultNamespace
{
    
    public class TiktakScript : MonoBehaviour
    {
        private NavMeshAgent agent;
        public Transform player;
        public int health=100;
        private void Start()
        {
            agent = GetComponent<NavMeshAgent>();
            agent.destination = player.position;
        }

        IEnumerator GoToPlayer()
        {
            while (true)
            {
                agent.destination = player.position;
                yield return new WaitForSeconds(0.6f);
            }
        } 
        public void Damage(int damage)
        {
            health -= damage;
            if (health<=0)
            {
                Death();    
            }
        }

        private void FixedUpdate()
        {
            agent.destination = player.position;
        }

        public void HeadShot(int damage)
        {
            Damage(damage);
        }

        private void Death()
        {
            Destroy(gameObject);
        }
        
        
    }
}