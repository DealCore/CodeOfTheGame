using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;
using UnityEngine.SceneManagement;

public class MainEasyFavorScript : MonoBehaviour 
{
	public int hSe = 0;

	void OnMouseUpAsButton()
	{
		if (Advertisement.IsReady ()) 
		{
			Advertisement.Show ("rewardedVideo", new ShowOptions () { resultCallback = HandleAdResult});
		}
	}

	private void HandleAdResult(ShowResult result)
	{
		switch (result) {
		case ShowResult.Finished:
			Debug.Log ("Player Gains+5 gems");
			hSe = PlayerPrefs.GetInt ("FavorScore");
			hSe += 7;
			PlayerPrefs.SetInt ("FavorScore", hSe);
			break;
		case ShowResult.Skipped:
			Debug.Log ("Player did not fully watch the ad");
			break;
		case ShowResult.Failed:
			Debug.Log ("Player failed to launch the ad? Internet?");
			break;
		}
	}
	public void GoStartGame()
	{
		SceneManager.LoadScene ("mainScene");
	}
}
