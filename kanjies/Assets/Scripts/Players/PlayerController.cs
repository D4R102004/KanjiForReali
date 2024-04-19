using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour 
{
	public StringVariable DownDeck;
	public StringVariable UpDeck;
	public StringVariable DownHero;
	public StringVariable UpHero;
	public StringVariable DownOwner;
	public StringVariable UpOwner;
	public StringVariable DownGraveyard;
	public StringVariable UpGraveyard;
	public StringVariable UpHand;
	public StringVariable DownHand;
	public StringVariable swapper;
	public PlayerState CurrentPlayer;
	public PlayerState StandByPlayer;
	public StringVariable ToPlaceField;
	public StringVariable ToPlaceFieldType;
	public StringVariable ToPlaceFieldOwner;
	public GameEvent RemovedCard;
	public GameEvent TurnSwap;
	public GameEvent ChangeTexts;
	public GameEvent Create;
	public GameEvent Placed;
	public GameEvent GameEnded;
	public GameEvent DrawGame;
	public GameEvent RoundsChanged;
	public FloatVariable CardsDiscarded;
	public StringVariable ReturnToDeck;
	private void Start() 
	{
		CardsDiscarded.Zero();
	}
	private void Update() {
		ChangeTexts.Raise(this, CurrentPlayer, StandByPlayer, null);
		CalculatePlayers();
	}
	public void HeroSkill(Component sender, object data1, object data2, object data3)
	{
		if (CurrentPlayer.HasUsedHero.Statement == false)
		{
		Card c = (Card)data1;
		c.ApplyEffect(CurrentPlayer, StandByPlayer, null, null);
		CurrentPlayer.HasUsedHero.True();
		SwapPlayers();
		}
	}
	public void HeroInit(Component sender, object data1, object data2, object data3)
	{
		Card c = (Card)data1;
		StringVariable s = null;
		Debug.Log("We are creating heros");
		if (c.CardOwner == CurrentPlayer.PlayerName) 
		{
			s = DownHero;
		}
		else 
		{
			s = UpHero;
		}
		Create.Raise(this, c, s, null);
	} 
	public void CommenceRound()
	{
		CurrentPlayer.CleanAllFields();
		StandByPlayer.CleanAllFields();
		CurrentPlayer.PlayerPassed.False();
		StandByPlayer.PlayerPassed.False();
		for (int i = 0; i < 2; i++)
		{
			CurrentPlayer.Draw();
			StandByPlayer.Draw();
		}
		ChangeTexts.Raise(this, CurrentPlayer, StandByPlayer, null);
	}
	public void GameOver()
	{
		if (CurrentPlayer.PlayerHP.Value == 0 && StandByPlayer.PlayerHP.Value != 0) 
		{
			GameEnded.Raise(this, StandByPlayer.PlayerName, null, null);
		}
		else if (StandByPlayer.PlayerHP.Value == 0 && CurrentPlayer.PlayerHP.Value != 0) 
		{
			GameEnded.Raise(this, CurrentPlayer.PlayerName, null, null);
		}
		else if (CurrentPlayer.PlayerHP.Value == 0 && StandByPlayer.PlayerHP.Value == 0) 
		{
			DrawGame.Raise(this, null, null, null);
		}
	}
	public void RoundChange()
	{
		RoundsChanged.Raise(this, null, null, null);
		if (CurrentPlayer.CollectedPower.Value > StandByPlayer.CollectedPower.Value)
		{
			StandByPlayer.PlayerHP.Value--;
			GameOver();
			CommenceRound();
		}
		else if (StandByPlayer.CollectedPower. Value > CurrentPlayer.CollectedPower.Value)
		{
			CurrentPlayer.PlayerHP.Value--;
			GameOver();
			CommenceRound();
		}
		else 
		{
			StandByPlayer.PlayerHP.Value--;
			CurrentPlayer.PlayerHP.Value--;
			GameOver();
			CommenceRound();
		}
	}
	public void PlayerPassed(Component sender, object data1, object data2, object data3)
	{
		CurrentPlayer.PlayerPassed.True();
		if (CurrentPlayer.PlayerPassed.Statement == true && StandByPlayer.PlayerPassed.Statement == true)
		{
			RoundChange();
		}
		else if (StandByPlayer.PlayerPassed.Statement == false)
		{
			SwapPlayers();
		}
	}
	public void AttemptingPlacement(Component sender, object data1, object data2, object data3)
	{
		Debug.Log("Trying to place a card");
		if (ToPlaceField != null && ToPlaceField != DownGraveyard)
		{
			ListOfCards PlacingIn = null;
			if (ToPlaceFieldOwner == DownOwner) PlacingIn = CurrentPlayer.TypeGetZone(ToPlaceFieldType);
			else PlacingIn = StandByPlayer.TypeGetZone(ToPlaceFieldType);
			if (PlacingIn != null)
			{ 
			if (PlacingIn.NotFull())
			{
			PlaceCard(this, data1, data2, data3);
			if (StandByPlayer.PlayerPassed.Statement == false) SwapPlayers();
			}
			}
		}
	}
	public void SwapPlayers()
	{
		CurrentPlayer.FakeOutHand();
		StandByPlayer.RestoreHand();
		CurrentPlayer.IsFirstTurn.False();
		CardsDiscarded.Zero();
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
		StringVariable owner = (StringVariable)data3;
		ToPlaceFieldOwner = owner;
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
	public void Draw(Component sender, object data1, object data2, object data3)
	{
		Card c = (Card)data1;
		StringVariable s = null;
		if (c.CardOwner == CurrentPlayer.PlayerName) s = DownHand;
		else s = UpHand;
		Create.Raise(this, c, s, null);
	}
	public void Deck1st(Component sender, object data1, object data2, object data3)
	{
		Card c = (Card)data1;
		if (ToPlaceField == DownDeck)
		{
		if (CurrentPlayer.IsFirstTurn.Statement == true)
		{
			if (CardsDiscarded.Value < 2)
			{
				Debug.Log("Trying to change a card");
				CurrentPlayer.Hand.Remove(c);
				CurrentPlayer.Draw();
				CurrentPlayer.Deck.Add(c);
				CurrentPlayer.Shuffle();
				CardsDiscarded.Value += 1;
				RemovedCard.Raise(this, c, ReturnToDeck, null);
			}
		}
		}
	}
	public void CreateWeather(Component sender, object data1, object data2, object data3)
	{
		if (CurrentPlayer.Weather.NotFull())
		{
		Card c = (Card)data1;
		if (c != null) Debug.Log(c.CardName.Word + " is not null");
		Create.Raise(this, c, DownHand, null);
		ToPlaceField = CurrentPlayer.Weather.ListName;
		ToPlaceFieldType = CurrentPlayer.Weather.ListType;
		PlaceCard(this, c, null, null);
		}
	}
	public void RemoveBoost(Component sender, object data1, object data2, object data3)
	{
		Card c = (Card)data1;
		CurrentPlayer.SearchDestroyBoost(c);
		StandByPlayer.SearchDestroyBoost(c);
	}
}

