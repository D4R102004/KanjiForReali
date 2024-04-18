using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;



[CreateAssetMenu(fileName = "WeatherRangeCard", menuName = "kanjies/WeatherRangeCard", order = 0)]
public class WeatherRangeCard : WeatherCard 
{
    public override void Place(PlayerState Player, PlayerState Enemy, StringVariable Zone, StringVariable ZoneType)
    {
		Player.Hand.Remove(this);
		Player.InsertBoost(this, Player.WeatherRange);
		Player.Weather.Add(this);
		Player.IterateField(this.CardAttack.Value * -1, Player.Range);
		Enemy.Weather.Add(this);
		Enemy.InsertBoost(this, Enemy.WeatherRange);
		Enemy.IterateField(this.CardAttack.Value * -1, Enemy.Range);
    }
}
