using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RespawnItems
{
    public class RespawnController : MonoBehaviour
    {
        public struct DelayedItem
        {
            public GameObject Item;
            public float RespawnTime;
        }

        private List<DelayedItem> items = new List<DelayedItem>();

		private void Update()
		{
			for (int i = 0; i < items.Count; i++)
            {
                //Respawn
                if (items[i].RespawnTime <= Time.time)
                {
                    items[i].Item.SetActive(true);
                    items.RemoveAt(i);
                }
            }
		}

        /// <summary>
        /// Respawns an item after delay.
        /// </summary>
        /// <param name="item">GameObject to respawn.</param>
        /// <param name="delay">Time before item respawns.</param>
		public void RespawnItem(GameObject item, float delay)
        {
            DelayedItem newDelayeditem = new DelayedItem()
            {
                Item = item,
                RespawnTime = Time.time + delay
            };
            items.Add(newDelayeditem);
        }
    }
}