using System.Collections;
using System.Collections.Generic;
using UnityEngine;



[CreateAssetMenu(fileName = "PlayerState", menuName = "kanjies/PlayerState", order = 0)]
public class PlayerState : ScriptableObject 
{
	public ListOfCards Melee;
	public ListOfCards Range;
	public ListOfCards Siege;
	public ListOfCards BoostMelee;
	public ListOfCards BoostRange;
	public ListOfCards BoostSiege;
	public ListOfCards Hand;
	public ListOfCards Deck;
	public ListOfCards Weather;
	public FloatVariable MeleeBoost;
	public FloatVariable RangeBoost;
	public FloatVariable SiegeBoost;
	public FloatVariable WeatherMelee;
	public FloatVariable WeatherRange;
	public FloatVariable WeatherSiege;
	public FloatVariable CollectedPower;
	public void ApplyBoost(Card card, FloatVariable Boost, FloatVariable Weather)
	{
		card.CardAttack.Value += Boost.Value;
		card.CardAttack.Value -= Weather.Value;
		if (card.CardAttack.Value < 0) card.CardAttack.Zero();
	}
	public void InsertBoost(Card card, FloatVariable Boost)
	{
		Boost.Value += card.CardAttack.Value;
	}
	public void IterateField(float n, ListOfCards Field)
	{
		for (int i = Field.ListCard.Count - 1; i >= 0; i--)
		{
			Field.ListCard[i].CardAttack.Value += n;
			if (Field.ListCard[i].CardAttack.Value < 0) Field.ListCard[i].CardAttack.Zero();
		}
	}
	public void Restart()
	{
		Melee.Restart();
		Range.Restart();
		Siege.Restart();
		BoostMelee.Restart();
		BoostRange.Restart();
		BoostSiege.Restart();
		Hand.Restart();
		Deck.Restart();
		MeleeBoost.Zero();
		RangeBoost.Zero();
		SiegeBoost.Zero();
		WeatherMelee.Zero();
		WeatherRange.Zero();
		WeatherSiege.Zero();
		CollectedPower.Zero();
	}
} 
