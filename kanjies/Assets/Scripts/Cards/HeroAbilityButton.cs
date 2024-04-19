using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroAbilityButton : MonoBehaviour 
{
	public HeroCard Hero;
	public GameEvent HeroUse;
	public GameEventListener ThisReacts;
	private void Start() {
	}
	private void Update() {
		if (this.gameObject.GetComponent<Field>().VisualField[0] != null)
		{
		Hero = (HeroCard)this.gameObject.GetComponent<Field>().VisualField[0].GetComponent<CardDisplay>().card;
		HeroUse = Hero.HeroEvent;
		ThisReacts.gameEvent = HeroUse;
		ThisReacts.gameEvent.Register(ThisReacts);
		}
	}
	public void HeroAbility(Component sender, object data1, object data2, object data3)
	{
		PlayerController p = (PlayerController)sender;
		if (Hero.CardOwner == p.CurrentPlayer.PlayerName)
		{
			Hero.ApplyEffect(p.CurrentPlayer, p.StandByPlayer, null, null);
		}
		else 
		{
			Hero.ApplyEffect(p.StandByPlayer, p.CurrentPlayer, null, null);
		}
	}

	
}
