using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Advertisements;

public class AvaritiaScript : MonoBehaviour
{
	public int mainMoney;
	public int yIn;
	public int rez;

	public int ran;
	public int ranImg;
	public Text ranText;
	public Text ranText2;

	public GameObject ak1;
	public GameObject ak2;
	public GameObject ak3;
	public GameObject ak4;
	public GameObject ak5;
	public GameObject ak6;
	public GameObject ak7;
	public GameObject ak8;
	public GameObject ak9;
	public GameObject ak10;
	public GameObject ak11;
	public GameObject ak12;
	public GameObject ak13;
	public GameObject ak14;
	public GameObject ak15;
	public GameObject ak16;

	public GameObject mainAvaritia;
	public GameObject firstAvaritia;
	public GameObject loseAvaritia;
	public GameObject winAvaritia;

	public Text forRezult;
	public Text forRezultLose;

	public Text timeBox;
	public Text quantity;

	public float yTio;

	public int tyU;

	public static int avvL = 0; // переменная для подсчёта количества раз, сколько игрок проиграл
	public static int avvW = 0; // переменная для подсчёта количества раз, сколько игрок выиграл
	private string gameId = "1613948"; // переменная gameId содержит id игры для доступа к рекламе

	public bool helpB = false;

	void Start()
	{

		if (Advertisement.isSupported) { // если реклама поддерживается то
			Advertisement.Initialize (gameId, false); // установить заранее рекламу для последующего показа
		} else { // иначе
			Debug.Log("Platform is not supported"); // вывести в консоль строку
		}

		mainAvaritia.SetActive (false);
		firstAvaritia.SetActive (true);
		loseAvaritia.SetActive (false);
		winAvaritia.SetActive (false);
		mainMoney = 100;
		ranText2.text = mainMoney.ToString() + " $";
		Akses();
		OnMouseUpAsButton ();
	}

	void FixedUpdate()
	{
		TimeDetected ();
	}

	void TimeDetected()
	{
		if (helpB == true) {
			if (yTio < 10) {
				yTio += Time.deltaTime;
				timeBox.text = "sec 10/ " + yTio.ToString ("f2");
				quantity.text = "4/ " + yIn.ToString();
			} else {
				if (mainMoney < 50 || yIn < 4) {
					if (PlayerPrefs.GetString ("Music") != "no") {
						GameObject.Find ("loseSoundAvaritia").GetComponent<AudioSource> ().Play ();
					}
					forRezultLose.text = "" + mainMoney.ToString ();
					tyU = PlayerPrefs.GetInt ("PowerScore");
					tyU--;
					PlayerPrefs.SetInt ("PowerScore", tyU);

					mainAvaritia.SetActive (false);
					loseAvaritia.SetActive (true);
					winAvaritia.SetActive (false);
					helpB = false;

					avvL++; // переменная для подсчёта количества раз выигранных игр
					/*if (Advertisement.IsReady () && avvL % 3 == 0) { // если реклама готова и игрок проиграл 3 раза то
						Advertisement.Show (); // показать рекламу
					}*/
					if (Advertisement.IsReady () && avvL % 3 == 0) {
						Advertisement.Show ("rewardedVideo", new ShowOptions(){resultCallback = HandleAdResult});
					}

				} else if (mainMoney >= 50 || yIn >= 4){
					if (PlayerPrefs.GetString ("Music") != "no") {
						GameObject.Find ("winAvaritia").GetComponent<AudioSource> ().Play ();
					}
                    if (PlayerPrefs.GetInt("AvaritiaRecords") <= mainMoney) {
                        PlayerPrefs.SetInt("AvaritiaRecords", mainMoney);
                    }
					tyU = PlayerPrefs.GetInt ("PowerScore");
					tyU++;
					PlayerPrefs.SetInt ("PowerScore", tyU);

					forRezult.text = "" + mainMoney.ToString ();
					mainAvaritia.SetActive (false);
					loseAvaritia.SetActive (false);
					winAvaritia.SetActive (true);
					helpB = false;

					avvW++; // переменная для подсчёта количества раз выигранных игр
					/*if (Advertisement.IsReady () && avvW % 3 == 0) { // если реклама готова и игрок выиграл 3 раза то
						Advertisement.Show (); // показать рекламу
					}*/
					if (Advertisement.IsReady () && avvW % 3 == 0) {
						Advertisement.Show ("rewardedVideo", new ShowOptions(){resultCallback = HandleAdResult});
					}
				}
			}
		}
	}
	private void HandleAdResult(ShowResult result)
	{
		switch (result) {
		case ShowResult.Finished:
			Debug.Log ("Player Gains +5 gems");
			break;
		case ShowResult.Skipped:
			Debug.Log ("Player did not fully watch the ad");
			break;
		case ShowResult.Failed:
			Debug.Log ("Player failed to launch the ad? Internet?");
			break;
		}
	}


	public void NextMain()
	{
		if (PlayerPrefs.GetString ("Music") != "no") {
			GameObject.Find ("Buying").GetComponent<AudioSource> ().Play ();
		}
		mainAvaritia.SetActive (true);
		firstAvaritia.SetActive (false);
		loseAvaritia.SetActive (false);
		winAvaritia.SetActive (false);
		helpB = true;
	}

	public void Detect()
	{
		if (yIn >= 4) {
			//loseAravitia.SetActive (true);
		} else if (yIn < 4) {
			//winAravitia.SetActive (true);
			yIn++;
			mainMoney -= ran;
			ranText2.text = mainMoney.ToString() + " $";
		}
		OnMouseUpAsButton ();
	}

	public void ExitAvaritiaToLevels()
	{
		SceneManager.LoadScene ("Levels");
	}

	public void OnMouseUpAsButton()
	{
		if (PlayerPrefs.GetString ("Music") != "no") {
			GameObject.Find ("nextAvaritia").GetComponent<AudioSource> ().Play ();
		}
		DisImg(); // setActive(false);
		ran = Random.Range(5, 26);
		ranImg = Random.Range(0, 16);
		ranText.text = ran.ToString() + "$";

		switch (ranImg) {
		case 0:
			ak1.SetActive(true);
			break;
		case 1:
			ak2.SetActive(true);
			break;
		case 2:
			ak3.SetActive(true);
			break;
		case 3:
			ak4.SetActive(true);
			break;
		case 4:
			ak5.SetActive(true);
			break;
		case 5:
			ak6.SetActive(true);
			break;
		case 6:
			ak7.SetActive(true);
			break;
		case 7:
			ak8.SetActive(true);
			break;
		case 8:
			ak9.SetActive(true);
			break;
		case 9:
			ak10.SetActive(true);
			break;
		case 10:
			ak11.SetActive (true);
			break;
		case 11:
			ak12.SetActive (true);
			break;
		case 12:
			ak13.SetActive (true);
			break;
		case 13:
			ak14.SetActive (true);
			break;
		case 14:
			ak15.SetActive (true);
			break;
		case 15:
			ak16.SetActive (true);
			break;
		}
	}
	void DisImg()
	{
		ak1.SetActive(false);
		ak2.SetActive(false);
		ak3.SetActive(false);
		ak4.SetActive(false);
		ak5.SetActive(false);
		ak6.SetActive(false);
		ak7.SetActive(false);
		ak8.SetActive(false);
		ak9.SetActive(false);
		ak10.SetActive(false);
		ak11.SetActive (false);
		ak12.SetActive (false);
		ak13.SetActive (false);
		ak14.SetActive (false);
		ak15.SetActive (false);
		ak16.SetActive (false);
	}
	void Akses()
	{
		List<GameObject> aks = new List<GameObject>() { ak1, ak2, ak3, ak4, ak5, ak6, ak7, ak8, ak9, ak10, ak11, ak12, ak13, ak14, ak15, ak16};
	}
}