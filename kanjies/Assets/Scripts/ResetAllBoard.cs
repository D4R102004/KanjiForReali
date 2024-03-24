using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;

public class ResetAllBoard : MonoBehaviour 
{
	public GameMechanics logic;
	public FieldProperties field;
	public GameObject PlayerHand;
	public FieldProperties m;
	public FieldProperties r;
	public FieldProperties s;
	public FieldProperties b1;
	public FieldProperties w;
	public WeatherModifiers wetmod;

	// Use this for initialization
	void Start () 
	{
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	public void ResetYourPower(GameMechanics logic)
	{
		logic.CollectedPower = 0;
		logic.MeleePower = 0;
		logic.SiegePower = 0;
		logic.RangePower = 0;
		logic.BoostMelee = 0;
		logic.BoostRange = 0;
		logic.BoostSiege = 0;
		logic.WeatherMelee = 0;
		logic.WeatherRange = 0;
		logic.WeatherSiege = 0;
	}
	public void ResetTheCounters()
	{
		m.counter = 0;
		r.counter = 0;
		s.counter = 0;
		b1.counter = 0;
		w.counter = 0;
		wetmod.Melee = 1;
		wetmod.Range = 1;
		wetmod.Siege = 1;
	}
}
