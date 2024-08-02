using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class sc : MonoBehaviour {
	public Button compButton;
	public Text buttonText;
	public void GoToCompiler()
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
	}
	public void Disable(Component sender, object data1, object data2, object data3 )
	{
		Debug.Log("Disabling compiled");
		compButton.gameObject.GetComponent<Image>().enabled = false;
		buttonText.enabled = false;
		compButton.enabled = false;

	}

}
