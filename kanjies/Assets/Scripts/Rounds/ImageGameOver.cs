using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ImageGameOver : MonoBehaviour 
{
	public Image GameOverScreen;
	public Text GameOverText;
	private void Start() 
	{
		GameOverScreen.enabled = false;
		GameOverText.enabled = false;
	}
	public void GameOver(Component sender, object data1, object data2, object data3)
	{
		StringVariable s = (StringVariable)data1;
		GameOverScreen.enabled = true;
		GameOverText.enabled = true;
		GameOverText.text = "GAMEOVER!!! " + s.Word + " WINS!!!";
	}
	public void Draw(Component sender, object data1, object data2, object data3)
	{
		GameOverScreen.enabled = true;
		GameOverText.enabled = true;
		GameOverText.text = "DRAW!!!";
	}

}
