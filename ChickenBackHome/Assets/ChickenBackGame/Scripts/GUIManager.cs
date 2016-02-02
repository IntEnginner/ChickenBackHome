using UnityEngine;
using System.Collections;

public class GUIManager : MonoBehaviour 
{	
	[HideInInspector]
	public int chickenHomed;
	public int eggsInLevel;
	public int chickenInTail;


	void Start()
	{	
	}

	void OnGUI()
	{
		GUILayout.Space(5f);

		GUILayout.Label ("Home: " + chickenHomed);
		GUILayout.Label ("Tail: " + chickenInTail);
	}
}