using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
[Serializable]

public class BoolReference 
{
	public bool Determine;
	public bool MyBool;
	public BoolVariable Variable;
	public bool Statement
	{
		get {return Determine? MyBool : Variable.Statement;}
	}


}
