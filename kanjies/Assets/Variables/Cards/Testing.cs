using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Testing : MonoBehaviour 
{
	public ListOfCards list;
	public Card thing;
	private void Start() {
		list.Add(thing);
	}
	private void Update() {
		foreach (Card card in list.ListCard)
		if (card is AttackingCard) 
		{
			AttackingCard attackingcard = (AttackingCard)card;
			attackingcard.CardAttack.Value += 1;
			Debug.Log(attackingcard.CardAttack.Value.ToString());
		}
	}

}
