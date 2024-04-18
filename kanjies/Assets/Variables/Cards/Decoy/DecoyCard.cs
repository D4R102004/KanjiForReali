using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;



[CreateAssetMenu(fileName = "DecoyCard", menuName = "kanjies/DecoyCard", order = 0)]
public class DecoyCard : Card 
{
    public override void Place(PlayerState Player, PlayerState Enemy, StringVariable Zone, StringVariable ZoneType)
    {
      Player.Hand.Remove(this);
      ListOfCards ImGoing = Enemy.TypeGetZone(ZoneType);
      ImGoing.Add(this);
      this.HasBeenPlayed();
      Enemy.Update();
    }


}

