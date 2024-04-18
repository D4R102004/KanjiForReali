using System.Collections;
using System.Collections.Generic;
using UnityEngine;



[CreateAssetMenu(fileName = "DecoyEffect", menuName = "kanjies/DecoyEffect", order = 0)]
public class DecoyEffect : EffectApplier 
{
    public override void ApplyEffect(PlayerState Player, PlayerState Enemy, StringVariable Zone, StringVariable ZoneType, Card ThisCard)
    {
		ListOfCards ImAffecting = Enemy.TypeGetZone(ZoneType);
		Card c = Enemy.FindStrongest(ImAffecting);
		c.RevertEffect(Enemy, Player, Zone, ZoneType);
		Enemy.ReturnToTheHand(c, ImAffecting);
		if (c != null) c.HasBeenPlayed();
	}
	
} 