using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitiatePlayerHero : MonoBehaviour 
{
	private GameObject HeroZone;
	private GameObject Hero1;
	private void Awake()
	{
	    HeroZone = GameObject.Find("PlayerKanZone");
		Hero1 = GameObject.Find("Hero1");
	}
	// Use this for initialization
	void Start () 
	{
		GameObject playerhero = Instantiate(Hero1, new Vector3 (0,0,0), Quaternion.identity);
		playerhero.transform.SetParent(HeroZone.transform);
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
