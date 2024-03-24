using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "Logic", menuName = "Mechanic")]
public class GameMechanics : ScriptableObject 
{
	public int CollectedPower = 0;
	public int MeleePower = 0;
	public int RangePower = 0;
	public int SiegePower = 0;
	public int BoostMelee = 0;
	public int BoostRange = 0;
	public int BoostSiege = 0;
	public int WeatherMelee = 0;
	public int WeatherRange = 0;
	public int WeatherSiege = 0;

}
