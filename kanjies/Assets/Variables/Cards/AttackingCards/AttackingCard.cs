using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "AttackingCard", menuName = "kanjies/AttackCard", order = 0)]
public class AttackingCard : Card 
{
    public override void Place(PlayerState Player, PlayerState Enemy, StringVariable Zone, StringVariable ZoneType)
    {
        ListOfCards ImGoing = Player.TypeGetZone(ZoneType);
        FloatVariable Buff = ImGoing.GetBuff();
        FloatVariable Debuff = ImGoing.GetDebuff();
        Player.ApplyBoost(this, Buff, Debuff);
        ImGoing.Add(this);
        this.HasBeenPlayed();
    }	
}
