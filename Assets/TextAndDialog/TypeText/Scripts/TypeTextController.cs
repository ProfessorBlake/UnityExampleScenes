using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace Game.Text
{
	public class TypeTextController : MonoBehaviour
	{
		[SerializeField] private TMP_Text tmpText;
		[SerializeField] private float typeSpeed;

		private int typedLength = 0;
		private float nextTypeTime;
		private string textContent;

		private void Start()
		{
			ShowText("Hello! Welcome to the Type Text Example. Here you can watch as this message is typed out on your screen. Enjoy!");
		}

		private void Update()
		{
			tmpText.text = textContent.Substring(0, typedLength);
			if (typedLength >= textContent.Length)
				return;

			//Speed through text
			if (Input.GetMouseButtonDown(0) || Input.GetKey(KeyCode.Space))
			{
				nextTypeTime = (nextTypeTime + Time.time) / 2;
			}

			//Advance typedLenght
			if (Time.time >= nextTypeTime)
			{
				nextTypeTime = Time.time + typeSpeed;
				typedLength++;
			}
		}

		/// <summary>
		/// Set the typed text to a new string
		/// </summary>
		/// <param name="text">Text to display.</param>
		public void ShowText(string text)
		{
			textContent = text;
			typedLength = 0;
			nextTypeTime = Time.time + typeSpeed;
		}
	}
}