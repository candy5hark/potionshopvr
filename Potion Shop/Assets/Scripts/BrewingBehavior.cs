using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrewingBehavior : MonoBehaviour {

	public bool brewFinish = false;
	public bool brewCorrect = false;
	public GameObject brewing_arrow;
	public AudioClip popNoise;

	private List<string> theCauldron = new List<string>();
	private string potion_base = "empty";
	private bool using_base = false;
	private Dialogue_Activator dialogue_info;
	private string ingredient_parent;

	void resetVars(){

		brewFinish = false;
		brewCorrect = false;
		theCauldron.Clear();

		potion_base = "empty";
		using_base = false;
		brewing_arrow.GetComponent<Process_potion>().arrow.enabled = !brewing_arrow.GetComponent<Process_potion>().arrow.enabled;
		brewing_arrow.GetComponent<Process_potion>().potionBrewed = false;
		Destroy(brewing_arrow.GetComponent<Process_potion>().audioSource);
		brewing_arrow.SetActive(false);

	}

	void ingredient_in(string ingredient_name)
	{
		using_base = (ingredient_name == "heart_title" || ingredient_name == "fae_title" || ingredient_name == "fury_title");


		if(potion_base == "empty" && using_base)
		{
			potion_base = ingredient_name;
			//Debug.Log(potion_base);
			ingredient_parent = GameObject.Find(ingredient_name).transform.parent.name;
			GameObject.Find(ingredient_parent).SetActive(false);
			var audioSource = this.GetComponent<AudioSource>();
			if (audioSource == null)
			{
				audioSource = this.gameObject.AddComponent<AudioSource>();
			}

			audioSource.clip = this.popNoise;
			audioSource.Play();


		}
		else if(theCauldron.Count < 2 && !using_base){

			theCauldron.Add(ingredient_name);
			//Debug.Log(ingredient_name);
			ingredient_parent = GameObject.Find(ingredient_name).transform.parent.name;
			GameObject.Find(ingredient_parent).SetActive(false);
			var audioSource = this.GetComponent<AudioSource>();
			if (audioSource == null)
			{
				audioSource = this.gameObject.AddComponent<AudioSource>();
			}

			audioSource.clip = this.popNoise;
			audioSource.Play();


		}

		if(theCauldron.Count == 2 && potion_base != "empty")
		{
			theCauldron.Add(potion_base);
			brewFinish = true;

			dialogue_info = GameObject.Find("Talkbox").GetComponent<Dialogue_Activator>();
			brewCorrect = check_if_correct(dialogue_info.customer_id);
			//Debug.Log(brewCorrect);
			brewing_arrow.SetActive(true);


		}



	}


	bool check_if_correct(int customer_id){
		//Debug.Log(customer_id);

		switch(customer_id)
		{
		case 0:
			return (theCauldron.Contains("fury_title") && theCauldron.Contains("tea_title") && theCauldron.Contains("firefly_title"));
		case 1:
			return (theCauldron.Contains("heart_title") && theCauldron.Contains("mint_title") && theCauldron.Contains("gooshroom_title"));
		case 2:
			return (theCauldron.Contains("fae_title") && theCauldron.Contains("garlic_title") && theCauldron.Contains("angel_title"));
		case 3:
			return (theCauldron.Contains("fae_title") && theCauldron.Contains("loaf_title") && theCauldron.Contains("butter_title"));
		case 4:
			return (theCauldron.Contains("heart_title") && theCauldron.Contains("loaf_title") && theCauldron.Contains("dreams_title"));
		default:
			Debug.Log("Invalid Customer ID?");
			return false;
		}


	}

}
