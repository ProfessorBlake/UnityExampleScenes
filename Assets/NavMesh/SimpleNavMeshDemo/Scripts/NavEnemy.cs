using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace Game.NavMesh.Simple
{
    public class NavEnemy : MonoBehaviour
    {
        [SerializeField] private NavMeshAgent agent;
        [SerializeField] Transform target;
        [SerializeField] private Rigidbody rb;


		private void Start()
		{
            rb.isKinematic = true;
		}

		private void Update()
		{
			if (agent.enabled)
			{
				agent.SetDestination(target.position);
                
		}

		private void FixedUpdate()
        {
            if (!agent.enabled)
            {
                if(rb.velocity.magnitude <= 0)
                {
                    agent.enabled = true;
					rb.isKinematic = true;
                    rb.rotation = Quaternion.identity;
				}
            }
        }

        public void GetKnocked(Vector3 position, float power)
        {
            agent.enabled = false;
            rb.isKinematic = false;
            rb.velocity = Vector3.up;
            rb.AddExplosionForce(power, position + new Vector3(0,-1,0), 50);
        }
    }
}