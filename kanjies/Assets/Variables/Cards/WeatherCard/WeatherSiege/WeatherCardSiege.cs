using System.Collections;
using System.Collections.Generic;
using UnityEngine;



[CreateAssetMenu(fileName = "WeatherCardSiege", menuName = "kanjies/WeatherCardSiege", order = 0)]
public class WeatherCardSiege : WeatherCard
{
    public override void Place(PlayerState Player, PlayerState Enemy, StringVariable Zone, StringVariable ZoneType)
    {
        Player.Hand.Remove(this);
		Player.InsertBoost(this, Player.WeatherSiege);
		Player.Weather.Add(this);
		Player.IterateField(this.CardAttack.Value * -1, Player.Siege);
		Enemy.Weather.Add(this);
		Enemy.InsertBoost(this, Enemy.WeatherSiege);
		Enemy.IterateField(this.CardAttack.Value * -1, Enemy.Siege);
    }


} 
