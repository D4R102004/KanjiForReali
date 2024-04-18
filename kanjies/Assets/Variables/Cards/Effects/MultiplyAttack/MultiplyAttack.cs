using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using UnityEngine;



[CreateAssetMenu(fileName = "MultiplyAttack", menuName = "kanjies/MultiplyAttack", order = 0)]
public class MultiplyAttack : EffectApplier
{
	public FloatVariable OriginalAttack;
    public override void ApplyEffect(PlayerState Player, PlayerState Enemy, StringVariable Zone, StringVariable ZoneType, Card ThisCard)
    {
		string MyName = ThisCard.CardName.Word;
		List<Card> MeSameName = Player.GetAllWithSameName(MyName);
		List<Card> YouSameName = Enemy.GetAllWithSameName(MyName);
		int n = MeSameName.Count + YouSameName.Count;
		for (int i = MeSameName.Count - 1; i >= 0; i--)
		{
			MeSameName[i].OriginalAttack.Value = OriginalAttack.Value * n;
		}
		for (int i = YouSameName.Count - 1; i >= 0; i--)
		{
			YouSameName[i].OriginalAttack.Value = OriginalAttack.Value * n;
		}
		Player.Update();
		Enemy.Update();
    }
    public override void EffectRevert(PlayerState Player, PlayerState Enemy, StringVariable Zone, StringVariable ZoneType, Card ThisCard)
    {
		string MyName = ThisCard.CardName.Word;
		List<Card> MeSameName = Player.GetAllWithSameName(MyName);
		List<Card> YouSameName = Enemy.GetAllWithSameName(MyName);
		int n = MeSameName.Count + YouSameName.Count - 1;
		for (int i = MeSameName.Count - 1; i >= 0; i--)
		{
			MeSameName[i].OriginalAttack.Value = OriginalAttack.Value * n;
		}
		for (int i = YouSameName.Count - 1; i >= 0; i--)
		{
			YouSameName[i].OriginalAttack.Value = OriginalAttack.Value * n;
		}
		Player.Update();
		Enemy.Update();
    }


}
