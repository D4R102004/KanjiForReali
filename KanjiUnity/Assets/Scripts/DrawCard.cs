using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.UI;

public class DrawCard : MonoBehaviour 
{
	public GameObject Card1;
	public GameObject PlayerHand;
	List<GameObject> cards = new List<GameObject>();

	// Use this for initialization
	void Start () 
	{
		cards.Add(Card1);
	}
	public void Draw()
	{
		GameObject playercard = Instantiate(cards[Random.Range(0, cards.Count)], new Vector3(0,0,0), Quaternion.identity);
		playercard.transform.SetParent(PlayerHand.transform);
	}

	
}
