using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Field : MonoBehaviour {
	public StringVariable FieldName;
	public StringVariable FieldType;
	public StringVariable FieldOwner;
	public List<GameObject> VisualField;
	public StringVariable MyMirror;
	public StringVariable MySwapper;
	public GameEvent ActiveField;
	public GameEvent Removing;
	public GameEvent Done;
	private void Update() {
		for (int i = VisualField.Count - 1; i >=0; i--)
		{
		if (FieldName.Word == "OppHand") VisualField[i].GetComponent<CardDisplay>().FlipFaceDown();
		else VisualField[i].GetComponent<CardDisplay>().Reveal();
		}
	}
	private void OnCollisionEnter2D(Collision2D other)
	{
		Debug.Log("Colliding with " + FieldName.Word);
		Card c = (Card)other.gameObject.GetComponent<CardDisplay>().card;
		if (c.HasBeenPlaced.Statement == false)
		{
		for (int i = c.CardZone.Count - 1; i >= 0; i--)
		{
			if (c.CardZone[i].Word == FieldName.Word) ActiveField.Raise(this, FieldName, FieldType, FieldOwner);
		}
		}
	}
	private void OnCollisionExit2D(Collision2D other) 
	{	
		ActiveField.Raise(this, null, null, null);
	}
	public void Remove(Component sender, object data1, object data2, object data3)
	{
		Card c = (Card)data1;
		StringVariable s = (StringVariable)data2;
		for (int i = VisualField.Count - 1; i >= 0; i--)
		{
			if (VisualField[i].GetComponent<CardDisplay>().card == c)
			{
				Removing.Raise(this, VisualField[i], s, null);
				VisualField.RemoveAt(i);
			}
		}
	}
	public void Add(Component sender, object data1, object data2, object data3)
	{
		GameObject g = (GameObject)data1;
		StringVariable s = (StringVariable)data2;
		if (FieldName.Word == s.Word)
		{
			VisualField.Add(g);
			Debug.Log(FieldName.Word + " has added " + g.GetComponent<CardDisplay>().card.CardName.Word);
			g.transform.SetParent(this.gameObject.transform);
		}
	}
	public void GiveAll(Component sender, object data1, object data2, object data3)
	{
		StringVariable s = (StringVariable)data2;
		if (sender is PlayerController || s.Word == FieldName.Word)
		{
		for (int i = VisualField.Count - 1; i >= 0; i--)
		{
			Removing.Raise(this, VisualField[i], MySwapper, null);
			VisualField.RemoveAt(i);
		}
		Done.Raise(this, null, MyMirror, null);
		}
	}
}
