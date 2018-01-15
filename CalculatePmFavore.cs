using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CalculatePmFavore : MonoBehaviour 
{
	public int recPM;
	public int recFav;
	public GameObject erPan;
	public GameObject mainFavorPan;

	public void OnMouseUpAsButton()
	{
		recPM = PlayerPrefs.GetInt("PowerScore");
		recFav = PlayerPrefs.GetInt ("FavorScore");

		if (recFav > 7) {
			recFav -= 7;
			PlayerPrefs.SetInt ("FavorScore", recFav);

			recPM += 1;
			PlayerPrefs.SetInt ("PowerScore", recPM);
		} else {
			erPan.SetActive (true);
			mainFavorPan.SetActive (false);
		}
	}

	public void ComeBackEasyFavor()
	{
		erPan.SetActive (false);
		mainFavorPan.SetActive (true);
	}
}
