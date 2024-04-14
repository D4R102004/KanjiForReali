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
	public void Awake()
	{
		IsYourTurn = true;
		YourTurn = 1;
		IsOpponentTurn = 1;
	}

	// Use this for initialization
	void Start () 
	{
		
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
	} 
	public void OpponentEndTurn()
	{
		IsYourTurn = true;
		YourTurn += 1;
	}
}
