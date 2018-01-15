using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreFavor : MonoBehaviour 
{
	public int vi;
	public Text viF;

	void Start () {
		vi = PlayerPrefs.GetInt ("FavorScore");
		viF.text = "" + vi.ToString();
	}
}
