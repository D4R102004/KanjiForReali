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
	public StringVariable ToPlaceFieldType;
	public GameEvent RemovedCard;
	public GameEvent TurnSwap;
	public GameEvent ChangeTexts;
	public GameEvent Create;
	public GameEvent Placed;
	private void Start() 
	{

	}
	public void AttemptingPlacement(Component sender, object data1, object data2, object data3)
	{
		Debug.Log("Trying to place a card");
		if (ToPlaceField != null)
		{
			PlaceCard(this, data1, data2, data3);
			SwapPlayers();
		}
	}
	public void SwapPlayers()
	{
		PlayerState temp = CurrentPlayer;
		CurrentPlayer = StandByPlayer;
		StandByPlayer = temp;
		TurnSwap.Raise(this, null, swapper, null);
		ChangeTexts.Raise(this, CurrentPlayer, StandByPlayer, null);
	}
	public void PlaceCard(Component sender, object data1, object data2, object data3)
	{
		Debug.Log("Placing in " + ToPlaceField.Word);
		Card card = (Card)data1;
		RemovedCard.Raise(this, card, ToPlaceField, null);
		card.Place(CurrentPlayer, StandByPlayer, ToPlaceField, ToPlaceFieldType);
		card.ApplyEffect(CurrentPlayer, StandByPlayer, ToPlaceField, ToPlaceFieldType);
		CalculatePlayers();
	}
	public void EstablishField(Component Sender, object data1, object data2, object data3)
	{
		StringVariable name = (StringVariable)data1;
		ToPlaceField = name;
		StringVariable type = (StringVariable)data2;
		ToPlaceFieldType = type;
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
	public void CalculatePlayers()
	{
		CurrentPlayer.Calculate();
		StandByPlayer.Calculate();
	}
	public void CreateBoost(Component sender, object data1, object data2, object data3)
	{
		Card c = (Card)data1;
		if (c != null) Debug.Log(c.CardName.Word + " is not null");
		Create.Raise(this, c, DownHand, null);
		StringVariable s = (StringVariable)data2;
		ToPlaceField = s;
		PlaceCard(this, c, null, null);
	}
	public void RemoveBoost(Component sender, object data1, object data2, object data3)
	{
		Card c = (Card)data1;
		CurrentPlayer.SearchDestroyBoost(c);
		StandByPlayer.SearchDestroyBoost(c);
	}
}
