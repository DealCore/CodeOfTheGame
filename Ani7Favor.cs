using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ani7Favor : MonoBehaviour 
{
	public GameObject fa1;
	public GameObject fa2;
	public float i;

	void FixedUpdate () {
		if (i < 2.0f) {
			i += Time.deltaTime;
			if (i < 1.0f) {
				fa1.SetActive (true);
				fa2.SetActive (false);
			} else if (i >= 1.0f) {
				fa1.SetActive (false);
				fa2.SetActive (true);
			}
				
		} else if (i >= 2.0f) {
			i = 0.0f;
		}
	}
}
