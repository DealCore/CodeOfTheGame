using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Levels : MonoBehaviour 
{
	public Text iraRecord;
	public Text avaritiaRecord;
	public Text gulaRecord;
	public Text luxuriaRecord;

	void Start()
	{
		if (PlayerPrefs.GetString ("Music") != "no") { // если не выключен звук то
			GameObject.Find ("BGAu").GetComponent<AudioSource> ().Play (); // активировать компонент под именем BGAu
		}

		/*iraRecord.text = PlayerPrefs.GetInt ("IraRecords").ToString ();
		avaritiaRecord.text = PlayerPrefs.GetInt ("AvaritiaRecords").ToString ();
		gulaRecord.text = PlayerPrefs.GetInt ("GulaRecords").ToString ();
		luxuriaRecord.text = PlayerPrefs.GetInt ("LuxuriaRecords").ToString ();*/
	}

	public void OnMouseUpAsButton ()
	{
		if (PlayerPrefs.GetString ("Music") != "no"){
			GameObject.Find("ClickSounds").GetComponent<AudioSource> ().Play ();
		}

		switch (gameObject.name) {
		case "Superbia":
			SceneManager.LoadScene ("Superbia");
			break;
		case "Invidia":
			SceneManager.LoadScene ("Invidia");
			break;
		case "Ira":
			SceneManager.LoadScene ("Ira");
			break;
		case "Acedia":
			SceneManager.LoadScene ("Acedia");
			break;
		case "Avaritia":
			SceneManager.LoadScene ("Avaritia");
			break;
		case "Gula":
			SceneManager.LoadScene ("Gula");
			break;
		case "Luxuria":
			SceneManager.LoadScene ("Luxuria");
			break;
		case "Exit":
			SceneManager.LoadScene ("mainScene");
			break;

		}
	}
}
