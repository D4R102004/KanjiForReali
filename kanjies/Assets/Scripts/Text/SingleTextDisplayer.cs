using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SingleTextDisplayer : MonoBehaviour 
{
	public Text MyText;
	public string ToDisplay = "";
	public virtual void Display(Component sender, object data1, object data2, object data3)
	{
		
	}
	private void Update() {
		MyText.text = ToDisplay;
	}

}
