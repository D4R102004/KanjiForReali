using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragDropKan : MonoBehaviour 
{
	private Destruction pop;
	public CardProperties cardatt;
	public FieldProperties field;
	private string zonetype;
	private int maxsize;
	public bool isover = false;
	private bool IsDragging = false;
	private GameObject StartParent;
	private Vector2 StartPosition;
	private GameObject Canvas;
	private GameObject Zone;

	private void Awake()
	{
		Zone = GameObject.Find(zonetype);
		Canvas = GameObject.Find("Canvas");
	}
    void Start() 
	{
		pop = gameObject.GetComponent<Destruction>();
		zonetype = field.zonetype;
		maxsize = field.maxsize;
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
		Zone = GameObject.Find(zonetype);
	}
	private void OnCollisionEnter2D(Collision2D other) 
	{	
	    if (Zone == other.gameObject) 
		{
			isover = true;
			Zone = other.gameObject;
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
		if (isover && cardatt.faccion == "Clear" && field.counter != 0)
		{
			pop.DestroyWeather(Zone);
			field.counter = 0;
			Destroy(this.gameObject);
		}
		else if (isover && field.counter < maxsize && cardatt.faccion != "Clear")
		{
			transform.SetParent(Zone.transform);
			field.counter++;
			
		}
		else
		{
			transform.position = StartPosition;
			transform.SetParent(StartParent.transform);

		}
	}
}
