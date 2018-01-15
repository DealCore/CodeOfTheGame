using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForAniFavor : MonoBehaviour 
{
	public GameObject f1;
	public GameObject f2;
	public float u;


	void FixedUpdate () {
		if (u < 1.0f) {
			u += Time.deltaTime;
			if (u < 0.5f) {
				f1.SetActive (true);
				f2.SetActive (false);
			} else if (u >= 0.5f) {
				f1.SetActive (false);
				f2.SetActive (true);
			}

		} else if (u >= 1.0f) {
			u = 0.0f;
		}
	}
}
