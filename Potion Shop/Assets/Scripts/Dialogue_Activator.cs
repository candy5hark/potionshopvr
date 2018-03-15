using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dialogue_Activator : MonoBehaviour {



	public GameObject [] text_alert;
	public GameObject [] text_object;
	public GameObject [] speech_bubble;
	public GameObject line_trigger;
	public Animator [] face;
	public int customer_id = 0;

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
		if(clickable && Input.GetMouseButtonDown(0) && text_alert[customer_id].activeSelf){
			
			text_alert[customer_id].SetActive(false);
			speech_bubble[customer_id].SetActive(true);
			face[customer_id].SetBool("Talking", true);


		}

		if(clickable && text_object[customer_id].GetComponent<Text_Printer>().text_printed_flag && Input.GetMouseButtonDown(0)){

			text_object[customer_id].SendMessage("PrepareNextLine");
			face[customer_id].SetBool("Talking", true);


		}

	}

}
