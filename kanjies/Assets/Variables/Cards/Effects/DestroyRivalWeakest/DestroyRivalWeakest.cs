using System.Collections;
using System.Collections.Generic;
using UnityEngine;



[CreateAssetMenu(fileName = "DestroyRivalWeakest", menuName = "kanjies/DestroyRivalWeakest", order = 0)]
public class DestroyRivalWeakest : EffectApplier
{
    public override void ApplyEffect(PlayerState Player, PlayerState Enemy, StringVariable Zone, StringVariable ZoneType, Card ThisCard)
    {
        Card c = Enemy.GetWeakestCard();
		if (c != null)
		{
			c.RevertEffect(Enemy, Player, Zone, ZoneType);
			Enemy.Destroy(c, Enemy.GetCardLocation(c));
		}
    }


} 
