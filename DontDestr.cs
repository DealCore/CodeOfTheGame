using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DontDestr : MonoBehaviour
{
    public GameObject ob; // обьект для блокировки его уничтожения
    int rec; // перемення для реализации проверки количества очков власти игрока
    public GameObject kom; // панель для отображения малого количества власти игрока
    public GameObject mainObMainScenes;
    public bool fafHelper;
    public GameObject startButtonEasyFavor;

    void Start()
    {
        fafHelper = false;
        Detec();
    }

	void FixedUpdate () {
        DontDestroyOnLoad(ob);
        //Detec();
	}
    void Detec() // метод для реализации отслеживания количества очков, и контроль их
    {
            rec = PlayerPrefs.GetInt("PowerScore"); // записывание значения главного счёта в переменную rec
            if (rec <= -4) // если значение главного счёта меньше указанного минимума
            {
            fafHelper = true; // то присвоить вспомагательной переменной fafHelper значение true
            if (fafHelper == true) // если значение переменной fafHelper равняется true то
            {
                kom.SetActive(true); // отобразить панель при неостаточном количестве очков
                mainObMainScenes.SetActive(false);
                //SceneManager.LoadScene("EasyFavor");
                //mainObMainScenes.SetActive(false);
                fafHelper = false; // присвоить переменной fafHelper значение false
                startButtonEasyFavor.SetActive(false); // деактивировать кнопку старта(выхода на гавную сцену)
            }
            }
            else if (rec > -4) // если количество очков больше -4
            {

                mainObMainScenes.SetActive(true);
                kom.SetActive(false); // не отображать всплывающее окно
                startButtonEasyFavor.SetActive(true); // отображать кнопку Start - переход на главную сцену
            }
        
    }
    public void JustDoItButton() // метод для кнопки JustDoIt всплывающего окна при недостаточном количестве очков силы
    {
        kom.SetActive(false); // деактивировать появляющееся окно недостатка очков
        SceneManager.LoadScene("EasyFavor"); // загрузить сцену просмотра рекламы
    }
}
