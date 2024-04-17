using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurrentPlayerDisplayer : SingleTextDisplayer 
{
    public override void Display(Component sender, System.Object data1, System.Object data2, System.Object data3)
    {
		PlayerState current = (PlayerState)data1;
		this.ToDisplay = current.CollectedPower.Value.ToString();
    }



}
