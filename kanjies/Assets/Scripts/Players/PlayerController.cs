using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
	public StringVariable swapper;
	public PlayerState CurrentPlayer;
	public PlayerState StandByPlayer;
	public StringVariable ToPlaceField;
	public GameEvent RemovedCard;
	public GameEvent TurnSwap;
	private void Start() {
		CurrentPlayer.Restart();
		StandByPlayer.Restart();
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
}
