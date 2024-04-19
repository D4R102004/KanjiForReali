using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "DrawWinner", menuName = "kanjies/DrawWinner", order = 0)]
public class DrawWinner : EffectApplier
{
    public override void ApplyEffect(PlayerState Player, PlayerState Enemy, StringVariable Zone, StringVariable ZoneType, Card ThisCard)
    {
        if (Player.CollectedPower.Value == Enemy.CollectedPower.Value)
		{
			Player.CollectedPower.Value++;
		}
    }


}
