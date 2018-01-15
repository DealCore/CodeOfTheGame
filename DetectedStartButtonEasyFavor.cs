using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectedStartButtonEasyFavor : MonoBehaviour
{
    public int recSta;
    public GameObject oBStart;

	void FixedUpdate () {
        
        recSta = PlayerPrefs.GetInt("PowerScore");
        if (recSta <= -4) {
            oBStart.SetActive(false);
        } else if (recSta > -4) {
            oBStart.SetActive(true);
        }
	}
}
