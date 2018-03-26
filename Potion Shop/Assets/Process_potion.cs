using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Process_potion : MonoBehaviour {

	public GameObject line_trigger;
	public AudioClip correct;
	public AudioClip incorrect;
	public bool potionCorrect;
	public bool potionBrewed = false;


	private bool can_click;

	void OnTriggerEnter(Collider col){
		if(col.gameObject == line_trigger)
		{
			can_click = true;
		}
	}
	void OnTriggerExit(Collider col){
		if(col.gameObject == line_trigger)
		{
			can_click = false;
		}
	}
	
	// Update is called once per frame
	void Update () {

		if( can_click && Input.GetMouseButtonDown(0)){

			potionBrewed = true;

			if(GameObject.Find("Brew_Mode").GetComponent<BrewingBehavior>().brewCorrect)
			{
				potionCorrect = true;
				var audioSource = this.GetComponent<AudioSource>();
				if (audioSource == null)
				{
					audioSource = this.gameObject.AddComponent<AudioSource>();
				}

				audioSource.clip = this.correct;
				audioSource.Play();
			}
			else
			{
				potionCorrect = false;
				var audioSource = this.GetComponent<AudioSource>();
				if (audioSource == null)
				{
					audioSource = this.gameObject.AddComponent<AudioSource>();
				}

				audioSource.clip = this.incorrect;
				audioSource.Play();


			}



		}

		
	}
}
