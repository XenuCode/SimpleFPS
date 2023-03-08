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
        public float attackTime;
        public double lastAttack;
        public int damage;
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
        
        
        private void OnCollisionEnter(Collision collision)
        {
            lastAttack = Time.timeAsDouble;
        }

        private void OnCollisionStay(Collision collisionInfo)
        {
            if (Time.timeAsDouble - lastAttack > attackTime)
            {
                if (collisionInfo.collider.gameObject.CompareTag("Player"))
                {
                    collisionInfo.collider.gameObject.GetComponent<Player>().Damage(damage);
                    lastAttack = Time.timeAsDouble;
                }
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