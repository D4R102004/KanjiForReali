using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonRound : MonoBehaviour 
{
	public GameEvent PlayerPassed;
	public void Passed()
	{
		PlayerPassed.Raise(this, null, null, null);
	}


}
