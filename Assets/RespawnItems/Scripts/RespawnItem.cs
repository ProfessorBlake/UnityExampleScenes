using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RespawnItems
{
    public class RespawnItem : MonoBehaviour
    {
        [SerializeField] private float respawnDelay;

		private bool picked;

		private void OnMouseDown()
		{
            Pickup();
		}

		private void OnEnable()
		{
			transform.localScale = Vector3.one;
			picked = false;
		}

		public void Pickup()
        {
            picked = true;
        }

		private void Update()
		{
			if(picked)
			{
				transform.localScale *= (1f - (3f * Time.deltaTime));
				if (transform.localScale.x <= 0.01f)
				{
					FindObjectOfType<RespawnController>().RespawnItem(gameObject, respawnDelay);
					gameObject.SetActive(false);
				}
			}	
		}
	}
}