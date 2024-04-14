using System.Collections;
using System.Collections.Generic;
using UnityEngine;



[CreateAssetMenu(fileName = "AttackingCardRange", menuName = "kanjies/AttackingCardRange", order = 0)]
public class AttackingCardRange : AttackingCard 
{
    public override void Place(PlayerState Player, PlayerState Enemy, StringVariable Zone)
    {
		Player.ApplyBoost(this, Player.RangeBoost, Player.WeatherRange);
		Player.Range.Add(this);
    this.HasBeenPlaced.Statement = true;
    }
} 
