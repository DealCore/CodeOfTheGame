using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForSkull : MonoBehaviour 
{
	public bool t;
	public bool y;
	public GameObject sk1;
	public GameObject sk2;
	public float vx;

	void FixedUpdate () {
		Sec1 ();
	}

	void Gg()
	{
		if (t == true) {
			sk1.SetActive (true);
			sk2.SetActive (false);

		} else if (y == true) {
			sk1.SetActive (false);
			sk2.SetActive (true);

		}
	}
	void Sec1()
	{
		if (vx < 4.0f) {
			vx += Time.deltaTime;
			if (vx < 2.0f) {
				t = true;
				y = false;
				Gg ();
			} else if (vx >= 2.0f) {
				t = false;
				y = true;
				Gg ();
			}
		} else if (vx >= 4.0f) {
			vx = 0.0f;
		}
	}
}
