using System.Collections;
using System.Collections.Generic;
using UnityEngine;



[CreateAssetMenu(fileName = "ApplyBoost", menuName = "kanjies/ApplyBoost", order = 0)]
public class ApplyBoost : EffectApplier 
{
    public FloatReference Boost;
    public override void ApplyEffect(PlayerState Player, PlayerState Enemy, StringVariable Zone, StringVariable ZoneType, Card ThisCard)
    {
        ListOfCards ImGoing = Player.TypeGetZone(ZoneType);
        FloatVariable Buff = ImGoing.GetBuff();
        Buff.Value += Boost.Value;
        Player.Update();
    }
    public override void EffectRevert(PlayerState Player, PlayerState Enemy, StringVariable Zone, StringVariable ZoneType, Card ThisCard)
    {
        ListOfCards IWas = Player.GetCardLocation(ThisCard);
        FloatVariable Buff = IWas.GetBuff();
        Buff.Value -= Boost.Value;
        Player.Update();
    }


} 
