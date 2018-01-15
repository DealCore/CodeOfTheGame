using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Advertisements;

public class LuxuriaScript : MonoBehaviour {

	public int rr;
	public GameObject pik;
	public GameObject bub;
	public GameObject tre;
	public GameObject che;

	public GameObject mainLuxuria; // обьект для доступа к главной панели Luxuria
	public GameObject loseLuxuria; // обьект для доступа к панели поражения Luxuria
	public GameObject winLuxuria; // переменная для доступа к панели выигрыша
	public GameObject firstLuxuria; // переменная для доступа к стартовой панели Luxuria

	public bool goHelp; // переменная помощи в реаизации запуска таймера 

	public float tT; // переменная для реализации таймера
	public Text textTime; // переменная для доступа к текстовому обьекту textTime
	public int mainScore; // перменная для реализации главного счёта уровня
	public Text score; // переменная для доступа к текстовому обьекту

	public Text forLoseRezul;
	public Text forWinRezul;
	public int tyL;

	public static int alvL = 0; // переменная для отслеживания количества раз проигранных игр
	public static int alvW = 0; // переменная для подсчёта количества выигранных игр
	private string gameId = "1613948"; // переменная содержит id игры для доступа к рекламе

	void Start() // метод запускается только 1 раз при самом запуске уровня
	{
		if (Advertisement.isSupported) { // если реклама поддерживается то
			Advertisement.Initialize (gameId, false); // инициализировать рекламу
		} else { // иначе
			Debug.Log ("Platform is not supported"); // вывести в консоль строку
		}

		mainScore = 0;
		tT = 0.0f;
		loseLuxuria.SetActive (false); // скрыть проигрыш-панель
		winLuxuria.SetActive (false); // скрыть выигрыш-панель
		mainLuxuria.SetActive (false); // скрыть главную игровую область Luxuria
		firstLuxuria.SetActive (true); // отобразить квестовую панель, перед уровнем
		goHelp = false; // присвоить изначальное значение false переменной goHelp
	}

void FixedUpdate() // метод запусакется каждый кадр
{
		Kasl (); // метод для реализации таймера
}

void Kasl() // метод для реализации таймера и выигрыша и проигрыша
{
	if(goHelp == true){ // если переменная goHelp имеет значение true
			if (tT < 10) { // если не прошло 10 секунд
				tT += Time.deltaTime; // добавить секунду
				textTime.text = "sec " + tT.ToString ("f2"); // отобразить текущее время на текстовом обьекте textTime
			} else { // иначе
				if (mainScore < 10) { // если игрок набрал меньше 10-и очков
					if (PlayerPrefs.GetString ("Music") != "no") { // если звук в игре не выключен
						GameObject.Find ("loseLuxuria").GetComponent<AudioSource> ().Play (); // запустить аудио с именем loseLuxuria
						GameObject.Find("BGSexMusic").GetComponent<AudioSource> ().Stop();
						GameObject.Find ("SexSoundsWoman").GetComponent<AudioSource> ().Stop ();
						forLoseRezul.text = "" + mainScore.ToString ();
					}
					tyL = PlayerPrefs.GetInt ("PowerScore");
					tyL--;
					PlayerPrefs.SetInt ("PowerScore", tyL);

					mainLuxuria.SetActive (false); // скрыть главную панель Luxuria
					loseLuxuria.SetActive (true); // отобразить панель поражения
					winLuxuria.SetActive (false); // скрыть панель выигрыша
					firstLuxuria.SetActive (false); // скрыть панель изначального задания уровня
					goHelp = false; // скрыть переменной goHelp значение false

					alvL++; // переменная для подсчёта количества проигрышей игрока
					/*if (Advertisement.IsReady () && alvL % 3 == 0) { // если реклама готова и игрок проиграл 3 раза то
						Advertisement.Show (); // показать рекламу
					}*/
					if (Advertisement.IsReady () && alvL % 3 == 0) {
						Advertisement.Show ("rewardedVideo", new ShowOptions(){resultCallback = HandleAdResult});
					}

				} else if (mainScore >= 10) { // если очков набрано 10 или больше то
					if (PlayerPrefs.GetString ("Music") != "no") { // если звук в игре не выключен
						GameObject.Find ("winLuxuria").GetComponent<AudioSource> ().Play (); // активировать аудио с именем winLuxuria
						GameObject.Find("BGSexMusic").GetComponent<AudioSource> ().Stop();
						GameObject.Find ("SexSoundsWoman").GetComponent<AudioSource> ().Stop ();
						forWinRezul.text = "" + mainScore.ToString ();
				}

                    if (PlayerPrefs.GetInt("LuxuriaRecords") <= mainScore) {
                        PlayerPrefs.SetInt("LuxuriaRecords", mainScore);
                    }
					tyL = PlayerPrefs.GetInt ("PowerScore");
					tyL++;
				PlayerPrefs.SetInt ("PowerScore", tyL);

				mainLuxuria.SetActive (false); // скрыть главную панель Luxuria
				loseLuxuria.SetActive (false); // скрыть панель поражения
				winLuxuria.SetActive (true); // отобразить панель выигрыша Luxuria
				firstLuxuria.SetActive (false); // скрыть стартовую панель Luxuria
					goHelp = false; //присвоить переменной goHelp значение false

					alvW++; // переменная для подсчёта количества выигрышей игрока
					/*if (Advertisement.IsReady () && alvW % 3 == 0) { // если реклама готова и игрок выиграл 3 раза то
						Advertisement.Show (); // показать рекламу
					}*/
					if (Advertisement.IsReady () && alvW % 3 == 0) {
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

public void Sonext() // метод для стартовой панели уровня
	{
		goHelp = true; // присвоить переменной с именем goHelp значение true
	firstLuxuria.SetActive (false); // скрыть стартовую панель уровня
	mainLuxuria.SetActive (true); // отобразить главную панель
	}

public void ExitMetod()
	{
		SceneManager.LoadScene ("Levels");
	}

public void OnMouseUpAsButton() // метод для активирования кода при нажатии на елемент
	{
		mainScore++; // при нажатии инкрементировать главный счёт уровня Luxuria
		score.text = "Kisses " + mainScore.ToString (); // отображать главный счёт Luxuria на текстовом обьекта
		if (PlayerPrefs.GetString ("Music") != "no") { // если не выключен звук то
			GameObject.Find ("KissWoman").GetComponent<AudioSource> ().Play (); // активировать компонент под именем BGAu
		}

		rr = Random.Range (0, 4); // сгенерировать случайное значение в переменную rr 
		switch (rr) { // описывание инструкций для всех случайных значений переменной rr с помощью оператора switch
		case 0: // если значение переменной rr = 0
			pik.SetActive (true); // отобразить элемент pik
			bub.SetActive (false); // скрыть елемент bub
			tre.SetActive (false); // скрыть елемент tre
			che.SetActive (false); // скрыть елемент che
			break;
		case 1: // если значение переменной rr = 1
			pik.SetActive (false); // скрыть елемент pik
			bub.SetActive (true); //отобразить елемент bub
			tre.SetActive (false); // скрыть елемент tre
			che.SetActive (false); // скрыть елемент che
			break;
		case 2: // если значение переменной rr = 2
			pik.SetActive (false); // скрыть елемент pik
			bub.SetActive (false); // скрыть елемент bub
			tre.SetActive (true); // отобразить елемент tre
			che.SetActive (false); // скрыть елемент che
			break;
		case 3: // если значение переменной rr = 3
			pik.SetActive (false); // скрыть елемент pik
			bub.SetActive (false); // скрыть елемент bub
			tre.SetActive (false); // скрыть елемент tre
			che.SetActive (true); // отобразить елемент che
			break;
		}
	}
}
