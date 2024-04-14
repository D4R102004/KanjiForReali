using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.UI;

public class DrawCard : MonoBehaviour 
{
	public GameObject card;
	public GameObject PlayerHand;
	public ListOfCards LogicHand;
	List<GameObject> cards = new List<GameObject>();
	public List<Card> PossibleCards;

 
	// Use this for initialization
	void Start () 
	{
		cards.Add(card);
		for (int i = 0; i < 2; i++)
		{
			Draw();
		}
	}
	public void Draw()
	{
		Card c = PossibleCards[Random.Range(0, PossibleCards.Count)];
		LogicHand.Add(c);
		GameObject playercard = Instantiate(cards[Random.Range(0, cards.Count)], new Vector3(0,0,0), Quaternion.identity);
		playercard.GetComponent<CardDisplay>().card = c;
		playercard.GetComponent<CardDisplay>().SetCard();
		PlayerHand.GetComponent<Field>().VisualField.Add(playercard);
		playercard.transform.SetParent(PlayerHand.transform);
	}
	

	
}
