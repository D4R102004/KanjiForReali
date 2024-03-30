using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "New Field", menuName = "Field")]

public class FieldProperties : ScriptableObject 
{
	public string zonetype;
	public int maxsize;
	public bool IsOverZone;
	public int counter = 0;
	public bool FieldOwner;
}
