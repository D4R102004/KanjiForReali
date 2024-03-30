using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragDropKan : MonoBehaviour 
{
	public GameMechanics mech;
	private GameManager gm;
	private Destruction pop;
	public CardsAttributes cardatt;
	public FieldAttributes field;
	private int maxsize;
	public bool isover = false;
	private bool IsDragging = false;
	private GameObject StartParent;
	private Vector2 StartPosition;
	private GameObject Canvas;
	public GameObject Zone;

	private void Awake()
	{
		cardatt = gameObject.GetComponent<CardsAttributes>();
		Canvas = GameObject.Find("Canvas");
		pop = gameObject.GetComponent<Destruction>();
		gm = gameObject.GetComponent<GameManager>();
		
		InitializeZone();
	}
	public void InitializeZone()
	{
		Zone = gm.ZoneManager(cardatt);
		if (Zone == null)
		{
			Debug.LogError("Zone not found" + cardatt.field);
			return;
		}
		field = Zone.GetComponent<FieldAttributes>();
		if (field == null)
		{
			Debug.LogError("FieldAttributes not found on zone");
			return;
		}
		maxsize = field.maxsize;
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
		Zone = gm.ZoneManager(cardatt);
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
		Zone = gm.ZoneManager(cardatt);
		field = Zone.GetComponent<FieldAttributes>();
		StartParent = transform.parent.gameObject;
		StartPosition = transform.position;
		IsDragging = true;
	}
	public void EndDrag()
	{
		IsDragging = false;
		if (gm.TurnCorroborer(field))
		{
		if (isover && cardatt.IsClear && field.counter != 0)
		{
			gm.ConfirmWeather(Zone);
			int i = pop.DestroyWeather(Zone, cardatt);
			field.counter -= i;
			gm.ReduceWeather(cardatt);
			gm.WeatherTransform();
			Destroy(this.gameObject);
		}
		if (isover && cardatt.field == "Weather" && field.counter < maxsize && (cardatt.IsClear == false))
		{
			transform.SetParent(Zone.transform);
			field.counter++;
			gm.WeatherClause(cardatt);
		}
		else if (isover && field.counter < maxsize && (cardatt.IsClear == false) && cardatt.faccion != "Weather")
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
