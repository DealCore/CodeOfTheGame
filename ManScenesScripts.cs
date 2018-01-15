using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ManScenesScripts : MonoBehaviour 
{
	public GameObject m_on, m_off; // два обьекта для реализации вкючения, отключения музыки

	public Sprite layer1, layer2; // создание двух обьектов, для реализации взаимо заменяемости при нажатии на кнопку



	void FixedUpdate () // метод запускается сходу при первой же активации, цель - блочит все повороты камеры
	{
		Screen.orientation = ScreenOrientation.AutoRotation; // непонятная хрень с скрином
		Screen.autorotateToLandscapeLeft = false; // установления значения false на авто поворот влево
		Screen.autorotateToLandscapeRight = false; // установление значения false на авто поворот вправо
		Screen.autorotateToPortrait = false; // установление значения false на авто поворот вверх
		Screen.autorotateToPortraitUpsideDown = false; // или это оно и есть хер знает
	}

	void Start () // метод активируется при самом старте программы
	{	

		/*if (PlayerPrefs.GetString ("Music") != "no") { // если в инструкции под именем "Music" не содержится значение "no" то активировать трек
			GameObject.Find("BackGroundPiano").GetComponent<AudioSource> ().Play (); // находит обьект с именем "BackGroundPiano", обращается к свойству "AudioSource" и активирует функцию Play ()
		

		}*/

		if (gameObject.name == "Music") { // если имя обьекта = "Music" то

			if (PlayerPrefs.GetString ("Music") == "no") { // если в инструкции "Music" содержится значение "no" (Музыка отключена)
				m_on.SetActive (false); // то не отображать обьект "m_on" с помощью функции SetActive() 
				m_off.SetActive (true); // и отображать обьект "m_off" тоесть музыка отключена
			} else { // иначе если в инструкции "Music" содержится значение "yes"
				m_on.SetActive (true); // отображать обьект с именем "m_on"-> тоесть музыка включина
				m_off.SetActive (false); // и не отображать элемент с именем "m_off" 
			}
		}
	}

	public void OnMouseUpAsButton () // метод для определения функциональности основным кнопкам
	{
		if (PlayerPrefs.GetString ("Music") != "no") { //если в инструкции с именем "Music" содержится значение "yes" то ->
			GameObject.Find("ClickSounds").GetComponent<AudioSource> ().Play (); // найти обьект с именем "ClickAudio" и обратится к свойству "AudioSource" и активировать функцию Play ()

		}

		switch (gameObject.name) { // аргументом switch-a является имя получаемого обьекта
		case "Play": // если активирована клавиша Play
			//Application.LoadLevel ("play"); // загрузить сцену с именем "Play"
			SceneManager.LoadScene("Levels");
			break;
		case "Impera": // если активирована клавиша рейтинга
			Application.OpenURL ("http://google.com"); // то перейти по указанной ссылке
			break;
		case "Help":
			//Application.LoadLevel ("HowTo");
			SceneManager.LoadScene ("HowTo");
			break;
		case "Music":
			if (PlayerPrefs.GetString ("Music") != "no") { // если в инструкции "Music" содержится значение "yes"
				PlayerPrefs.SetString ("Music", "no"); // то поместить в инструкцию "Music" значение "no"
				m_on.SetActive (false); // выключить значёк активности звука
				m_off.SetActive (true); // и включить значёк выключенного звука
			}else { // иначе
				PlayerPrefs.SetString ("Music", "yes"); // поместить в инструкцию с именем "Music" поместить значение "yes"
				m_on.SetActive (true); // активировать значёк активности звука
				m_off.SetActive (false);  // и отключить значёк выключенного звука
			}
			break;
		}
	}
}
