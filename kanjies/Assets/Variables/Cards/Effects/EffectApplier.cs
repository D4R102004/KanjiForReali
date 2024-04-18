using System.Collections;
using System.Collections.Generic;
using UnityEngine;



[CreateAssetMenu(fileName = "EffectApplier", menuName = "kanjies/EffectApplier", order = 0)]
public class EffectApplier : ScriptableObject 
{
	public StringVariable EffectOwner;
	public virtual void ApplyEffect(PlayerState Player, PlayerState Enemy, StringVariable Zone, StringVariable ZoneType, Card ThisCard)
	{

	}
	public virtual void EffectRevert(PlayerState Player, PlayerState Enemy, StringVariable Zone, StringVariable ZoneType, Card ThisCard)
	{


	}	
} 

