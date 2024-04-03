using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Events;

public class DragDropKan : CardsAttributes 
{
	public GameMechanics mech;
	private Destruction pop;
	public CardsAttributes cardatt;
	public FieldAttributes fields;
	private int maxsize;
	public bool isover = false;
	private bool IsDragging = false;
	private GameObject StartParent;
	private Vector2 StartPosition;
	private GameObject Canvas;
	public GameObject Zone;

	private void Awake()
	{
		
	}
	public void InitializeZone()
	{
		Zone = gm.ZoneManager(cardatt);
		if (Zone == null)
		{
			Debug.LogError("Zone not found" + cardatt.field);
			return;
		}
		fields = Zone.GetComponent<FieldAttributes>();
		if (fields == null)
		{
			Debug.LogError("FieldAttributes not found on zone");
			return;
		}
		maxsize = fields.maxsize;
	}
    void Start() 
	{
		cardatt = gameObject.GetComponent<CardsAttributes>();
		if (cardatt == null) Debug.LogError("Card att not found");
		Canvas = GameObject.Find("Canvas");
		pop = gameObject.GetComponent<Destruction>();
		//gm = gameObject.GetComponent<GameManager>();
		gm = GameObject.Find("GameManager").GetComponent<GameManager>();
		InitializeZone();
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
		Zone = gm.ZoneManager(this.cardatt);
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
		Zone = gm.ZoneManager(this.cardatt);
		fields = Zone.GetComponent<FieldAttributes>();
		StartParent = transform.parent.gameObject;
		StartPosition = transform.position;
		IsDragging = true;
		Debug.Log(StartParent.gameObject.name);
	}
	public void EndDrag()
	{
		IsDragging = false;
		if (gm.TurnCorroborer(fields) && (StartParent == gm.PlayerHand || StartParent == gm.OppHand))
		{
		if (isover && cardatt.IsClear && fields.counter != 0)
		{
			gm.ConfirmWeather(Zone);
			int i = pop.DestroyWeather(Zone, cardatt);
			fields.counter -= i;
			gm.ReduceWeather(cardatt);
			gm.WeatherTransform();
			Destroy(this.gameObject);
		}
		if (isover && cardatt.field == "Weather" && fields.counter < maxsize && (cardatt.IsClear == false))
		{
			transform.SetParent(Zone.transform);
			fields.counter++;
			gm.WeatherClause(cardatt);
		}
		else if (isover && fields.counter < maxsize && (cardatt.IsClear == false) && cardatt.faccion != "Weather")
		{
			gm.PlaceCard();
		}
		else
		{
			transform.position = StartPosition;
			transform.SetParent(StartParent.transform);

		}
		}
		else 
		{
			transform.position = StartPosition;
			transform.SetParent(StartParent.transform);
		}
	}
}
