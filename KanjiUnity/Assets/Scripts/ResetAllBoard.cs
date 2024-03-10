using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetAllBoard : MonoBehaviour 
{
	public FieldProperties field;
	public GameObject PlayerHand;

	// Use this for initialization
	void Start () 
	{
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	public void ReturnHand(GameObject parent)
	{
		foreach(Transform child in parent.transform)
		{
			child.gameObject.transform.SetParent(PlayerHand.transform);
		}
		field.counter = 0;
	}
}
