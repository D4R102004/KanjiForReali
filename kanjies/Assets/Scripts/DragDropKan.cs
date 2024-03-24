using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragDropKan : MonoBehaviour 
{
	public GameMechanics mech;
	private GameManager gm;
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
		
		Canvas = GameObject.Find("Canvas");
		pop = gameObject.GetComponent<Destruction>();
		gm = gameObject.GetComponent<GameManager>();
		zonetype = field.zonetype;
		maxsize = field.maxsize;
		Zone = GameObject.Find(zonetype);
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
		if (isover && cardatt.IsClear && field.counter != 0)
		{
			gm.ConfirmWeather(Zone);
			int i = pop.DestroyWeather(Zone, cardatt);
			field.counter -= i;
			gm.ReduceWeather(cardatt);
			gm.WeatherTransform();
			Destroy(this.gameObject);
		}
		if (isover && cardatt.typetext == "Weather" && field.counter < maxsize)
		{
			transform.SetParent(Zone.transform);
			field.counter++;
			gm.WeatherClause(cardatt);
		}
		else if (isover && field.counter < maxsize && cardatt.faccion != "Clear" && cardatt.faccion != "Weather")
		{
			transform.SetParent(Zone.transform);
			field.counter++;
			if (cardatt.typetext != "Boost") gm.AttackGiver(cardatt);
			else gm.BoostGiver(cardatt);
		}
		else
		{
			transform.position = StartPosition;
			transform.SetParent(StartParent.transform);

		}
	}
}
