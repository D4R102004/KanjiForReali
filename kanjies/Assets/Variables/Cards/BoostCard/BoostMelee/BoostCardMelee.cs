using System.Collections;
using System.Collections.Generic;
using UnityEngine;



[CreateAssetMenu(fileName = "BoostCardMelee", menuName = "kanjies/BoostCardMelee", order = 0)]
public class BoostCardMelee : BoostCard 
{
    public override void Place(PlayerState Player, PlayerState Enemy, StringVariable Zone, StringVariable ZoneType)
    {
        Player.InsertBoost(this, Player.MeleeBoost);
		Player.Melee.Add(this);
		Player.IterateField(this.CardAttack.Value, Player.Melee);
		this.HasBeenPlaced.Statement = true;
    }


} 
