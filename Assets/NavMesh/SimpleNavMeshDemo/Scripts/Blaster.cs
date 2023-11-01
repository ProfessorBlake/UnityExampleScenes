using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.NavMesh
{
	public class Blaster : MonoBehaviour
	{
		[SerializeField] private Transform cameraTransform;
		[SerializeField] private GameObject blastPrefab;

		private void Update()
		{
			if (Input.GetButtonDown("Fire1"))
			{
				if(Physics.Raycast(cameraTransform.position, cameraTransform.forward, out RaycastHit hit))
				{
					Debug.DrawLine(cameraTransform.position, hit.point);
					Instantiate(blastPrefab, hit.point, Quaternion.identity);
				}
			}
		}
	}
}