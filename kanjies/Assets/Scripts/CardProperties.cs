using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "New Card", menuName = "Card")]

public class CardProperties : ScriptableObject
{
	public string cardname;
	public string faccion;
	public string typetext;
	public Sprite type;
	public Sprite artwork;
	public int power;
	public string effect;
	public int CardID;
	public bool IsClear = false;



}
