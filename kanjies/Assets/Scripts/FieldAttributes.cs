using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldAttributes : MonoBehaviour 
{
	public FieldProperties field;
	public string zonetype;
	public int maxsize;
	public int counter;
	public CardsAttributes att;
	public bool Player;
	private void Awake() 
	{
		att = gameObject.GetComponent<CardsAttributes>();
		zonetype = field.zonetype;
		maxsize = field.maxsize;
		counter = 0;
		Player = field.FieldOwner;
	}
	

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
