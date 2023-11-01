using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.SaveLoad
{
    public class Save2 : MonoBehaviour
    {
        public string PlayerName;
        public int Gold;

        private void Update()
        {
            if(Input.GetKeyDown(KeyCode.S))
            {
                Debug.Log("Saving data");
                PlayerPrefs.SetString("name", PlayerName);
                PlayerPrefs.SetInt("gold", Gold);
            }

            if(Input.GetKeyDown(KeyCode.L))
            {
                Debug.Log("Loading data");
                PlayerName = PlayerPrefs.GetString("name", "New Player");
                Gold = PlayerPrefs.GetInt("gold", 0);
            }
        }
    }
}
