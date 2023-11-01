using Game.NavMesh.Simple;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace Game.NavMesh
{
    /// <summary>
    /// Knocks nav agents off of their path
    /// </summary>
    public class NavBlast : MonoBehaviour
    {
		[SerializeField] private float power;
		[SerializeField] private float life;
		[SerializeField] private float scale;

		private void Update()
		{
			transform.localScale *= scale;
			life -= Time.deltaTime;
			if(life < 0)
			{
				Destroy(gameObject);
			}
		}

		private void OnTriggerEnter(Collider other)
		{
			NavEnemy enemy = other.GetComponent<NavEnemy>();
			if(enemy != null)
			{
				enemy.GetKnocked(transform.position, power);
			}
		}
	}
}