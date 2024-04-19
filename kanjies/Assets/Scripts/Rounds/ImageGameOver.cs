using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ImageGameOver : MonoBehaviour 
{
	public PlayerController pc;
	public GameEvent Gamestarted;
	public Image GameOverScreen;
	public Text GameOverText;
	public Button InitButton;
	public Text ButtonText;
	private void Start() 
	{
		GameOverScreen.enabled = true;
		GameOverText.enabled = true;
		GameOverText.text = "PRESS START";
		InitButton.enabled = true;
		ButtonText.enabled = true;
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
	public void StartGame()
	{
		Debug.Log("Trying to start the game");
		Gamestarted.Raise(pc, null, null, null);
		InitButton.enabled = false;
		InitButton.gameObject.GetComponent<Image>().enabled = false;
		ButtonText.enabled = false;
		GameOverScreen.enabled = false;
		GameOverText.enabled = false;
	}

}
