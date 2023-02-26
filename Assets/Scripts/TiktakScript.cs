using System;
using UnityEngine;
using UnityEngine.AI;

namespace DefaultNamespace
{
    
    public class TiktakScript : UnityEngine.MonoBehaviour
    {
        private NavMeshAgent agent;
        public Transform player;
        private void Start()
        {
            agent = GetComponent<NavMeshAgent>();
            agent.destination = player.position; 
        }

        private void FixedUpdate()
        {
            agent.destination = player.position;
        }
    }
}