using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpdateScoreFavorEasy : MonoBehaviour 
{
	public int y;
	public Text yT;

	void FixedUpdate () {
		y = PlayerPrefs.GetInt("FavorScore");
		yT.text = "" + y.ToString ();
	}
}
