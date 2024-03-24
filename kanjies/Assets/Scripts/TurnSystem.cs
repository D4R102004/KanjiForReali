using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TurnSystem : MonoBehaviour 
{
	public bool IsYourTurn;
	public int YourTurn;
	public int IsOpponentTurn;
	public Text TurnText;
	public GameMechanics logic;
	public FieldProperties P1Melee;
	public FieldProperties P1Range;
	public FieldProperties P1Siege;
	public GameManager gm;
	public void Awake()
	{
		gm = gameObject.GetComponent<GameManager>();
	}

	// Use this for initialization
	void Start () 
	{
		IsYourTurn = true;
		YourTurn = 1;
		IsOpponentTurn = 0;
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (IsYourTurn)
		{
			TurnText.text = "Player's Turn";
		}
		else
		{
			TurnText.text = "Opponent's Turn";
		}	
	}
	public void PlayerEndTurn()
	{
		IsYourTurn = false;
		IsOpponentTurn += 1;
		gm.PlayerEnd(logic, P1Melee, P1Range, P1Siege);
		logic.BoostMelee = 0;
		logic.BoostRange = 0;
		logic.BoostSiege = 0;
	} 
	public void OpponentEndTurn()
	{
		IsYourTurn = true;
		YourTurn += 1;
	}
}
