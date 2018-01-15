using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayButtonVideo : MonoBehaviour 
{
	public GameObject io1;
	public GameObject io2;
	public float o;

	void FixedUpdate () {
		if (o < 1.0f) {
			o += Time.deltaTime;
			if (o < 0.5f) {
				io1.SetActive (true);
				io2.SetActive (false);

			} else if (o >= 0.5f) {
				io1.SetActive (false);
				io2.SetActive (true);

			}
		} else if (o >= 1.0f) {
			o = 0.0f;
		}
	}
}
