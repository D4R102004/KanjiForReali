using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoostMeleeEffect : EffectApplier 
{
	public FloatVariable Boosting;
    public override void ApplyEffect(PlayerState Player, PlayerState Enemy, StringVariable Zone, StringVariable ZoneType)
    {

    }
    public override void EffectRevert(PlayerState Player, PlayerState Enemy, StringVariable Zone, StringVariable ZoneType)
    {
        
    }


}
