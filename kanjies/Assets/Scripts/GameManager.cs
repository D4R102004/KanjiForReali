using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngineInternal;

public class GameManager : MonoBehaviour 
{
	
	public GameMechanics Mechanics;
	public GameObject m;
	public GameObject r;
	public GameObject s;
	public GameObject WeatherZone;
	public WeatherModifiers wetmod;
	private void Awake()
	{
		WeatherZone = GameObject.Find("Weather");

	}


	// Use this for initialization
	void Start () 
	{
	}
	
	// Update is called once per frame
	void Update () 
	{ 

		
	}
	public void AttackGiver(CardProperties card)
	{
		Mechanics.CollectedPower += card.power;
		Debug.Log("Current Power == " + Mechanics.CollectedPower); 
	}
	public void BoostGiver(CardProperties card)
	{
		if (card.faccion == "Melee")
		{
			Mechanics.BoostMelee = card.power;
		}
		else if (card.faccion == "Range")
		{
			Mechanics.BoostRange = card.power;
		}
		else Mechanics.BoostSiege = card.power;
	}
	public void WeatherClause(CardProperties card)
	{
		if (card.faccion == "Melee")
		{
			Mechanics.WeatherMelee += card.power;
			wetmod.Melee = 1;
		}
		else if (card.faccion == "Range") 
		{
			Mechanics.WeatherRange += card.power;
			wetmod.Range = 1;
		}
		else 
		{
			Mechanics.WeatherSiege += card.power;
			wetmod.Melee = 1;
		}
	}
	public void PlayerEnd(GameMechanics logic, FieldProperties m1, FieldProperties r1, FieldProperties s1)
	{
		WeatherTransform();
		for (int i = 0; i < m1.counter; i++)
		{
			logic.CollectedPower += logic.BoostMelee;
			logic.CollectedPower -= logic.WeatherMelee;
		}
		for (int i = 0; i < r1.counter; i++)
		{
			logic.CollectedPower += logic.BoostRange;
			logic.CollectedPower -= logic.WeatherRange;
		}
		for (int i = 0; i < s1.counter; i++)
		{
			logic.CollectedPower += logic.BoostSiege;
			logic.CollectedPower -= logic.WeatherSiege;
		}
		
	}
	public void Clear(string type, int number)
	{
		if (type == "Melee") Mechanics.WeatherMelee -= number;
		else if (type == "Range") Mechanics.WeatherRange -= number;
		else Mechanics.WeatherSiege -= number;
	}
	public void ConfirmWeather(GameObject zone)
	{
		foreach (Transform child in zone.transform)
		{
			if (child != null)
			{
			string type = child.GetComponent<DragDropKan>().cardatt.faccion;
			int i = child.GetComponent<DragDropKan>().cardatt.power;
			if (type == "Melee") wetmod.Melee += i;
			else if (type == "Range") wetmod.Range += i;
			else wetmod.Siege += i;
			}
		}
	}
	public void ReduceWeather(CardProperties cardatt)
	{
		if (cardatt.faccion == "Melee") wetmod.Melee = 0;
		else if (cardatt.faccion == "Range") wetmod.Range = 0;
		else wetmod.Siege = 0;
	}
	public void WeatherTransform()
	{
		if (wetmod.Melee == 0) Mechanics.WeatherMelee = 0;
		else if (wetmod.Melee == 0) Mechanics.WeatherRange = 0;
		else if (wetmod.Melee == 0) Mechanics.WeatherSiege = 0;
	}
	
	/*public void Effect(CardProperties card)
	{
		if (card.CardID == 1)
		{
			PlayerMeleePower += 2;
			Debug.Log("Current Melee" + PlayerMeleePower);
		}
	}*/

}
