using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrewingBehavior : MonoBehaviour {

	public bool brewFinish = false;
	public bool brewCorrect = false;

	private List<string> theCauldron = new List<string>();
	private string potion_base = "empty";
	private bool using_base = false;

	void ingredient_in(string ingredient_name)
	{
		using_base = (ingredient_name == "heart_title" || ingredient_name == "fae_title" || ingredient_name == "fury_title");


		if(potion_base == "empty" && using_base)
		{
			potion_base = ingredient_name;
			Debug.Log(potion_base);

		}
		else if(theCauldron.Count < 2 && !using_base){

			theCauldron.Add(ingredient_name);
			Debug.Log(ingredient_name);


		}

		if(theCauldron.Count == 2 && potion_base != "empty")
		{
			theCauldron.Add(potion_base);
			brewFinish = true;




		}



	}

}
