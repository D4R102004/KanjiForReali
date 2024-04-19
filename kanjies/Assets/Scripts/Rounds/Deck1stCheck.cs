using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deck1stCheck : MonoBehaviour {
	public GameEvent ActiveField;
	public StringVariable DeckName;
	public void OnCollisionEnter2D (Collision2D other)
	{
		ActiveField.Raise(this, DeckName, null, null);
	}
}
