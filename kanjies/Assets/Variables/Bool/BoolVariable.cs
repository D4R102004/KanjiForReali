using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "BoolVariable", menuName = "BoolVariable", order = 0)]
public class BoolVariable : ScriptableObject 
{
	public bool Statement;
	public string Description;
	public void False()
	{
		Statement = false;
	}
	
} 
