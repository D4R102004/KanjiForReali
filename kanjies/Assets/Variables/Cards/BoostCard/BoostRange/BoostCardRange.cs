using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "BoostCardRange", menuName = "kanjies/BoostCardRange", order = 0)]
public class BoostCardRange : BoostCard 
{
    public override void Place(PlayerState Player, PlayerState Enemy, StringVariable Zone, StringVariable ZoneType)
    {
        Player.InsertBoost(this, Player.RangeBoost);
		Player.BoostRange.Add(this);
		Player.IterateField(this.CardAttack.Value, Player.Range);
		this.HasBeenPlaced.Statement = true;
    }
} 
