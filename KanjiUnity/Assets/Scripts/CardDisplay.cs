using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardDisplay : MonoBehaviour 
{
	public CardProperties card;
	public Text nametext;
	public Text faccion;
	public Text typetext;
	public Image imagetype;
	public Image artworkimage;
	public Text cardpower;
	public Text effect;


	// Use this for initialization
	void Start () 
	{
		nametext.text = card.cardname;
		faccion.text = card.faccion;
		typetext.text = card.typetext;
		imagetype.sprite = card.type;
		artworkimage.sprite = card.artwork;
		cardpower.text = card.power.ToString();
		effect.text = card.effect;


		
	}
	
	
}
