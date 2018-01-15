using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Advertisements;

public class Mamo : MonoBehaviour 
{
	public int tot; // переменная для отображения счёта
	public Text tText; // перменная для получения дотупа к текстовому обьекту
	public GameObject pl; // переменная для взаимодействия с панелью проигрыша
	public GameObject pl2; // переменная для взаимодействия с панелью выигрыша
	public GameObject  main; // взаимодействие с главной частью уровня

	public Text hiJ; // переменная для доступа к текстовому обьекту

	public Text speedRe; // переменная для доступа к текстовому обьекту ждя отображения зтраченного времени игроком
	public float sP; // переменная для реализации подсчёта реакции игрока
	public float spHelp;
	public bool spTF;

	public GameObject pik; // переменная для для доступа к пике
	public GameObject bub; // переменная для доступа к бубе
	public GameObject tre; // переменная для доступа к трефе
	public GameObject che; // переменная для доступа к чирве

	public GameObject panelLose;
	public GameObject panelWin;
	public GameObject mainIraPan;
	public GameObject firstPanIra;

	private string gameId = "1613948"; // id игры для доступа к показу рекламы

	public Text forRezultLose;
	public Text forRezultWin;

	public float lot; // переменная для реализации таймера

	public int u; // переменная для реализации таймера
	public int tyPo;
	public static int advL = 0; // переменная для отсчёта количество раз проигрышей
	public static int advW = 0; // переменная для отсчёта количества раз выигрышей

	void Start() // функция выполняется только при старте
	{

		if (Advertisement.isSupported) { // если реклама поддерживается то
			Advertisement.Initialize (gameId, false); // инициализировать рекламу
		} else { // иначе
			Debug.Log ("Platform is not supported"); // вывести строку в консоле
		}

		firstPanIra.SetActive (true);
		panelLose.SetActive (false);
		panelWin.SetActive (false);
		mainIraPan.SetActive (false);
		lot = 32; // присваивание изначальной велечены таймеру
		spTF = false;
	}

	void Update() // функция выполняется постоянно
	{
		if (lot > 0) {  // если время не вышло то
			lot -= Time.deltaTime; // отнять какуюто величину
		} else { // иначе
			if (tot < 50){
				//RulMain (); // выключение экрана игры
				//T (); //вызвать метод проигрыша
				forRezultLose.text = "" + tot.ToString();
				panelLose.SetActive(true);
				mainIraPan.SetActive (false);
				firstPanIra.SetActive (false);
				panelWin.SetActive (false);

				advL++; // инкрементировать переменную для подсчёта проигрышей
				/*if (Advertisement.IsReady () && advL % 3 == 0) { // если реклама готова и игрок проиграл 3 раза то
					Advertisement.Show (); // показ рекламы
				}*/
				if (Advertisement.IsReady () && advL % 3 == 0) { // если реклама готова и игрок 3 раза проиграл то
					Advertisement.Show ("rewardedVideo", new ShowOptions(){resultCallback = HandleAdResult});
				}

				tyPo = PlayerPrefs.GetInt("PowerScore");
				tyPo--;
				PlayerPrefs.SetInt ("PowerScore", tyPo); // 

			}else {
				//RulMain (); // выключение главного экрана уровня
				//G (); // вызвать метод выигрыша
				forRezultWin.text = "" + tot.ToString();
				panelWin.SetActive(true);
				panelLose.SetActive (false);
				firstPanIra.SetActive (false);
				mainIraPan.SetActive (false);

				advW++; // переменная для подсчёта количества выиграшей
				/*if (Advertisement.IsReady () && advW % 3 == 0) { // если реклама готова к показу и игрок выиграл 3 раза то
					Advertisement.Show (); // показать рекламу
				}*/
				if (Advertisement.IsReady () && advL % 3 == 0) {
					Advertisement.Show ("rewardedVideo", new ShowOptions(){resultCallback = HandleAdResult});
				}

				if (PlayerPrefs.GetInt ("IraRecords") <= tot) {
					PlayerPrefs.SetInt ("IraRecords", tot);
				}

				tyPo = PlayerPrefs.GetInt ("PowerScore");
				tyPo++;
				PlayerPrefs.SetInt ("PowerScore", tyPo);
			}
		}
		MetHiJ (); // запуск метода отображения оставшегося времени
		STime(); // метод для подсчёта затраченного времени игроком
	}

	private void HandleAdResult(ShowResult result) // метод експеримент
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

	public void NextHex()
	{
		firstPanIra.SetActive (false);
		mainIraPan.SetActive (true);
		panelLose.SetActive (false);
		panelWin.SetActive (false);
		Mm ();
	}

	public void ExitIraToLevels()
	{
		SceneManager.LoadScene ("Levels");
	}

	void Mm()
	{
		if (PlayerPrefs.GetString ("Music") != "no") {
			GameObject.Find ("BGmusic").GetComponent<AudioSource> ().Play ();
			GameObject.Find ("soundsDemon").GetComponent<AudioSource> ().Play ();
		}
	}

	public void Uu() // метод для реализации случайно появляющихся мастей
	{
		u = Random.Range (0, 4); // в переменную u помещается рандомное число
		switch (u) { // использование оператора switch
		case 0: // если 0
			pik.SetActive (true);
			bub.SetActive (false);
			tre.SetActive (false);
			che.SetActive (false);
			break;
		case 1:
			pik.SetActive (false);
			bub.SetActive (true);
			tre.SetActive (false);
			che.SetActive (false);
			break;
		case 2:
			pik.SetActive (false);
			bub.SetActive (false);
			tre.SetActive (true);
			che.SetActive (false);
			break;
		case 3:
			pik.SetActive (false);
			bub.SetActive (false);
			tre.SetActive (false);
			che.SetActive (true);
			break;
		}
	}

	public void OnMouseUpAsButton () // метод активируется при нажатии на обьект
	{
		if (PlayerPrefs.GetString ("Music") != "no") {
			GameObject.Find ("ClickIra").GetComponent<AudioSource> ().Play ();
		}
		spTF = false;

		//T ();
		tot++; // перемення для счёта
		Uu (); // запуск метода рандомности мастей
		Gog (); // запуск метода отображения счёта

		spTF = true;
	}

	public void T()
	{

		//if (tot == 3) {
		//	if (PlayerPrefs.GetString ("Music") != "no"){
		//		GameObject.Find("LaughLose").GetComponent<AudioSource> ().Play ();
		//	}
		pl.SetActive (true);
		//}
	}

	public void G()
	{
		pl2.SetActive (true);
	}

	public void RulMain()
	{
		main.SetActive (false);
	}

	public void Gog()
	{
		tText.text = "" + tot.ToString () + "/ 50";

	}

	public void MetHiJ()
	{
		hiJ.text = "" + lot.ToString ("f2");
	}
	public void STime()
	{
		if (spTF == true) {
			spHelp += Time.deltaTime;
		} else if (spTF == false) {
			sP = spHelp;
			speedRe.text = "SpeedReaction = " + sP.ToString ("f2");
			spHelp = 0;
			spTF = false;
		}
	}
    
}
