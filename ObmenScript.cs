using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObmenScript : MonoBehaviour 
{
	public float ti;
	public GameObject o1;
	public GameObject o2;

	void FixedUpdate () {
		if (ti < 0.6f) {
			ti += Time.deltaTime;
			if (ti < 0.3f) {
				o1.SetActive (true);
				o2.SetActive (false);
			} else if (ti >= 0.3f) {
				o1.SetActive (false);
				o2.SetActive (true);
			}
		} else if (ti >= 0.6f) {
			ti = 0.0f;
		}
	}
}
