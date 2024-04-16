using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Creator : MonoBehaviour 
{
	public GameObject card;
	public GameEvent Removing;
	public void Create(Component sender, object data1, object data2, object data3)
	{
		Card c = (Card)data1;
		StringVariable s = (StringVariable)data2;
		GameObject g = Instantiate(card, new Vector3(0, 0, 0), Quaternion.identity);
		g.GetComponent<CardDisplay>().card = c;
		Removing.Raise(this, g, s, null);
	}

}
