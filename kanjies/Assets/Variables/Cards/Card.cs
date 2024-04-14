using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;


[CreateAssetMenu(fileName = "Card", menuName = "kanjies/Card", order = 0)]
public class Card : ScriptableObject 
{
	public BoolVariable HasBeenPlaced;
	public StringReference CardName;
	public StringReference CardFaccion;
	public StringReference CardEffect;
	public StringReference CardType;
	public FloatVariable CardAttack;
	public ImageReference CardArtwork;
	public ImageReference TypeArtwork;
	public List<StringVariable> CardZone;
	public virtual void Place(PlayerState Player, PlayerState Enemy, StringVariable Zone)
	{
		
	}
} 