using System.Collections;
using System.Collections.Generic;
using UnityEngine;



[CreateAssetMenu(fileName = "DestroyStrongest", menuName = "kanjies/DestroyStrongest", order = 0)]
public class DestroyStrongest : EffectApplier {
    public override void ApplyEffect(PlayerState Player, PlayerState Enemy, StringVariable Zone, StringVariable ZoneType, Card ThisCard)
    {
        Card Me = Player.GetStrongestCard();
		Card You = Enemy.GetStrongestCard();
		if (You != null && Me != null)
		{
		if (You.CardAttack.Value >= Me.CardAttack.Value)
		{
			You.RevertEffect(Enemy, Player, Zone, ZoneType);
			Enemy.Destroy(You, Enemy.GetCardLocation(You));
		}
		else 
		{
			Me.RevertEffect(Player, Enemy, Zone, ZoneType);
			Player.Destroy(Me, Player.GetCardLocation(Me));
		}
		}
		else if (You == null)
		{
			Me.RevertEffect(Player, Enemy, Zone, ZoneType);
			Player.Destroy(Me, Player.GetCardLocation(Me));

		}
		else if (Me == null)
		{
			You.RevertEffect(Enemy, Player, Zone, ZoneType);
			Enemy.Destroy(You, Enemy.GetCardLocation(You));
		}
		Player.Update();
		Enemy.Update();
    }


} 