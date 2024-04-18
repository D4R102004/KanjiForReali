using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Graveyard1stCheck : MonoBehaviour {
	public GameEvent ActiveField;
	public StringVariable GraveyardName;
	public void OnCollisionEnter2D (Collision2D other)
	{
		Card c = (Card)other.gameObject.GetComponent<CardDisplay>().card;
		ActiveField.Raise(this, GraveyardName, null, null);

	}
}
