using System.Collections;
using System.Collections.Generic;
using UnityEngine;



[CreateAssetMenu(fileName = "PlaceWeatherEffect", menuName = "kanjies/PlaceWeatherEffect", order = 0)]
public class PlaceWeatherEffect : EffectApplier
{
	public Card ThisWeather;
	public GameEvent CreateWeather;
    public override void ApplyEffect(PlayerState Player, PlayerState Enemy, StringVariable Zone, StringVariable ZoneType, Card ThisCard)
    {
		CreateWeather.Raise(null, ThisWeather, null, null);
    }


} 
