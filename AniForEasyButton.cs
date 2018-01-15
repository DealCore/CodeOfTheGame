using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AniForEasyButton : MonoBehaviour 
{
	public GameObject e1;
	public GameObject e2;
	public float h;


	void Update () {
		if (h < 0.8f) {
			h += Time.deltaTime;
			if (h < 0.4f) {
				e1.SetActive (true);
				e2.SetActive (false);
			} else if (h >= 0.4f) {
				e1.SetActive (false);
				e2.SetActive (true);
			}
		} else if (h >= 0.8f) {
			h = 0.0f;
		}
	}
}
