using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "BoostCard", menuName = "kanjies/BoostCard", order = 0)]
public class BoostCard : Card 
{
    public override void Place(PlayerState Player, PlayerState Enemy, StringVariable Zone, StringVariable ZoneType)
    {
        Player.Hand.Remove(this);
        ListOfCards ImGoing = Player.TypeGetZone(ZoneType);
        ImGoing.Add(this);
        this.HasBeenPlayed();
        Player.Update();
    }



} 
