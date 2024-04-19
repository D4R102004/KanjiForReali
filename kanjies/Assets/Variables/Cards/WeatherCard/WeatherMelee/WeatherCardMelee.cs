using System.Collections;
using System.Collections.Generic;
using UnityEngine;



[CreateAssetMenu(fileName = "WeatherCardMelee", menuName = "kanjies/WeatherCardMelee", order = 0)]
public class WeatherCardMelee : WeatherCard
{
    public override void Place(PlayerState Player, PlayerState Enemy, StringVariable Zone, StringVariable ZoneType)
    {
        Player.Hand.Remove(this);
		Player.InsertBoost(this, Player.WeatherMelee);
		Player.Weather.Add(this);
		Player.IterateField(this.CardAttack.Value * -1, Player.Melee);
		Enemy.Weather.Add(this);
		Enemy.InsertBoost(this, Enemy.WeatherMelee);
		Enemy.IterateField(this.CardAttack.Value * -1, Enemy.Melee);
    }



} 