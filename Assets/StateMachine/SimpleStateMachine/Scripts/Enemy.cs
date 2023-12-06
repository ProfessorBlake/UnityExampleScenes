using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
	public enum EnemyStatesEnum
	{
		Idle,
		Walking,
		Attacking,
		Dead
	}

	public EnemyStatesEnum State;
	public Transform PlayerTransform;
	public Rigidbody Rb;

	private void Update()
	{
		switch(State)
		{
			case EnemyStatesEnum.Idle:
				Update_Idle();
				break;
			case EnemyStatesEnum.Attacking:
				Update_Attacking(); 
				break;
			case EnemyStatesEnum.Walking:
			case EnemyStatesEnum.Dead:
				Debug.Log("Haven't made a state for " + State);
				break;
			default: 
				break;
		}
	}

	private void Update_Idle()
	{
		//Exit state
		if(Physics.SphereCast(transform.position, 0.25f, PlayerTransform.position - transform.position, out RaycastHit hit))
		{
			if(hit.collider.tag == "Player")
			{
				Debug.Log("Idle > Attack");
				State = EnemyStatesEnum.Attacking;
				return;
			}
		}
	}

	private void Update_Attacking()
	{
		//Exit state
		if (Physics.SphereCast(transform.position, 0.25f, PlayerTransform.position - transform.position, out RaycastHit hit))
		{
			if (hit.collider.tag != "Player")
			{
				Debug.Log("Attack > Idle");
				State = EnemyStatesEnum.Idle;
				Rb.velocity *= 0.1f;
				return;
			}
		}

		//Attack
		Rb.velocity = (PlayerTransform.position - transform.position).normalized * 5;
	}
}
