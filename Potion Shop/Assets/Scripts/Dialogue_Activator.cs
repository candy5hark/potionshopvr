﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dialogue_Activator : MonoBehaviour {



	public GameObject text_alert;
	public GameObject speech_bubble;
	public GameObject line_trigger;
	public Animator face;

	private bool clickable = false;

	void OnTriggerEnter(Collider col){
		if(col.gameObject == line_trigger)
		{
			clickable = true;
		}
	}
	void OnTriggerExit(Collider col){
		if(col.gameObject == line_trigger)
		{
			clickable = false;
		}
	}

	void Update()
	{
		if(clickable && Input.GetMouseButtonDown(0)){
			
			text_alert.SetActive(false);
			speech_bubble.SetActive(true);
			face.SetBool("Talking", true);

		}

	}

}
