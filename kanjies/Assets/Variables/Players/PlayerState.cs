using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using System;



[CreateAssetMenu(fileName = "PlayerState", menuName = "kanjies/PlayerState", order = 0)]
public class PlayerState : ScriptableObject 
{
	public StringVariable PlayerName;
	public GameEvent Destroyed;
	public GameEvent Create;
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
		Weather.Restart();
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
	public void Draw()
	{
		Debug.Log("Drawing");
		Card c = Deck.ListCard[0];
		Hand.Add(c);
		Deck.Remove(c);
		Create.Raise(null, c, Hand.ListName, null);
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
				Destroyed.Raise(null, Weather.ListCard[i], null, null);
				Weather.ListCard.RemoveAt(i);
			}
		}
		Update();
	}
	public void Update()
	{
		UpdateField(Melee, MeleeBoost, WeatherMelee);
		UpdateField(Range, RangeBoost, WeatherRange);
		UpdateField(Siege, SiegeBoost, WeatherSiege);
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
			Bounced.Raise(null, card, null, null);
		}
	}
	public void Decoy(Card card, ListOfCards field)
	{
		Card c = FindStrongest(field);
		ReturnToTheHand(c, field);
		field.Add(card);
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
} 
