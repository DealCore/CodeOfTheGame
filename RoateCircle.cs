using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoateCircle : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		Quaternion rotationY = Quaternion.AngleAxis (1, new Vector3(0, 0, 1));
		transform.rotation *= rotationY;
	}
}
