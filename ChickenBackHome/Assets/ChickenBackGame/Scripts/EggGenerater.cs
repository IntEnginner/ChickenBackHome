using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EggGenerater : MonoBehaviour {

	public GameObject eggTemplate;
	public Transform[] eggHomeTransitions;


	public float generateInterval;
	float generateCounter;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		UpdateGeneration ();
	}

	void UpdateGeneration(){
		if(generateCounter >= generateInterval){
			generateCounter = 0;
			GenerateEgg();
			UpdateDifficulty();
		}
		generateCounter += Time.deltaTime;
	}

	void UpdateDifficulty(){
		generateInterval -= Time.deltaTime;
	}

	void GenerateEgg(){
		if(eggTemplate != null 
		   && eggHomeTransitions != null 
		   && eggHomeTransitions.Length > 0){

			int eggTargetTrans = Random.Range(0, eggHomeTransitions.Length);


			GameObject egg = Instantiate(eggTemplate);
			egg.transform.position = eggHomeTransitions[eggTargetTrans].position;
		}
	}
}
