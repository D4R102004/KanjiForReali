using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
	public StringVariable DownGraveyard;
	public StringVariable UpGraveyard;
	public StringVariable UpHand;
	public StringVariable DownHand;
	public StringVariable swapper;
	public PlayerState CurrentPlayer;
	public PlayerState StandByPlayer;
	public StringVariable ToPlaceField;
	public GameEvent RemovedCard;
	public GameEvent TurnSwap;
	private void Start() 
	{

	}
	public void SwapPlayers()
	{
		PlayerState temp = CurrentPlayer;
		CurrentPlayer = StandByPlayer;
		StandByPlayer = temp;
		TurnSwap.Raise(this, null, swapper, null);
	}
	public void PlaceCard(Component sender, object data1, object data2, object data3)
	{
		Debug.Log("Trying to place a card");
		if (ToPlaceField != null)
		{
		Debug.Log("Placing in " + ToPlaceField.Word);
		Card card = (Card)data1;
		card.Place(CurrentPlayer, StandByPlayer, ToPlaceField);
		RemovedCard.Raise(this, card, ToPlaceField, null);
		SwapPlayers();
		}
	}
	public void EstablishField(Component Sender, object data1, object data2, object data3)
	{
		StringVariable s = (StringVariable)data1;
		ToPlaceField = s;
	}
	public void Destroyed(Component sender, object data1, object data2, object data3)
	{
		Card c = (Card)data1;
		StringVariable s = null;
		if (c.CardOwner == CurrentPlayer.PlayerName) s = DownGraveyard;
		else s = UpGraveyard;
		Debug.Log("Sending " + c.CardName.Word + " to " + s.Word);
		RemovedCard.Raise(this, c, s, null);
	}
	public void Bounce(Component sender, object data1, object data2, object data3)
	{
		Card c = (Card)data1;
		StringVariable s = null;
		if (c.CardOwner == CurrentPlayer.PlayerName) s = DownHand;
		else s = UpHand;
		Debug.Log("Bouncing " + c.CardName.Word + " to " + s.Word);
		RemovedCard.Raise(this, c, s, null);
	}
	
}
