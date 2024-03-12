using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;

public class Effects : MonoBehaviour 
{
	private CardProperties meleeprop1;
	private CardProperties meleeprop2;
	private CardProperties meleeprop3;
	private CardProperties meleeprop4;
	private CardProperties meleeprop5;
	public FieldProperties meleefield;
	public GameObject meleezone;
	public List<CardProperties> meleelist;
	// Use this for initialization
	void Start () 
	{

		

	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}

	public void Boost(CardProperties booster, FieldProperties fieldnum, GameObject Zone, List<CardProperties> cardprop)
	{
		foreach (Transform child in Zone.transform)
		{
			for (int i = 0; i < fieldnum.counter; i++)
			{
				cardprop[i].power += booster.power;
			}
			
		}
	}
}
