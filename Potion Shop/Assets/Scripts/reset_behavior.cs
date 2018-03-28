using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class reset_behavior : MonoBehaviour {

	public GameObject [] bases;
	public GameObject brew;
	public GameObject mistake_potion;
	public GameObject [] correct_potion;
	public GameObject [] characters;

	public int char_id;

	void reset_after_loss(){
		foreach (Transform child in transform)
		{
			child.gameObject.SetActive( true );
		}
		for(int i = 0; i < 3; i++)
		{
			bases[i].SetActive(true);
		}

		brew.SendMessage("resetVars");
		mistake_potion.SetActive(false);

	}


	void reset_after_win(){
		char_id = GameObject.Find("Talkbox").GetComponent<Dialogue_Activator>().customer_id;
		characters[char_id].transform.Translate(-16, 0, 0);
		foreach (Transform child in transform)
		{
			child.gameObject.SetActive( true );
		}
		for(int i = 0; i < 3; i++)
		{
			bases[i].SetActive(true);
		}

		brew.SendMessage("resetVars");
		correct_potion[char_id].SetActive(false);
		mistake_potion.SetActive(false);
		char_id++;
		characters[char_id].transform.Translate(-16, 0, 0);
		GameObject.Find("Talkbox").GetComponent<Dialogue_Activator>().customer_id = char_id;
		brew.SetActive(false);
		if(char_id == 4){
			GameObject.Find("Broken_witch").GetComponent<FloatBehavior>().floatStrength = .1f;
		}

	}



}
