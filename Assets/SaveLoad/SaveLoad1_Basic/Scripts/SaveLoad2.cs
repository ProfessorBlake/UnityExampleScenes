using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveLoad2 : MonoBehaviour
{
    private int gold;
    private float distanceWalked;

	private void Start()
	{
		LoadPlayer();
	}

	private void LoadPlayer()
	{
		if (PlayerPrefs.HasKey("position"))
		{
			//Load position ("1,2,3")
			string savedPosition = PlayerPrefs.GetString("position", "0,0,0");
			string[] parsedPosition = savedPosition.Split(',');
			transform.position = new Vector3(
				int.Parse(parsedPosition[0]),
				int.Parse(parsedPosition[1]),
				int.Parse(parsedPosition[2]));

			//Load gold
			gold = PlayerPrefs.GetInt("gold", 0);

			//Load XP
			distanceWalked = PlayerPrefs.GetFloat("walked", 0);
		}
	}

	private void SavePlayer()
	{
		//Save position ("x,y,z")
		PlayerPrefs.SetString("position",
			$"{transform.position.x},{transform.position.y},{transform.position.z}");


	}
}
