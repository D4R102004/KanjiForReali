using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using System;



[CreateAssetMenu(fileName = "PlayerState", menuName = "kanjies/PlayerState", order = 0)]
public class PlayerState : ScriptableObject 
{
	public BoolVariable IsFirstTurn;
	public BoolVariable PlayerPassed;
	public FloatVariable PlayerHP;
	public StringVariable PlayerName;
	public GameEvent Destroyed;
	public GameEvent Drawn;
	public GameEvent Bounced;
	public ListOfCards Melee;
	public ListOfCards Range;
	public ListOfCards Siege;
	public ListOfCards BoostMelee;
	public ListOfCards BoostRange;
	public ListOfCards BoostSiege;
	public ListOfCards Hand;
	public ListOfCards Deck;
	public ListOfCards Graveyard;
	public ListOfCards Weather;
	public FloatVariable MeleeBoost;
	public FloatVariable RangeBoost;
	public FloatVariable SiegeBoost;
	public FloatVariable WeatherMelee;
	public FloatVariable WeatherRange;
	public FloatVariable WeatherSiege;
	public FloatVariable CollectedPower;
	public List<ListOfCards> AllFields;
	public void CleanAllFields()
	{
		for (int i = AllFields.Count - 1; i >= 0; i--)
		{
			for (int j = AllFields[i].ListCard.Count - 1; j >= 0; j--)
			{
				Destroy(AllFields[i].ListCard[j], AllFields[i]);
			}
		}
		MeleeBoost.Zero();
		RangeBoost.Zero();
		SiegeBoost.Zero();
		WeatherMelee.Zero();
		WeatherRange.Zero();
		WeatherSiege.Zero();
		CollectedPower.Zero();
	}
	public Card GetStrongestCard()
	{
		float max = -1;
		for (int i = AllFields.Count - 1; i >= 0; i--)
		{
			for (int j = AllFields[i].ListCard.Count - 1; j >= 0; j--)
			{
				if (AllFields[i].ListCard[j] is AttackingCard)
				{
				if (AllFields[i].ListCard[j].CardAttack.Value > max) max = AllFields[i].ListCard[j].CardAttack.Value;
				}
			}
		}
		for (int i = AllFields.Count - 1; i >= 0; i--)
		{
			for (int j = AllFields[i].ListCard.Count - 1; j >= 0; j--)
			{
				if (AllFields[i].ListCard[j] is AttackingCard)
				{
					if (AllFields[i].ListCard[j].CardAttack.Value == max) return AllFields[i].ListCard[j];
				}
			}
		}
		return null;
	}
	public Card GetWeakestCard()
	{
		float min = 10000;
		for (int i = AllFields.Count - 1; i >= 0; i--)
		{
			for (int j = AllFields[i].ListCard.Count - 1; j >= 0; j--)
			{
				if (AllFields[i].ListCard[j] is AttackingCard)
				{
				if (AllFields[i].ListCard[j].CardAttack.Value < min) min = AllFields[i].ListCard[j].CardAttack.Value;
				}
			}
		}
		for (int i = AllFields.Count - 1; i >= 0; i--)
		{
			for (int j = AllFields[i].ListCard.Count - 1; j >= 0; j--)
			{
				if (AllFields[i].ListCard[j] is AttackingCard)
				{
					if (AllFields[i].ListCard[j].CardAttack.Value == min) return AllFields[i].ListCard[j];
				}
			}
		}
		return null;
	}
	public List<Card> GetAllWithSameName(string name)
	{
		List<Card> AllName = new List<Card>();
		for (int i = AllFields.Count - 1; i >= 0; i--)
		{
			for (int j = AllFields[i].ListCard.Count - 1; j >= 0; j--)
			{
				if (AllFields[i].ListCard[j].CardName.Word == name) AllName.Add(AllFields[i].ListCard[j]);
			}
		}
		return AllName;
	}
	public ListOfCards GetCardLocation(Card c)
	{
		for (int i = AllFields.Count - 1; i >= 0; i--)
		{
			if (AllFields[i].ListCard.Contains(c)) return AllFields[i];
		}
		return null;
	}
	public ListOfCards TypeGetZone(StringVariable ZoneType)
	{
		for (int i = AllFields.Count - 1; i >= 0; i--)
		{
			if (ZoneType == AllFields[i].ListType) return AllFields[i];
		}
		return null;
	}
	public void ApplyBoost(Card card, FloatVariable Boost, FloatVariable Weather)
	{
		if (card is AttackingCard)
		{
		card.CardAttack.Value += Boost.Value;
		card.CardAttack.Value -= Weather.Value;
		if (card.CardAttack.Value < 0) card.CardAttack.Zero();
		}
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
		Weather.Restart();
		Hand.Restart();
		Deck.Restart();
		Graveyard.Restart();
		MeleeBoost.Zero();
		RangeBoost.Zero();
		SiegeBoost.Zero();
		WeatherMelee.Zero();
		WeatherRange.Zero();
		WeatherSiege.Zero();
		CollectedPower.Zero();
	}
	public void Draw()
	{
		if (Deck.ListCard.Count > 0 && Hand.ListCard.Count < 10)
		{
		Card c = Deck.ListCard[0];
		Hand.Add(c);
		Deck.Remove(c);
		Drawn.Raise(null, c, null, null);
		}
	}
	public void ListSwap(ListOfCards l)
	{
		System.Random rng = new System.Random();
		int n = l.ListCard.Count;
		while (n > 1)
		{
			n--;
			int k = rng.Next(n + 1);
			Card c = l.ListCard[k];
			l.ListCard[k] = l.ListCard[n];
			l.ListCard[n] = c;
		}
	}
	public void Shuffle()
	{
		ListSwap(Deck);
	}
	public void DestroyWeather(string type, FloatVariable reduce)
	{
		for (int i = Weather.ListCard.Count - 1; i >= 0; i--)
		{
			if (Weather.ListCard[i].CardFaccion.Word == type)
			{
			    reduce.Value -= Weather.ListCard[i].CardAttack.Value;
				Weather.ListCard[i].HasBeenPlayed();
				Destroyed.Raise(null, Weather.ListCard[i], null, null);
				Weather.ListCard.RemoveAt(i);
			}
		}
		Update();
	}
	public void Destroy(Card c, ListOfCards field)
	{
		if (field.ListCard.Contains(c))
		{
			Graveyard.Add(c);
			c.HasBeenPlayed();
			field.Remove(c);
			c.Normalize();
			Destroyed.Raise(null, c, null, null);
		}
	}
	public void DestroyBoost(Card c, ListOfCards field, FloatVariable reduce)
	{
		if (field.ListCard.Contains(c))
		{
			Debug.Log("Destroying " + c.CardName.Word + " in " + field.ListName.Word);
		for (int i = field.ListCard.Count - 1; i >= 0; i--)
		{
			if (field.ListCard[i] == c)
			{
				reduce.Value -= field.ListCard[i].CardAttack.Value;
				field.ListCard[i].HasBeenPlayed();
				Destroyed.Raise(null, field.ListCard[i], null, null);
				Debug.Log("We have destroyed it");
				field.ListCard.RemoveAt(i);
			}
		}
		}
		Update();
	}
	public void SearchDestroyBoost(Card c)
	{
		DestroyBoost(c, BoostMelee, MeleeBoost);
		DestroyBoost(c, BoostRange, RangeBoost);
		DestroyBoost(c, BoostSiege, SiegeBoost);
	}
	public void Update()
	{
		UpdateField(Melee, MeleeBoost, WeatherMelee);
		UpdateField(Range, RangeBoost, WeatherRange);
		UpdateField(Siege, SiegeBoost, WeatherSiege);
		Calculate();
	}
	public void UpdateField(ListOfCards field, FloatVariable buff, FloatVariable debuff)
	{
		for (int i = field.ListCard.Count - 1; i >= 0; i--)
		{
			field.ListCard[i].Normalize();
			ApplyBoost(field.ListCard[i], buff, debuff);
		}
	}
	public void FindAndEliminate(Card card, ListOfCards l)
	{
		for (int i = l.ListCard.Count - 1; i >= 0; i--)
		{
			if (l.ListCard[i] == card)
			{
				l.ListCard.RemoveAt(i);
				Destroyed.Raise(null, l.ListCard[i], Graveyard.ListName, null);
			}
		}
	}
	public void ReturnToTheHand(Card card, ListOfCards field)
	{
		if (field.ListCard.Contains(card))
		{
			field.Remove(card);
			Hand.Add(card);
			card.HasBeenPlaced.False();
			card.Normalize();
			Bounced.Raise(null, card, null, null);
		}
	}
	
	public Card FindStrongest(ListOfCards field)
	{
		float max = 0;
		for (int i = field.ListCard.Count - 1; i >= 0; i--)
		{
			if (field.ListCard[i].CardAttack.Value > max) max = field.ListCard[i].CardAttack.Value;
		}
		return SearchForAttack(max, field);
	}
	public Card SearchForAttack(float n, ListOfCards field)
	{
		for (int i = field.ListCard.Count - 1; i >= 0; i--)
		{
			if (field.ListCard[i].CardAttack.Value == n) return field.ListCard[i];
		}
		return null;
	}
	public void Calculate()
	{
		CollectedPower.Value = 0;
		for (int i = Melee.ListCard.Count - 1; i >= 0; i--)
		{
			CollectedPower.Value += Melee.ListCard[i].CardAttack.Value;
		}
		for (int i = Range.ListCard.Count - 1; i >= 0; i--)
		{
			CollectedPower.Value += Range.ListCard[i].CardAttack.Value;
		}
		for (int i = Siege.ListCard.Count - 1; i >= 0; i--)
		{
			CollectedPower.Value += Siege.ListCard[i].CardAttack.Value;
		}
	}
} 
