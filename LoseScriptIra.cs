using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoseScriptIra : MonoBehaviour {

	// Use this for initialization
	void Start () {
        if (PlayerPrefs.GetString("Music") != "no")
        {
            GameObject.Find("LoseSou").GetComponent<AudioSource>().Play();
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
