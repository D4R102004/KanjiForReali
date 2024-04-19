using System.Collections;
using System.Collections.Generic;
using UnityEngine;



[CreateAssetMenu(fileName = "HeroDraw", menuName = "kanjies/HeroDraw", order = 0)]
public class HeroDraw : EffectApplier 
{
	public FloatReference CardsToDraw;
    public override void ApplyEffect(PlayerState Player, PlayerState Enemy, StringVariable Zone, StringVariable ZoneType, Card ThisCard)
    {
        for (int i = 0; i < CardsToDraw.Value; i++)
		{
			Player.Draw();
		}
    }
}

