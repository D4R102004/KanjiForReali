using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "LegendCard", menuName = "kanjies/LegendCard", order = 0)]
public class LegendCard : Card
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
