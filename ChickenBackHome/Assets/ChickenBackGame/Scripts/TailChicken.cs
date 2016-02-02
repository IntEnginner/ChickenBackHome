using UnityEngine;
using System.Collections;

public class TailChicken : MonoBehaviour {
	
	[HideInInspector]
	public PlayerChicken mother;
	[HideInInspector]
	public TailChicken frontChild;
	[HideInInspector]


	GUIManager gui;

	// Use this for initialization
	void Start () {
		gui = FindObjectOfType(typeof(GUIManager)) as GUIManager;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider other) {
		if(other.gameObject.tag == "egg" || other.gameObject.tag == "wall"){
			GeneralManager.EndGame();
		} else if (other.gameObject.tag == "chickenHome"){
			BackHome();
		}
	}

	public void UpdateTrans(){
		if (frontChild != null) {
			gameObject.transform.position = frontChild.transform.position - frontChild.transform.forward * 1.5f;
			gameObject.transform.rotation = frontChild.transform.rotation;
		} else {
			gameObject.transform.position = mother.transform.position - mother.transform.forward * 1.5f;
			gameObject.transform.rotation = mother.transform.rotation;
		}
	}

	void BackHome(){ // remove from mother
		mother.DestroyChild (this);
		if (gui != null) {
			GeneralManager.score++;
			gui.chickenHomed = GeneralManager.score;
			gui.chickenInTail = mother.childList.Count;
		}
	}
}
