using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destruction : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
    public void DestroyWeather(GameObject parent)
	{
	foreach(Transform child in parent.transform)
		{
			GameObject.Destroy(child.gameObject);
		}
	}
}
