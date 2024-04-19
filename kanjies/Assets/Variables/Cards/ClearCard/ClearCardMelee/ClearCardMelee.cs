using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearCardMelee : ClearCard {

	public override void Place(PlayerState Player, PlayerState Enemy, StringVariable Zone, StringVariable ZoneType)
    {
      Player.Hand.Remove(this);
	  Player.Weather.Add(this);
	  Player.DestroyWeather(this.CardFaccion.Word, Player.WeatherMelee);
	  Enemy.DestroyWeather(this.CardFaccion.Word, Enemy.WeatherMelee);
    }
}
