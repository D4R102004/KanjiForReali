using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OppHealthDisplay : SingleTextDisplayer 
{
    public override void Display(Component sender, System.Object data1, System.Object data2, System.Object data3)
    {
		PlayerState StandBy = (PlayerState)data2;
		this.ToDisplay = StandBy.PlayerHP.Value.ToString();
    }



}
