using System.Collections;
using System.Collections.Generic;
using UnityEngine;



[CreateAssetMenu(fileName = "DrawEffect", menuName = "kanjies/DrawEffect", order = 0)]
public class DrawEffect : EffectApplier {
	public FloatReference ToDraw;
    public override void ApplyEffect(PlayerState Player, PlayerState Enemy, StringVariable Zone, StringVariable ZoneType, Card ThisCard)
    {
		for (int i = 0; i < ToDraw.Value; i++)
		{
			Player.Draw();
		}
    }


} 
