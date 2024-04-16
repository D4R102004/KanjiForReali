using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.UI;

public class DrawCard : MonoBehaviour 
{
	public FloatReference WantingToDraw;
	public GameObject card;
	public GameObject PlayerHand;
	public ListOfCards LogicHand;
	List<GameObject> cards = new List<GameObject>();
	public List<Card> PossibleCards;

 
	// Use this for initialization
	/*void Start () 
	{
		cards.Add(card);
		Draw();
	}
	public void Draw()
	{
		for (int i = 0; i < PossibleCards.Count; i++)
		{
		Card c = PossibleCards[i];
		c.HasBeenPlaced.False();
		LogicHand.Add(c);
		GameObject playercard = Instantiate(cards[Random.Range(0, cards.Count)], new Vector3(0,0,0), Quaternion.identity);
		playercard.GetComponent<CardDisplay>().card = c;
		playercard.GetComponent<CardDisplay>().SetCard();
		PlayerHand.GetComponent<Field>().VisualField.Add(playercard);
		playercard.transform.SetParent(PlayerHand.transform);
		}
	}*/
	

	
}
