using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;


[CreateAssetMenu(fileName = "Card", menuName = "kanjies/Card", order = 0)]
public class Card : ScriptableObject 
{
	public StringVariable CardOwner;
	public BoolVariable HasBeenPlaced;
	public StringReference CardName;
	public StringReference CardFaccion;
	public StringReference CardEffect;
	public StringReference CardType;
	public FloatVariable CardAttack;
	public ImageReference CardArtwork;
	public ImageReference TypeArtwork;
	public ImageReference CardBack;
	public List<StringVariable> CardZone;
	public FloatReference OriginalAttack;
	public EffectApplier Effect;
	public virtual void Place(PlayerState Player, PlayerState Enemy, StringVariable Zone, StringVariable ZoneType)
	{
		
	}
	public void Normalize()
	{
		CardAttack.Value = OriginalAttack.Value;
	}
	public void SetOwner(StringVariable player)
	{
		CardOwner = player;
		Effect.EffectOwner = player;
	}
	public void HasBeenPlayed()
	{
		this.HasBeenPlaced.Statement = true;
	}
	public void ApplyEffect(PlayerState Player, PlayerState Enemy, StringVariable Zone, StringVariable ZoneType)
	{
		Effect.ApplyEffect(Player, Enemy, Zone, ZoneType);
	}
	public void RevertEffect(PlayerState player, PlayerState enemy, StringVariable Zone, StringVariable ZoneType)
	{
		Effect.EffectRevert(player, enemy, Zone, ZoneType);
	}
} 