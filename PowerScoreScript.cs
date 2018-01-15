using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PowerScoreScript : MonoBehaviour 
{

	void Start () {
        //Cle(); // принудительная очистка
		GetComponent <Text> ().text = PlayerPrefs.GetInt ("PowerScore").ToString ();
	}
    void Cle()
    {
        PlayerPrefs.SetInt("PowerScore", 0);
    }
}
