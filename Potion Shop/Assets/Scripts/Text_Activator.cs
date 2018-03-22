using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Text_Activator : MonoBehaviour {

	public GameObject ingredient_info;
	public GameObject line_trigger;
	public GameObject brewMode;

	
	void OnTriggerEnter(Collider col){
		if(col.gameObject == line_trigger)
		{
			ingredient_info.SetActive(true);
		}
	}
	void OnTriggerExit(Collider col){
		if(col.gameObject == line_trigger)
		{
			ingredient_info.SetActive(false);
		}
	}

	void Update(){
		if(ingredient_info.activeSelf && brewMode.activeSelf && Input.GetMouseButtonDown(0)){
			//code for inserting object into cauldron
			//check if cauldron has 2 ingredients and 1 base first.
			Debug.Log("This Works", brewMode);


		}


	}

}
