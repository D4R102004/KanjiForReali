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
		IsOpponentTurn = 1;
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
		gm.PlayerEnd();
	} 
	public void OpponentEndTurn()
	{
		IsYourTurn = true;
		YourTurn += 1;
	}
}
