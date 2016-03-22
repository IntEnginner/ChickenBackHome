using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.Advertisements;

public class EndScene : MonoBehaviour {

	string gameId = "1044315";
	string placementId = "rewardedVideo";
	public bool enableTestMode = false;


	public Text scoreLabel;
	public Text godButtonLabel;
	// Use this for initialization
	void Awake() {
		GeneralManager.godMode = false;
	}

	void Start () {
		if(scoreLabel != null){
			scoreLabel.text = GeneralManager.score.ToString();
		}
	}
	
	// Update is called once per frame
	void Update () {

	}

	public void GodModeButtonClicked() {
		StartCoroutine (InitializeAd ()); 
	}

	IEnumerator InitializeAd () {

		while (!Advertisement.IsReady(placementId)) {
			SetGodButtonText("Waiting ...");
			yield return new WaitForSeconds(0.5f);
		}

		ShowOptions options = new ShowOptions();
		options.resultCallback = HandleShowResult;

		Advertisement.Show (placementId, options);
	}

	void HandleShowResult (ShowResult result) {
		switch (result)
		{
		case ShowResult.Finished:
			SetGodButtonText("Congrats!");
			GeneralManager.godMode = true;
			break;
		case ShowResult.Skipped:
			SetGodButtonText("Active god mode by watching a video!!");
			Debug.LogWarning ("Video was skipped.");
			break;
		case ShowResult.Failed:
			SetGodButtonText("Active god mode failed ...");
			Debug.LogWarning ("Video failed to show.");
			break;
		}
	}

	void SetGodButtonText(string text) {
		if (godButtonLabel != null) {
			godButtonLabel.text = text;
		} else {
			Debug.LogError("godButtonLabel isn't assigned");
		}
	}
}
