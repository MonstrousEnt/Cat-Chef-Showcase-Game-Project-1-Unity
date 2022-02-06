using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LivesUI : MonoBehaviour
{
	[SerializeField] private Text LivesText;

	public void SetLives(int lives)
	{
		LivesText.text = "x " + lives.ToString();
	}
}
