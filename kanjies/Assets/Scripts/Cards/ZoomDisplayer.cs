using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ZoomDisplayer : MonoBehaviour 
{
    public Text BigName;
    public Text BigPower;
    public Text BigTypeText;
    public Text BigFaccion;
    public Text BigEffect;
    public Image BigArtwork;
    public Image BigType;
    public Image FaceDown;
    private void Start() 
    {
        BigName.enabled = false;
        BigPower.enabled = false;
        BigTypeText.enabled = false;
        BigFaccion.enabled = false;
        BigEffect.enabled = false;
        BigArtwork.enabled = false;
        BigType.enabled = false;
    }

	public void GetZoom(Component sender, object data1, object data2, object data3)
	{
        FaceDown.enabled = false;
        BigName.enabled = true;
        BigPower.enabled = true;
        BigTypeText.enabled = true;
        BigFaccion.enabled = true;
        BigEffect.enabled = true;
        BigArtwork.enabled = true;
        BigType.enabled = true;
		GameObject card = (GameObject)data1;
        Card c = card.GetComponent<CardDisplay>().card;
        BigName.text = c.CardName.Word;
        BigPower.text = c.CardAttack.Value.ToString();
        BigTypeText.text = c.CardType.Word;
        BigFaccion.text = c.CardFaccion.Word;
        BigEffect.text = c.CardEffect.Word;
        BigArtwork.sprite = c.CardArtwork.Image;
        BigType.sprite = c.TypeArtwork.Image;
        if (card.GetComponent<CardDisplay>().CardBack.enabled == true)
        {
            FaceDown.enabled = true;
            FaceDown.sprite = c.CardBack.Image;
        }
    }

}

