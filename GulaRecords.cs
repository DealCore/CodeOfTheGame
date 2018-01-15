using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GulaRecords : MonoBehaviour 
{

	void Start () {
		GetComponent <Text> ().text = PlayerPrefs.GetInt ("GulaRecords").ToString ();
	}
}
