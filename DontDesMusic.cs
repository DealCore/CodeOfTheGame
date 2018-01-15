using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDesMusic : MonoBehaviour {

	void Start () {
		DontDestroyOnLoad (gameObject);
	}
}
