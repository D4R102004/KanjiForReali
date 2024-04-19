using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardZoom : MonoBehaviour {
	public GameObject Canvas;
	private GameObject ZoomCard;
	public GameEvent SendZoom;
	private void Awake() {
		Canvas = GameObject.Find("Canvas");
	}
	public void OnHoverEnter()
	{
		ZoomCard = Instantiate(gameObject, new Vector2(Input.mousePosition.x, Input.mousePosition.y), Quaternion.identity);
        SendZoom.Raise(this, ZoomCard, null, null);
	}
	public void OnHoverexit()
	{
		Destroy(ZoomCard);
	}
}
