using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;


[CreateAssetMenu(fileName = "ListOfCards", menuName = "kanjies/ListOfCards", order = 0)]
public class ListOfCards : ScriptableObject 
{
	public List<Card> ListCard;
	public string Description;
	public void Add(Card card)
	{
		ListCard.Add(card);
	}
	public void Remove(Card card)
	{
		ListCard.Remove(card);
	}
	public void Restart()
	{
		ListCard = new List<Card>();
	}
	
} 
