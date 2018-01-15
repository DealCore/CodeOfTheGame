using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Advertisements;

public class GulaScripts : MonoBehaviour 
{
	public GameObject masoText;
	public GameObject traviText;
	public GameObject napitkiText;

	public Text mas; // счёт мяса
	public Text zel; // счёт зелени
	public Text nap; // счёт напитка

	public int r; // переменная для рандомного трёх значного числа
	public int rList; // переменная для случайного числа, обозначающие три списка
	public int mEl; // переменная для определения случайного элемента мяса
	public int tEl; // переменная для определения случайного элемента списка зелени
	public int hEl; // переменная для определения случайного элемента списка напитков

	public int rN; // 


	public int first; // переменная для первого числа трёзначного
	public int second; // переменная для второго числа трёхзначного
	public int third; // переменная для третьего числа трёхзначного

	public GameObject panelLoseGula;
	public GameObject panelWinGula;
	public bool helpFalse = false; // для контрольного запуска таймера, строго после квестовой панели
	public float tI; // переменная для таймера

	// переменные для списка мяса
	public GameObject mas1;
	public GameObject mas2;
	public GameObject mas3;
	public GameObject mas4;
	public GameObject mas5;
	public GameObject mas6;
	public GameObject mas7;
	public GameObject mas8;
	public GameObject mas9;
	public GameObject mas10;

	// переменные для списка зелени
	public GameObject zel1;
	public GameObject zel2;
	public GameObject zel3;
	public GameObject zel4;
	public GameObject zel5;
	public GameObject zel6;
	public GameObject zel7;
	public GameObject zel8;
	public GameObject zel9;
	public GameObject zel10;

	// переменные для списка напитков
	public GameObject nap1;
	public GameObject nap2;
	public GameObject nap3;
	public GameObject nap4;
	public GameObject nap5;
	public GameObject nap6;
	public GameObject nap7;
	public GameObject nap8;
	public GameObject nap9;
	public GameObject nap10;

	public bool mA;
	public bool tR;
	public bool nA;

	public int mInc;
	public int tInc;
	public int nInc;

	public Text mAso;
	public Text tRav;
	public Text nAp;

	public Text mAsoW;
	public Text tRavW;
	public Text nApW;
	public GameObject mAsoWW;
	public GameObject tRavWW;
	public GameObject nApWW;

	public Text mAsoL;
	public Text tRavL;
	public Text nApL;
	public GameObject mAsoLL;
	public GameObject tRavLL;
	public GameObject nApLL;

	public GameObject mCri; // переменная для квестовой панели
	public GameObject tCri;
	public GameObject nCri;
	public GameObject pQuest;

	public Text goTime;

	public GameObject forMainDisable;
	public GameObject firstQvestPanel;

	public Text forRezulWinGula;
	public Text forRezulLoseGula;
	public int tyO;

	public static int agvL = 0; // переменная для подсчёта количества лузов игрока
	public static int agvW = 0; // переменная для отслеживания выигранных количества раз игр
	private string gameId = "1613948"; // переменная для доступа к рекламе, содержит id игры

	public bool fof;  // вспомагательная переменная

	void Start() // метод для запуска кода с самого начала
	{

		if (Advertisement.isSupported) { // если реклама поддерживается то 
			Advertisement.Initialize (gameId, false); // установить рекламу заранее
		} else { // иначе
			Debug.Log ("Platform is not supported"); // вывести в консоль строку
		}

		forMainDisable.SetActive (false);
		Tol (); // метод для инициализации трёх списков
		Tt(); // метод запускается сразу при первом запуске и определяет какие элементы должен собирать игрок
		PanM();
		OnMouseUpAsButton ();
	}

	void FixedUpdate()
	{
		Tzhraty ();

	}

	void Tzhraty ()
	{
		if (helpFalse == true) {
			if (tI < 29) {
				tI += Time.deltaTime;
				goTime.text = "sec " + tI.ToString ("f2");
			} else {
				if (mInc >= 13 || tInc >= 13 || nInc >= 13) {
					if (PlayerPrefs.GetString ("Music") != "no") {
						GameObject.Find ("forWinGula").GetComponent<AudioSource> ().Play ();
					}

                    if (mA == true)
                    {
                        if (PlayerPrefs.GetInt("GulaRecords") <= mInc)
                        {
                            PlayerPrefs.SetInt("GulaRecords", mInc);
                        }
                    }
                    else if (tR == true)
                    {
                        if (PlayerPrefs.GetInt("GulaRecords") <= tInc)
                        {
                            PlayerPrefs.SetInt("GulaRecords", tInc);
                        }
                    }
                    else if (nA == true)
                    {
                        if (PlayerPrefs.GetInt("GulaRecords") <= nInc)
                        {
                            PlayerPrefs.SetInt("GulaRecords", nInc);
                        }
                    }
					tyO = PlayerPrefs.GetInt ("PowerScore");
					tyO++;
					PlayerPrefs.SetInt ("PowerScore", tyO);

                    panelWinGula.SetActive (true);
					forMainDisable.SetActive (false);
					mAsoW.text = "" + mInc.ToString();
					tRavW.text = "" + tInc.ToString ();
					nApW.text = "" + nInc.ToString ();

					agvW++; // переменная для подсчёта количества раз выигранных игр
					/*if (Advertisement.IsReady () && agvW % 3 == 0) { // если реклама готова и игрок выиграл 3 раза то
						Advertisement.Show (); // показать рекламу
					}*/
					if (Advertisement.IsReady () && agvW % 3 == 0) {
						Advertisement.Show ("rewardedVideo", new ShowOptions(){resultCallback = HandleAdResult});
					}

				} else {
					if (PlayerPrefs.GetString("Music") != "no") {
						GameObject.Find("smexLoseGula").GetComponent<AudioSource> ().Play();
						GameObject.Find("LoseSoundPasuda").GetComponent<AudioSource> ().Play();
					}
					panelLoseGula.SetActive (true);
					forMainDisable.SetActive (false);
					mAsoL.text = "" + mInc.ToString ();
					tRavL.text = "" + tInc.ToString ();
					nApL.text = "" + nInc.ToString ();
					tyO = PlayerPrefs.GetInt ("PowerScore");
					tyO--;
					PlayerPrefs.SetInt ("PowerScore", tyO);

					agvL++; // переменная для подсчёта количества раз проигранных каток
					/*if (Advertisement.IsReady () && agvL % 3 == 0) { // если реклама готова и игрок проиграл 3 раза то
						Advertisement.Show (); // показать рекламу
					}*/
					if (Advertisement.IsReady () && agvL % 3 == 0) {
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

    public void ExitGula()
    {
        SceneManager.LoadScene("Levels");
    }

	public void HoNext() // метод для сворачивания квестовой панели
	{
		forMainDisable.SetActive (true);
		helpFalse = true;
		pQuest.SetActive (false); // зафолсить панель
	}

	public void Tt() // метод для генерации одного из списков, и предопределение задачи для игрока
	{
		rN = Random.Range (0, 3); // генерация одного из переменных
		switch (rN) {
		case 0:
			mA = true;
			masoText.SetActive (true);
			traviText.SetActive (false);
			napitkiText.SetActive (false);

			mAsoWW.SetActive (true);
			mAsoLL.SetActive (true);

			tRavWW.SetActive (false);
			tRavLL.SetActive (false);

			nApWW.SetActive (false);
			nApLL.SetActive (false);

			mAso.text = "Catch the meat!";
			break;
		case 1:
			tR = true;
			masoText.SetActive (false);
			traviText.SetActive (true);
			napitkiText.SetActive (false);

			mAsoWW.SetActive (false);
			mAsoLL.SetActive (false);

			tRavWW.SetActive (true);
			tRavLL.SetActive (true);

			nApWW.SetActive (false);
			nApLL.SetActive (false);

			tRav.text = "Сatch greens!";
			break;
		case 2:
			nA = true;
			masoText.SetActive (false);
			traviText.SetActive (false);
			napitkiText.SetActive (true);

			mAsoWW.SetActive (false);
			mAsoLL.SetActive (false);

			tRavWW.SetActive (false);
			tRavLL.SetActive (false);

			nApWW.SetActive (true);
			nApLL.SetActive (true);

			nAp.text = "Сatch the drinks!";
			break;
		}
	}

	void PanM()
	{
		pQuest.SetActive (true);
		switch (rN) {
		case 0:
			mCri.SetActive (true);
			tCri.SetActive (false);
			nCri.SetActive (false);
			break;
		case 1:
			mCri.SetActive (false);
			tCri.SetActive (true);
			nCri.SetActive (false);
			break;
		case 2:
			mCri.SetActive (false);
			tCri.SetActive (false);
			nCri.SetActive (true);
			break;
		}
	}

	public void OnMouseUpAsButton() // метод запускается после нажатия на кнопку
	{
		if (PlayerPrefs.GetString ("Music") != "no") {
			GameObject.Find ("soundKnife").GetComponent<AudioSource> ().Play ();
		}
		GgR (); // метод для скрытия всех элементов трёх списков
		fof = true; // вспомагательная переменная
		//GenRandQuest (); // метод для вывода случайного трёх значного числа

		rList = Random.Range (0, 3); // инициализация рандомного значения в переменной rList
		switch (rList) {
		case 0:
			MList (); // вызов метода мяса
			break;
		case 1:
			TList (); // вызов метода зелени
			break;
		case 2:
			HList (); // вызов метода напитков
			break;
		}
	}

	public void Ty() // метод для определения цели сбора для игрока с самаого начала уровня
	{
		if (PlayerPrefs.GetString ("Music") != "no") {
			GameObject.Find ("soundBell").GetComponent<AudioSource> ().Play ();
		}
		if (mA == true) { // если переменная mA true то
			if (rList == 0) { // если случайное значение имеет 0 то нужно собирать мясо
				mInc++; // инкремента мяса
				mAso.text = "meat 13/" + mInc.ToString (); // выводить значение переменной mA 
			} else { // иначе
				mInc--; // декремента
				mAso.text = "meat 13/" + mInc.ToString (); // вывести значение
			}
		} else if (tR == true) { // проверить если выпало собирать траву
			if (rList == 1) { // если выпал рисунок из списка трав то
				tInc++; // инкрементировать
				tRav.text = "greenery 13/" + tInc.ToString (); // выывести значение
			} else { // иначе
				tInc--; // декментировать
				tRav.text = "greenery 13/" + tInc.ToString (); // вывести значение
			}
		} else if (nA == true) { // проверить выпало ли собирать напитки
			if (rList == 2) { // если выпал рисунок из напитков то
				nInc++; // инкрементировать
				nAp.text = "beverages 13/" + nInc.ToString (); // вывести значение
			} else { // иначе
				nInc--; // декрементировать
				nAp.text = "beverages 13/" + nInc.ToString (); // вывести значение
			}
		}
		OnMouseUpAsButton (); // вызывается метод для смены картинки
	}

	public void Tol() // метод для инициализации трёх списков
	{
		List<GameObject> maso = new List<GameObject> () { mas1, mas2, mas3, mas4, mas5, mas6, mas7, mas8, mas9, mas10};
		List<GameObject> zelen = new List<GameObject> () { zel1, zel2, zel3, zel4, zel5, zel6, zel7, zel8, zel9, zel10};
		List<GameObject> napitki = new List<GameObject> () { nap1, nap2, nap3, nap4, nap5, nap6, nap7, nap8, nap9, nap10};
	}
	void MList() // метод для отображение элементов из списка мяса
	{
		mEl = Random.Range (0, 10); // генерация случайного значения в переменной mEl
		switch (mEl) {
		case 0:
			//mas1.SetActive (true);
			if (fof == true) {
				mas1.SetActive (true);
			} else if (fof = false){
				mas1.SetActive(false);
			}
			break;
		case 1:
			//mas2.SetActive (true);
			if (fof == true) {
				mas2.SetActive (true);
			} else if (fof == false) {
				mas2.SetActive (false);
			}
			break;
		case 2:
			//mas3.SetActive (true);
			if (fof == true) {
				mas3.SetActive (true);
			} else if (fof == false) {
				mas3.SetActive (false);
			}
			break;
		case 3:
			//mas4.SetActive (true);
			if (fof == true) {
				mas4.SetActive (true);
			} else if (fof == false) {
				mas4.SetActive (false);
			}
			break;
		case 4:
			//mas5.SetActive (true);
			if (fof == true) {
				mas5.SetActive (true);
			} else if (fof == false) {
				mas5.SetActive (false);
			}
			break;
		case 5:
			//mas6.SetActive (true);
			if (fof == true) {
				mas6.SetActive (true);
			} else if (fof == false) {
				mas6.SetActive (false);
			}
			break;
		case 6:
			//mas7.SetActive (true);
			if (fof == true) {
				mas7.SetActive (true);
			} else if (fof == false) {
				mas7.SetActive (false);
			}
			break;
		case 7:
			//mas8.SetActive (true);
			if(fof == true){
				mas8.SetActive (true);
			}else if(fof == false){
				mas8.SetActive (false);
			}
			break;
		case 8:
			//mas9.SetActive (true);
			if(fof == true){
				mas9.SetActive (true);
			}else if(fof == false){
				mas9.SetActive (false);
			}
			break;
		case 9:
			//mas10.SetActive (true);
			if (fof == true) {
				mas10.SetActive (true);
			} else if (fof == false) {
				mas10.SetActive (false);
			}
			break;
		}
	}
	void TList()
	{
		tEl = Random.Range (0, 10);
		switch (tEl) {
		case 0:
			//zel1.SetActive (true);
			if(fof == true){
				zel1.SetActive (true);
			}else if(fof == false){
				zel1.SetActive (false);
			}
			break;
		case 1:
			//zel2.SetActive (true);
			if (fof == true) {
				zel2.SetActive (true);
			} else if (fof == false) {
				zel2.SetActive (false);
			}
			break;
		case 2:
			//zel3.SetActive (true);
			if (fof == true) {
				zel3.SetActive (true);
			} else if (fof == false) {
				zel3.SetActive (false);
			}
			break;
		case 3:
			//zel4.SetActive (true);
			if (fof == true) {
				zel4.SetActive (true);
			} else if (fof == false) {
				zel4.SetActive (false);
			}
			break;
		case 4:
			//zel5.SetActive (true);
			if (fof == true) {
				zel5.SetActive (true);
			} else if (fof == false) {
				zel5.SetActive (false);
			}
			break;
		case 5:
			//zel6.SetActive (true);
			if (fof == true) {
				zel6.SetActive (true);
			} else if (fof == false) {
				zel6.SetActive (false);
			}
			break;
		case 6:
			//zel7.SetActive (true);
			if (fof == true) {
				zel7.SetActive (true);
			} else if (fof == false) {
				zel7.SetActive (false);
			}
			break;
		case 7:
			//zel8.SetActive (true);
			if (fof == true) {
				zel8.SetActive (true);
			} else if (fof == false) {
				zel8.SetActive (false);
			}
			break;
		case 8:
			//zel9.SetActive (true);
			if (fof == true) {
				zel9.SetActive (true);
			} else if (fof == false) {
				zel9.SetActive (false);
			}
			break;
		case 9:
			//zel10.SetActive (true);
			if (fof == true) {
				zel10.SetActive (true);
			} else if (fof == false) {
				zel10.SetActive (false);
			}
			break;
		}
	}
	void HList()
	{
		hEl = Random.Range (0, 10);
		switch (hEl) {
		case 0:
			//nap1.SetActive (true);
			if (fof == true) {
				nap1.SetActive (true);
			} else if (fof == false) {
				nap1.SetActive (false);
			}
			break;
		case 1:
			//nap2.SetActive (true);
			if (fof == true) {
				nap2.SetActive (true);
			} else if (fof == false) {
				nap2.SetActive (false);
			}
			break;
		case 2:
			//nap3.SetActive (true);
			if (fof == true) {
				nap3.SetActive (true);
			} else if (fof == false) {
				nap3.SetActive (false);
			}
			break;
		case 3:
			//nap4.SetActive (true);
			if (fof == true) {
				nap4.SetActive (true);
			} else if (fof == false) {
				nap4.SetActive (false);
			}
			break;
		case 4:
			//nap5.SetActive (true);
			if (fof == true) {
				nap5.SetActive (true);
			} else if (fof == false) {
				nap5.SetActive (false);
			}
			break;
		case 5:
			//nap6.SetActive (true);
			if (fof == true) {
				nap6.SetActive (true);
			} else if (fof == false) {
				nap6.SetActive (false);
			}
			break;
		case 6:
			//nap7.SetActive (true);
			if (fof == true) {
				nap7.SetActive (true);
			} else if (fof == false) {
				nap7.SetActive (false);
			}
			break;
		case 7:
			//nap8.SetActive (true);
			if (fof == true) {
				nap8.SetActive (true);
			} else if (fof == false) {
				nap8.SetActive (false);
			}
			break;
		case 8:
			//nap9.SetActive (true);
			if (fof == true) {
				nap9.SetActive (true);
			} else if (fof == false) {
				nap9.SetActive (false);
			}
			break;
		case 9:
			//nap10.SetActive (true);
			if (fof == true) {
				nap10.SetActive (true);
			} else if (fof == false) {
				nap10.SetActive (false);
			}
			break;
		}
	}

	void GgR() // метод для деактивирования всех элементов трёх списков
	{
		mas1.SetActive (false);
		mas2.SetActive (false);
		mas3.SetActive (false);
		mas4.SetActive (false);
		mas5.SetActive (false);
		mas6.SetActive (false);
		mas7.SetActive (false);
		mas8.SetActive (false);
		mas9.SetActive (false);
		mas10.SetActive (false);

		zel1.SetActive (false);
		zel2.SetActive (false);
		zel3.SetActive (false);
		zel4.SetActive (false);
		zel5.SetActive (false);
		zel6.SetActive (false);
		zel7.SetActive (false);
		zel8.SetActive (false);
		zel9.SetActive (false);
		zel10.SetActive (false);

		nap1.SetActive (false);
		nap2.SetActive (false);
		nap3.SetActive (false);
		nap4.SetActive (false);
		nap5.SetActive (false);
		nap6.SetActive (false);
		nap7.SetActive (false);
		nap8.SetActive (false);
		nap9.SetActive (false);
		nap10.SetActive (false);
	}
}
