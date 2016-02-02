using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class MoveController : MonoBehaviour {

	public float speed = 6f;
	GUIManager gui;

	bool up;
	bool down;
	bool left;
	bool right;

	void Awake() {
		gui = FindObjectOfType(typeof(GUIManager)) as GUIManager;
	}

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		UpdateByButtonState ();
	}

	void UpdateByButtonState() {

		if(up) {
			if (GeneralManager.godMode) {
				TryMoveUp ();
			} else {
				MoveForward();
			}
		} else if (down) {
			if (GeneralManager.godMode) {
				TryMoveDown ();
			} else {
				MoveBack();
			}
		} else if(left) {
			if (GeneralManager.godMode) {
				TryMoveLeft ();
			} 
		} else if(right) {
			if (GeneralManager.godMode) {
				TryMoveRight ();
			} 
		}
	}

	// god mode control
	void GodControl() {
		if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved) {
			// Get movement of the finger since last frame
			Vector2 touchDeltaPosition = Input.GetTouch(0).deltaPosition;
			
			// Move object across XY plane
			transform.Translate(-touchDeltaPosition.x * speed, -touchDeltaPosition.y * speed, 0);
		}
	}
	
	public void MoveUpButtonDown(){
		up = true;
	}
	
	public void MoveDownButtonDown() {
		down = true;
	}
	
	public void MoveLeftButtonDown() {
		left = true;
		if (!GeneralManager.godMode) {
			TurnLeft();
		}
	}
	
	public void MoveRightButtonDown() {
		right = true;
		if (!GeneralManager.godMode) {
			TurnRight();
		}
	}
	
	public void MoveUpButtonUp(){
		up = false;
	}
	
	public void MoveDownButtonUp() {
		down = false;
	}
	
	public void MoveLeftButtonUp() {
		left = false;
	}
	
	public void MoveRightButtonUp() {
		right = false;
	}

	void TryMoveUp() {
		if (transform.forward == Vector3.back) {
			MoveBack ();
		} else {
			MoveUp ();
		}
	}
	
	void TryMoveDown() {
		if (transform.forward == Vector3.forward) {
			MoveBack ();
		} else {
			MoveDown ();
		}
	}

	void TryMoveLeft() {
		if (transform.forward == Vector3.right) {
			MoveBack ();
		} else {
			MoveLeft ();
		}
	}

	void TryMoveRight() {
		if (transform.forward == Vector3.left) {
			MoveBack ();
		} else {
			MoveRight ();
		}
	}
	
	void MoveUp() {
		transform.forward = Vector3.forward;
		MoveForward ();
	}
	
	void MoveDown() {
		transform.forward = Vector3.back;
		MoveForward ();
	}
	
	void MoveLeft() {
		transform.forward = Vector3.left;
		MoveForward ();
	}
	
	void MoveRight() {
		transform.forward = Vector3.right;
		MoveForward ();
	}
	
	void TurnLeft(){
		transform.Rotate (0f, -90f, 0f);
	}

	void TurnRight(){
		transform.Rotate (0f, 90f, 0f);
	}

	void MoveForward(){
		transform.position += transform.forward * speed * Time.deltaTime;


		PlayerChicken playerScript = GetComponent<PlayerChicken> ();
		if(playerScript != null){
			playerScript.MotherMovedForward();
		}

	}

	void MoveBack(){
		transform.position -= transform.forward * speed * Time.deltaTime;


		PlayerChicken playerScript = GetComponent<PlayerChicken> ();
		if(playerScript != null){
			playerScript.MotherMovedBack();
		}

	}
}
