using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LuxuriaRecords : MonoBehaviour 
{
	
	void Start () {
		GetComponent <Text> ().text = PlayerPrefs.GetInt ("LuxuriaRecords").ToString ();
	}
}
