using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		if (PlayerPrefs.GetString("Music") != "no")
		{
			GameObject.Find("Applause").GetComponent<AudioSource>().Play();
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
