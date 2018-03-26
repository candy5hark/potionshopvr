using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotionGuide : MonoBehaviour {

	public List<string> correct_ingredients = new List<string>();


	List<string> populate_ingredient_checker (int customer_id) {

		switch(customer_id)
		{
		case 0:
			correct_ingredients.Add("fury_title");
			correct_ingredients.Add("tea_title");
			correct_ingredients.Add("firefly_title");
			break;
		case 1:
			correct_ingredients.Add("fury_title");
			correct_ingredients.Add("tea_title");
			correct_ingredients.Add("firefly_title");
			break;
		default:
			break;
		}


		return correct_ingredients;

	}
	

}
