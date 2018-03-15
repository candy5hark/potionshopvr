using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Text_Printer : MonoBehaviour {

	public float letterPause = 0.2f;
	public AudioClip talk_sound;

	public string [] intro;
	public string wrong_potion_text;
	public string [] right_poition_text;
	public bool text_printed_flag = false;

	public int dialogue_number = 0;

	public Animator face;


	// Use this for initialization
	void Start () {
		StartCoroutine(TypeText());
	}

	void PrepareNextLine(){
		if( dialogue_number < intro.Length-1 )
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

}
