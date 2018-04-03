using System.Collections;
using System.Collections.Generic;
using VRTK;
using UnityEngine;

public class Dialogue_Activator : MonoBehaviour {



	public GameObject [] text_alert;
	public GameObject [] text_object;
	public GameObject [] speech_bubble;
	public GameObject line_trigger;
	public Animator [] face;
	public int customer_id = 0;
	public GameObject brewMode;

	private bool clickable = false;
	private bool touchpad_held_down = false;

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


		if(text_alert[customer_id].activeSelf & face[customer_id].GetBool("Talking"))
		{
			face[customer_id].SetBool("Talking", false);
		}
		if(clickable && ( Input.GetMouseButtonDown(0) || GameObject.Find("LeftController").GetComponent<VRTK_ControllerEvents>().triggerClicked || GameObject.Find("RightController").GetComponent<VRTK_ControllerEvents>().triggerClicked) && text_alert[customer_id].activeSelf){
			
			text_alert[customer_id].SetActive(false);
			speech_bubble[customer_id].SetActive(true);
			face[customer_id].SetBool("Talking", true);


		}

		if(clickable && text_object[customer_id].GetComponent<Text_Printer>().text_printed_flag && ( Input.GetMouseButtonDown(0) ||GameObject.Find("LeftController").GetComponent<VRTK_ControllerEvents>().triggerPressed || GameObject.Find("RightController").GetComponent<VRTK_ControllerEvents>().triggerPressed)){

			text_object[customer_id].SendMessage("PrepareNextLine");
			face[customer_id].SetBool("Talking", true);
			if(!brewMode.activeSelf){
				brewMode.SetActive(true);
			}
		}



	}

}
