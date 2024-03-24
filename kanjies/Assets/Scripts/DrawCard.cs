using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.UI;

public class DrawCard : MonoBehaviour 
{
	public GameObject Card2;
	public GameObject DenkiCard;
	public GameObject HaganeCard;
	public GameObject Weather1;
	public GameObject Clear1;
	public GameObject Boost1;
	public GameObject PlayerHand;
	public GameObject OppHand;
	List<GameObject> cards = new List<GameObject>();
	List<GameObject> oppcards = new List<GameObject>();
 
	// Use this for initialization
	void Start () 
	{
		cards.Add(HaganeCard);
		cards.Add(Card2);
		cards.Add(Weather1);
		cards.Add(Clear1);
		cards.Add(Boost1);
		cards.Add(DenkiCard);
		
		for (int i = 0; i < 10; i++)
		{
			Draw();
		}
	}
	public void Draw()
	{
		GameObject playercard = Instantiate(cards[Random.Range(0, cards.Count)], new Vector3(0,0,0), Quaternion.identity);
		playercard.transform.SetParent(PlayerHand.transform);
		
	}

	
}
