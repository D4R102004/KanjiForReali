using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;



[CreateAssetMenu(fileName = "AverageEffect", menuName = "kanjies/AverageEffect", order = 0)]
public class AverageEffect : EffectApplier 
{
    public override void ApplyEffect(PlayerState Player, PlayerState Enemy, StringVariable Zone, StringVariable ZoneType, Card ThisCard)
    {
		float average = Enemy.GetAverage();
		Enemy.SetEveryOneToValue(average);
		Enemy.Update();
    }


}
