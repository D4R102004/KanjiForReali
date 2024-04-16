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
	public virtual void Place(PlayerState Player, PlayerState Enemy, StringVariable Zone)
	{
		
	}
	public void Normalize()
	{
		CardAttack.Value = OriginalAttack.Value;
	}
	public void SetOwner(StringVariable player)
	{
		CardOwner = player;
	}
} 