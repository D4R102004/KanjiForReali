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
	
    public int DestroyWeather(GameObject parent, CardsAttributes cardatt)
	{
		int i = 0;
	foreach(Transform child in parent.transform)
		{
			string type = child.GetComponent<DragDropKan>().cardatt.faccion;
			if (cardatt.faccion == type) GameObject.Destroy(child.gameObject);
			i++;
		}
		return i;
	}
}
