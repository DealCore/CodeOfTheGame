using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForComeBackButton : MonoBehaviour 
{
	public GameObject err;
	public GameObject mainEasy;

	public void OnMouseUpAsButton()
	{
		err.SetActive (false);
		mainEasy.SetActive (true);
	}
}
