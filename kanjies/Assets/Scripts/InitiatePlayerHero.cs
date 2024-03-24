using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitiatePlayerHero : MonoBehaviour 
{
	private ResetAllBoard reset;
	public GameMechanics Mechanics;
	private GameObject HeroZone;
	public GameObject Hero1;
	private void Awake()
	{
		reset = gameObject.GetComponent<ResetAllBoard>();
		reset.ResetYourPower(Mechanics);
		reset.ResetTheCounters();
	    HeroZone = GameObject.Find("PlayerKanZone");
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
