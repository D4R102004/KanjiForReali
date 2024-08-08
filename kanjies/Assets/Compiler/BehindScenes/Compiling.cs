using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Compiling : MonoBehaviour {
	public InputField userInput;
	public DAR dar;

	// Use this for initialization
	void Start () {
		
	}

	// Update is called once per frame
	void Update () {
		
	}
	public void Submit(string text)
	{
		dar.Compile(text);
		Debug.Log("Wrote: " + text);
	}
    
	}

