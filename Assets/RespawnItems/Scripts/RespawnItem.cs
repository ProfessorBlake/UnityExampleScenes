using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RespawnItems
{
    public class RespawnItem : MonoBehaviour
    {
        [SerializeField] private float respawnDelay;

		private void OnMouseDown()
		{
            Pickup();
		}

		public void Pickup()
        {
            FindObjectOfType<RespawnController>().RespawnItem(gameObject, respawnDelay);
            gameObject.SetActive(false);
        }
    }
}