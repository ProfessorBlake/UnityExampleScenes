using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Movement.ParabolaPhysics
{
    /// <summary>
    /// Adapted from the code by Stephan-B: https://forum.unity.com/threads/throw-an-object-along-a-parabola.158855/
    /// </summary>
    public class Projectile : MonoBehaviour
    {
		private Rigidbody rb;
        private float targetDist = 0;
        private Vector3 velocity = Vector3.zero;
        private float time = 0;
        private float timeToTarget = 0;
        private float gravity;

		private void Awake()
		{
			rb = GetComponent<Rigidbody>();
		}

		public void Throw(Vector3 startPos, Vector3 targetPos, float angle)
		{
			Debug.DrawLine(startPos, targetPos, Color.red, 1);

			gravity = -10;
			transform.position = startPos;

			// Calculate distance to target
			targetDist = Vector3.Distance(startPos, targetPos);

			// Calculate the velocity needed to throw the object to the target at specified angle.
			float vel = targetDist / (Mathf.Sin(2 * angle * Mathf.Deg2Rad) / Mathf.Abs( gravity));

			// Extract the X  Y componenent of the velocity
			velocity.x = Mathf.Sqrt(vel) * Mathf.Cos(angle * Mathf.Deg2Rad);
			velocity.y = Mathf.Sqrt(vel) * Mathf.Sin(angle * Mathf.Deg2Rad);

			// Calculate flight time.
			timeToTarget = targetDist / velocity.x;

			// Rotate projectile to face the target.
			transform.rotation = Quaternion.LookRotation(targetPos - startPos);
			
			rb.velocity = velocity;
		}
	}
}