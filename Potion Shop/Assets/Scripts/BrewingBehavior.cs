using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrewingBehavior : MonoBehaviour {

	public bool brewFinish = false;
	public bool brewCorrect = false;

	private List<string> theCauldron = new List<string>();
	private string potion_base = "empty";
	private bool using_base = false;
	private Dialogue_Activator dialogue_info;
	private string ingredient_parent;

	void ingredient_in(string ingredient_name)
	{
		using_base = (ingredient_name == "heart_title" || ingredient_name == "fae_title" || ingredient_name == "fury_title");


		if(potion_base == "empty" && using_base)
		{
			potion_base = ingredient_name;
			Debug.Log(potion_base);
			ingredient_parent = GameObject.Find(ingredient_name).transform.parent.name;
			GameObject.Find(ingredient_parent).SetActive(false);


		}
		else if(theCauldron.Count < 2 && !using_base){

			theCauldron.Add(ingredient_name);
			Debug.Log(ingredient_name);
			ingredient_parent = GameObject.Find(ingredient_name).transform.parent.name;
			GameObject.Find(ingredient_parent).SetActive(false);


		}

		if(theCauldron.Count == 2 && potion_base != "empty")
		{
			theCauldron.Add(potion_base);
			brewFinish = true;

			dialogue_info = GameObject.Find("Talkbox").GetComponent<Dialogue_Activator>();
			brewCorrect = check_if_correct(dialogue_info.customer_id);
			Debug.Log(brewCorrect);


		}



	}


	bool check_if_correct(int customer_id){


		switch(customer_id)
		{
		case 0:
			return (theCauldron.Contains("fury_title") && theCauldron.Contains("tea_title") && theCauldron.Contains("firefly_title"));
		case 1:
			return (theCauldron.Contains("fury_title") && theCauldron.Contains("tea_title") && theCauldron.Contains("firefly_title"));
		default:
			Debug.Log("Invalid Customer ID?");
			return false;
		}


	}

}
