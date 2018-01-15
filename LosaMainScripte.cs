using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LosaMainScripte : MonoBehaviour 
{
	public void OnMouseUpAsButton()
	{
		switch (gameObject.name) {
		case "rePlay":
			SceneManager.LoadScene ("Ira");
			break;
		case "Exit":
			SceneManager.LoadScene ("mainScene");
			break;
		}
	}
}
