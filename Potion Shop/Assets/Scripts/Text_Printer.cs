using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Text_Printer : MonoBehaviour {

	public float letterPause = 0.2f;
	public AudioClip talk_sound;

	public string [] intro;
	public string [] wrong_potion_text;
	public string [] right_potion_text;
	public bool text_printed_flag = false;

	public int dialogue_number = 0;
	public int success_fail_dialogue_number = 0;

	public Animator face;


	// Use this for initialization
	void Start () {
		StartCoroutine(TypeText());
	}

	void PrepareNextLine(){


		if( GameObject.Find("time_to_brew_arrow") && GameObject.Find("time_to_brew_arrow").GetComponent<Process_potion>().potionBrewed )
		{

			GetComponent<TextMesh>().text = "";


			if( GameObject.Find("time_to_brew_arrow").GetComponent<Process_potion>().potionCorrect ){
				if(success_fail_dialogue_number < right_potion_text.Length-1){
					StartCoroutine(TypeTextCorrect());

					success_fail_dialogue_number++;
				}
				else{
					StartCoroutine(TypeTextCorrect());

					success_fail_dialogue_number = 0;
				}

				//StartCoroutine(TypeTextCorrect());
			}
			else{
				if(success_fail_dialogue_number < wrong_potion_text.Length-1){
					StartCoroutine(TypeTextIncorrect());

					success_fail_dialogue_number++;
				}
				else{
					StartCoroutine(TypeTextIncorrect());

					success_fail_dialogue_number = 0;

				}
				//StartCoroutine(TypeTextIncorrect());

			}
		}
		else if( dialogue_number < intro.Length-1 )
		{
			dialogue_number++;
			GetComponent<TextMesh>().text = "";
			StartCoroutine(TypeText());
		}
		else{
			dialogue_number = 0;
			GetComponent<TextMesh>().text = "";
			StartCoroutine(TypeText());
		}

	}


	IEnumerator TypeText () {
		foreach (char letter in intro[dialogue_number].ToCharArray()) {
			text_printed_flag = false;
			if(letter == '~'){
			GetComponent<TextMesh>().text += '\n';
			}
			else{
			GetComponent<TextMesh>().text += letter;
			}

			if(letter == ' ' || letter == '~')
			{}
			else{
				var audioSource = this.GetComponent<AudioSource>();
				if (audioSource == null)
				{
					audioSource = this.gameObject.AddComponent<AudioSource>();
				}

				audioSource.clip = this.talk_sound;
				audioSource.Play();
			}
				
			yield return 0;
			yield return new WaitForSeconds (letterPause);
		}      
		text_printed_flag = true;
		face.SetBool("Talking", false);

	}


	IEnumerator TypeTextIncorrect () {
		foreach (char letter in wrong_potion_text[success_fail_dialogue_number].ToCharArray()) {
			text_printed_flag = false;
			if(letter == '~'){
				GetComponent<TextMesh>().text += '\n';
			}
			else{
				GetComponent<TextMesh>().text += letter;
			}

			if(letter == ' ' || letter == '~')
			{}
			else{
				var audioSource = this.GetComponent<AudioSource>();
				if (audioSource == null)
				{
					audioSource = this.gameObject.AddComponent<AudioSource>();
				}

				audioSource.clip = this.talk_sound;
				audioSource.Play();
			}

			yield return 0;
			yield return new WaitForSeconds (letterPause);
		}      
		text_printed_flag = true;
		face.SetBool("Talking", false);

	}


	IEnumerator TypeTextCorrect () {
		foreach (char letter in right_potion_text[success_fail_dialogue_number].ToCharArray()) {
			text_printed_flag = false;
			if(letter == '~'){
				GetComponent<TextMesh>().text += '\n';
			}
			else{
				GetComponent<TextMesh>().text += letter;
			}

			if(letter == ' ' || letter == '~')
			{}
			else{
				var audioSource = this.GetComponent<AudioSource>();
				if (audioSource == null)
				{
					audioSource = this.gameObject.AddComponent<AudioSource>();
				}

				audioSource.clip = this.talk_sound;
				audioSource.Play();
			}

			yield return 0;
			yield return new WaitForSeconds (letterPause);
		}      
		text_printed_flag = true;
		face.SetBool("Talking", false);

	}

}
