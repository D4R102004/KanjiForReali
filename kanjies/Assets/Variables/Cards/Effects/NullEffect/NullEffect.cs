using System.Collections;
using System.Collections.Generic;
using UnityEngine;



[CreateAssetMenu(fileName = "NullEffect", menuName = "kanjies/NullEffect", order = 0)]
public class NullEffect : EffectApplier 
{
    public override void ApplyEffect(PlayerState Player, PlayerState Enemy, StringVariable Zone, StringVariable ZoneType)
    {
        return;
    }
    public override void EffectRevert(PlayerState Player, PlayerState Enemy, StringVariable Zone, StringVariable ZoneType)
    {
		return;
    }


} 
