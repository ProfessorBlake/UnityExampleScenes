using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.NavMesh.Simple
{
	public class Player : MonoBehaviour
	{
		[Header("CharacterController")]
		[SerializeField] private CharacterController cc;
		[SerializeField] private float moveSpeed;
		[SerializeField] private float gravity = -9.8f;
		[SerializeField] private float jumpSpeed;
		private float verticalSpeed;

		[Header("Mouse Look")]
		[SerializeField] private Transform camTransform;
		[SerializeField] private float mouseSpeed;
		private float mouseLookAngle;

		private void Start()
		{
			Cursor.lockState = CursorLockMode.Locked;
		}

		private void Update()
		{
			//Mouse Look
			transform.Rotate(new Vector3(0, Input.GetAxis("Mouse X") * mouseSpeed, 0));
			mouseLookAngle -= Input.GetAxis("Mouse Y") * mouseSpeed;
			camTransform.localEulerAngles = new Vector3(Mathf.Clamp(mouseLookAngle,-90, 90), 0, 0);


			// Movement
			Vector3 movement = Vector3.zero;

			// X/Z movement
			float forwardMovement = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;
			float sideMovement = Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime;

			movement += (transform.forward * forwardMovement) + (transform.right * sideMovement);

			if (cc.isGrounded)
			{
				verticalSpeed = 0f;
				if (Input.GetKeyDown(KeyCode.Space))
				{
					verticalSpeed = jumpSpeed;
				}
			}

			verticalSpeed += (gravity * Time.deltaTime);
			movement += (transform.up * verticalSpeed * Time.deltaTime);

			cc.Move(movement);
		}
	}
}