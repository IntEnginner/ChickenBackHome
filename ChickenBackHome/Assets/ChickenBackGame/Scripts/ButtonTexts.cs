using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ButtonTexts : MonoBehaviour {

	public Text upButtonLabel;
	public Text downButtonLabel;
	public Text leftButtonLabel;
	public Text rightButtonLabel;

	// Use this for initialization
	void Start () {
		if (GeneralManager.godMode) {
			SetupButtonTextGodControl ();
		} else {
			SetupButtonTextChicken ();
		}
	}

	void SetupButtonTextGodControl() {
		if(upButtonLabel != null){
			upButtonLabel.text = "Up";
		}
		if(downButtonLabel != null){
			downButtonLabel.text = "Down";
		}
		if(leftButtonLabel != null){
			leftButtonLabel.text = "Left";
		}
		if(rightButtonLabel != null){
			rightButtonLabel.text = "Right";
		}
	}

	void SetupButtonTextChicken() {
		
		if(upButtonLabel != null){
			upButtonLabel.text = "Forward";
		}
		if(downButtonLabel != null){
			downButtonLabel.text = "Backward";
		}
		if(leftButtonLabel != null){
			leftButtonLabel.text = "Turn Left";
		}
		if(rightButtonLabel != null){
			rightButtonLabel.text = "Turn Right";
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
