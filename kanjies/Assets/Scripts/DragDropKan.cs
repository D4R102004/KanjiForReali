using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragDropKan : MonoBehaviour 
{
	public bool isover = false;
	private bool IsDragging = false;
	private GameObject StartParent;
	private Vector2 StartPosition;
	private GameObject Canvas;
	public GameObject Zone;

	private void Awake()
	{
		Canvas = GameObject.Find("Canvas");
	}
	
    void Start() 
	{
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (IsDragging)
		{
			transform.position = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
			transform.SetParent(Canvas.transform, true);
		}
	}
	private void OnCollisionExit2D(Collision2D other)
	{
		isover = false;
	}
	private void OnCollisionEnter2D(Collision2D other) 
	{	
	    if (Zone == other.gameObject) 
		{
			isover = true;
		}
		
	}
	public void StartDrag()
	{
	
		StartParent = transform.parent.gameObject;
		StartPosition = transform.position;
		IsDragging = true;
	}
	public void EndDrag()
	{
		IsDragging = false;
		if (isover)
		{
			transform.SetParent(Zone.transform);
		}
		else 
		{
			transform.position = StartPosition;
			transform.SetParent(StartParent.transform);
		}
	}
}
