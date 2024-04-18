using System.Collections;
using System.Collections.Generic;
using UnityEngine;



[CreateAssetMenu(fileName = "ClearCardRange", menuName = "kanjies/ClearCardRange", order = 0)]
public class ClearCardRange : ClearCard
{
    public override void Place(PlayerState Player, PlayerState Enemy, StringVariable Zone, StringVariable ZoneType)
    {
      Player.Hand.Remove(this);
		  Player.Weather.Add(this);
		  Player.DestroyWeather(this.CardFaccion.Word, Player.WeatherRange);
		  Enemy.DestroyWeather(this.CardFaccion.Word, Enemy.WeatherRange);
    }
}
