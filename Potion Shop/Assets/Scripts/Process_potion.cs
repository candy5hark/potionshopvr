using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Process_potion : MonoBehaviour {

	public GameObject line_trigger;
	public AudioClip correct;
	public AudioClip incorrect;
	public bool potionCorrect;
	public bool potionBrewed = false;
	public AudioSource audioSource;
	public GameObject mistake_potion;
	public GameObject [] correct_potion;


	private bool can_click;
	public SpriteRenderer arrow;

	void Start(){
		arrow = GetComponent<SpriteRenderer>();

	}

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

			if(!potionBrewed){
				arrow.enabled = !arrow.enabled;
				if(GameObject.Find("Brew_Mode").GetComponent<BrewingBehavior>().brewCorrect)
				{
					potionCorrect = true;
					//var audioSource = this.GetComponent<AudioSource>();
					if (audioSource == null)
					{
						audioSource = this.gameObject.AddComponent<AudioSource>();
					}

					audioSource.clip = this.correct;
					audioSource.Play();
					correct_potion[GameObject.Find("Talkbox").GetComponent<Dialogue_Activator>().customer_id].SetActive(true);
				}
				else
				{
					potionCorrect = false;
					//var audioSource = this.GetComponent<AudioSource>();
					if (audioSource == null)
					{
						audioSource = this.gameObject.AddComponent<AudioSource>();
					}

					audioSource.clip = this.incorrect;
					audioSource.Play();
					Debug.Log(can_click);
					mistake_potion.SetActive(true);
				}
			}
			potionBrewed = true;



		}

		
	}
}
