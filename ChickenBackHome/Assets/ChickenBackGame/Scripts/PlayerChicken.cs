using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class PlayerChicken : MonoBehaviour {
	
	public GameObject tailChickenTemplate;

	GUIManager gui;
	[HideInInspector]
	public List<TailChicken> childList = new List<TailChicken> ();


	void Awake(){
		GeneralManager.score = 0;
		gui = FindObjectOfType(typeof(GUIManager)) as GUIManager;
	}

	void Start () {
	}
	
	// Update is called once per frame
	void Update () {

	}

	void OnTriggerEnter(Collider other) {
		if(other.gameObject.tag == "egg"){
			EatEgg();
			Destroy(other.gameObject);
			if (gui != null) {
				gui.chickenInTail = childList.Count;
			}
		} else if (other.gameObject.tag == "wall" || other.gameObject.tag == "chickenHome"){
			GeneralManager.EndGame();
		}
	}

	public void EatEgg(){
		MakeChild ();
	}

	void MakeChild(){
		if (tailChickenTemplate != null) {

			GameObject newChild = Instantiate(tailChickenTemplate) as GameObject;
			TailChicken childTail = newChild.GetComponent<TailChicken>();
			if(childTail != null){

				if(childList.Count > 0){
					childTail.frontChild = childList[childList.Count - 1];
				}
				childTail.mother = this;
				childList.Add(childTail);
				childTail.UpdateTrans();
			}

		}
	}
	
	public void MotherMovedBack(){
		foreach (TailChicken child in childList) {
			child.UpdateTrans();
		}
	}
	
	public void MotherMovedForward(){
		foreach (TailChicken child in childList) {
			child.UpdateTrans();
		}
	}

	public void DestroyChild(TailChicken child){
		childList.Remove (child);
		Destroy (child.gameObject);
	}
}
