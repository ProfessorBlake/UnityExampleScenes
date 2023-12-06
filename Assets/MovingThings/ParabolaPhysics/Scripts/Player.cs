using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Movement.ParabolaPhysics
{
    public class Player : MonoBehaviour
    {
        [SerializeField] private Transform camTransform;
        [SerializeField] private Projectile projectilePrefab;

		private void Update()
		{
			if (Input.GetMouseButtonDown(0))
			{
				Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
				RaycastHit hit;
				if (Physics.Raycast(ray, out hit))
				{
					Debug.DrawLine(camTransform.position, hit.point, Color.magenta, 3);
					Projectile newProjectile = Instantiate(projectilePrefab, transform.position, Quaternion.identity);
					newProjectile.Throw(transform.position, hit.point, 45);
				}
			}

			//transform.Rotate(transform.up, Input.GetAxis("Mouse X"));
			//camTransform.localEulerAngles += new Vector3(Input.GetAxis("Mouse Y"), 0, 0);
		}
	}
}