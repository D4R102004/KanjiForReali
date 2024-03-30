using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardsAttributes : MonoBehaviour 
{
	public CardProperties prop;
	public GameManager gm;
	public string Name;
	public string faccion;
	public string field;
	public int power;
	public int ID;
	public bool IsClear;
	public bool Boost;
	private void Awake() 
	{
		prop = gameObject.GetComponent<CardDisplay>().card;
		Name = prop.cardname;
		field = prop.typetext;
		power = prop.power;
		ID = prop.CardID;
		gm = gameObject.GetComponent<GameManager>();
		faccion = prop.faccion;
		IsClear = prop.IsClear;
		if (field == "BoostMelee" || field == "BoostRange" || field == "BoostSiege") Boost = true;
	}

	// Use this for initialization
	void Start () 
	{
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
