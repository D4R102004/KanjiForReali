using System.Collections;
using System.Collections.Generic;
using UnityEngine;



[CreateAssetMenu(fileName = "DecoyCard", menuName = "kanjies/DecoyCard", order = 0)]
public class DecoyCard : Card 
{
    public override void Place(PlayerState Player, PlayerState Enemy, StringVariable Zone, StringVariable ZoneType)
    {
		if (Zone.Word == "OppMelee") Enemy.Decoy(this, Enemy.Melee);
		else if (Zone.Word == "OppRange") Enemy.Decoy(this, Enemy.Range);
		else Enemy.Decoy(this, Enemy.Siege);
    }


}

