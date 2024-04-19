using System.Collections;
using System.Collections.Generic;
using UnityEngine;



[CreateAssetMenu(fileName = "CleanLowestRow", menuName = "kanjies/CleanLowestRow", order = 0)]
public class CleanLowestRow : EffectApplier 
{
    public override void ApplyEffect(PlayerState Player, PlayerState Enemy, StringVariable Zone, StringVariable ZoneType, Card ThisCard)
    {
        Debug.Log("Applying Dragon Effect");
        ListOfCards Me = Player.GetFileWithLowestCount();
        ListOfCards You = Enemy.GetFileWithLowestCount();
        if (Me != null && You != null)
        {
            if (Me.ListCard.Count > You.ListCard.Count)
            {
                Enemy.CleanRow(You);
            }
            else if (You.ListCard.Count > Me.ListCard.Count)
            {
                Player.CleanRow(Me);
            } 
            else Enemy.CleanRow(You);
        }
        else if (Me == null && You != null)
        {
            Enemy.CleanRow(You);
        }
        else if (You == null && Me != null)
        {
            Player.CleanRow(Me);
        }
    }


} 
