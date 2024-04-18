using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
[CreateAssetMenu(fileName = "AttackingCard", menuName = "kanjies/AttackCard", order = 0)]
public class AttackingCard : Card 
{
    public override void Place(PlayerState Player, PlayerState Enemy, StringVariable Zone, StringVariable ZoneType)
    {
        Player.Hand.Remove(this);
        ListOfCards ImGoing = Player.TypeGetZone(ZoneType);
        ImGoing.Add(this);
        FloatVariable Buff = ImGoing.GetBuff();
        FloatVariable Debuff = ImGoing.GetDebuff();
        Player.ApplyBoost(this, Buff, Debuff);
        this.HasBeenPlayed();
        Player.Update();
    }	
}
