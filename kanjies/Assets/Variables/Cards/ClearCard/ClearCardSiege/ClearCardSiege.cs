using System.Collections;
using System.Collections.Generic;
using UnityEngine;



[CreateAssetMenu(fileName = "ClearCardSiege", menuName = "kanjies/ClearCardSiege", order = 0)]
public class ClearCardSiege : ClearCard
{
	public override void Place(PlayerState Player, PlayerState Enemy, StringVariable Zone, StringVariable ZoneType)
    {
      Player.Hand.Remove(this);
	  Player.Weather.Add(this);
	  Player.DestroyWeather(this.CardFaccion.Word, Player.WeatherSiege);
	  Enemy.DestroyWeather(this.CardFaccion.Word, Enemy.WeatherSiege);
    }
	
	
} 
