using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLogic : MonoBehaviour 
{
	public GameMechanics Logic;
	public int CollectedPower;
	public int MeleePower;
	public int RangePower;
	public int SiegePower;
	public int BoostMelee;
	public int BoostRange;
	public int BoostSiege;
	public int WeatherMelee;
	public int WeatherRange;
	public int WeatherSiege;
	private void Awake() {
	CollectedPower = Logic.CollectedPower;
	MeleePower = Logic.MeleePower;
	RangePower = Logic.RangePower;
	SiegePower = Logic.SiegePower;
	BoostMelee = Logic.BoostMelee;
	BoostRange = Logic.BoostRange;
	BoostSiege = Logic.BoostSiege;
	WeatherMelee = Logic.WeatherMelee;
	WeatherRange = Logic.WeatherRange;
	WeatherSiege = Logic.WeatherSiege;
	}


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
