using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Text_Activator : MonoBehaviour {

	public GameObject ingredient_info;
	public GameObject line_trigger;

	
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

}
