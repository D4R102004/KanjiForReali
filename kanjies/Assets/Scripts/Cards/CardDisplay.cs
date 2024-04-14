using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardDisplay : MonoBehaviour {
	public GameEvent Placed;
	public Card card;
	public Text CardName;
	public Text CardType;
	public Text CardFaccion;
	public Text CardEffect;
	public Text CardAttack;
	public Image CardArtwork;
	public Image CardTypeArtwork;
	public List<StringVariable> CardZone;
	private bool IsDragging = false;
	private GameObject StartParent;
	private Vector2 StartPosition;
	private GameObject Canvas;
	private void Awake()
	{
		Canvas = GameObject.Find("Canvas");
	}
	public void SetCard()
	{
		CardName.text = card.CardName.Word;
		CardType.text = card.CardType.Word;
		CardFaccion.text = card.CardFaccion.Word;
		CardEffect.text = card.CardEffect.Word;
		CardAttack.text = card.CardAttack.Value.ToString();
		CardArtwork.sprite = card.CardArtwork.Image;
		CardTypeArtwork.sprite = card.TypeArtwork.Image;
	}
	void Update () 
	{
		if (IsDragging)
		{
			transform.position = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
			transform.SetParent(Canvas.transform, true);
		}
	}
		public void StartDrag()
	{
		if (!card.HasBeenPlaced.Statement)
		{
		StartParent = transform.parent.gameObject;
		if (StartParent == null) Debug.Log("No startParent");
		StartPosition = transform.position;
		IsDragging = true;
		}
	}
	public void EndDrag()
	{
		if (!card.HasBeenPlaced.Statement)
		{
		IsDragging = false;
		Placed.Raise(this, card, null, null);
		transform.position = StartPosition;
		transform.SetParent(StartParent.transform);
		}
	}
}
