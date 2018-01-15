using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoStartGame : MonoBehaviour 
{

	public void OnMouseUpAsButton()
	{
		SceneManager.LoadScene ("mainScene");
	}
}
