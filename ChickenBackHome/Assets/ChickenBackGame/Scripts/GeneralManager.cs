using UnityEngine;
using System.Collections;

public class GeneralManager : MonoBehaviour {

	public static bool godMode;
	public static int score;
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {

	}

	public static void StartGame(){
		Application.LoadLevel ("Level01");
	}

	public static void EndGame(){
		Application.LoadLevel ("ScoreScene");
	}

	public static void HomeScene(){
		if(Application.loadedLevelName == "ScoreScene"){
			Application.LoadLevel("HomeScene");
		}
	}
}
