using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour 
{

	private int PlayerMeleePower;
	private int PlayerRangePower;
	private int PlayerSiegePower;
	private void Awake()
	{
		
	}


	// Use this for initialization
	void Start () 
	{
		
	}
	
	// Update is called once per frame
	void Update () 
	{

		
	}
	public void Effect(CardProperties card)
	{
		if (card.CardID == 1)
		{
			PlayerMeleePower += 2;
			Debug.Log("Current Melee" + PlayerMeleePower);
		}
	}

}
