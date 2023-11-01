using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FallTrigger : MonoBehaviour
{
    public enum FallBehavior { Destroy, TeleportToStart, ResetLevel}
    [SerializeField] private FallBehavior behavior;
    [SerializeField] private float triggetHeight;

	private Vector3 startPosition;

	private void Start()
	{
		startPosition = transform.position;
	}

	private void Update()
	{
		if(transform.position.y < triggetHeight)
		{
			switch(behavior)
			{
				case FallBehavior.Destroy:
					Destroy(gameObject);
					break;
				case FallBehavior.TeleportToStart:
					transform.position = startPosition; 
					break;
				case FallBehavior.ResetLevel:
					SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
					break;
			}
		}
	}
}
