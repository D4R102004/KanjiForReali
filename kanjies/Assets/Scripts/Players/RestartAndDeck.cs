using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RestartAndDeck : MonoBehaviour 
{
	public PlayerState P1;
	public PlayerState P2;
	public ListOfCards P1Cards;
	public ListOfCards P2Cards;
	public FloatReference StartingHandSize;
	private void Start() 
	{
		P1.Restart();
		P2.Restart();
		DeckStarter();
		P1.Shuffle();
		P2.Shuffle();
		StartingHand();
	}
	public void DeckStarter()
	{
		PlayerDeckStarter();
		OppDeckStarter();
	}
	public void OppDeckStarter()
	{
		for (int i = P2Cards.ListCard.Count - 1; i >= 0; i--)
		{
			Card c = P2Cards.ListCard[i];
			c.HasBeenPlaced.False();
			c.Normalize();
			c.SetOwner(P2.PlayerName);
			P2.Deck.Add(c);
		}
	}
	public void PlayerDeckStarter()
	{
		for (int i = P1Cards.ListCard.Count - 1; i >= 0; i--)
		{
			Card c = P1Cards.ListCard[i];
			c.HasBeenPlaced.False();
			c.Normalize();
			c.SetOwner(P1.PlayerName);
			P1.Deck.Add(c);
		}
	}
	public void StartingHand()
	{
		for (int i = 0; i < StartingHandSize.Value; i++)
		{
			P1.Draw();
			P2.Draw();
		}
	}
}
