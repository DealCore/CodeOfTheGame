using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FreeFavorButtonGo : MonoBehaviour 
{
	public void OnMouseUpAsButton()
	{
		SceneManager.LoadScene ("EasyFavor");
	}
}
