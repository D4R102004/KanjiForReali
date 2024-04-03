using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
using UnityEngineInternal;

public class GameManager : MonoBehaviour 
{
	public Text PlayerScore;
	public Text PlayScore;
	public Text OppScore;
	List<GameObject> cards = new List<GameObject>();
	public GameObject Card2;
	public GameObject DenkiCard;
	public GameObject HaganeCard;
	public GameObject Weather1;
	public GameObject Clear1;
	public GameObject BoostM;
	public GameObject BoostR;
	public GameObject BoostS;
	public GameObject BoostMo;
	public GameObject BoostRo;
	public GameObject BoostSo;
	public GameMechanics Mechanics;
	public GameObject m;
	public GameObject r;
	public GameObject s;
	public GameObject mo;
	public GameObject ro;
	public GameObject so;
	public GameObject WeatherZone;
	public WeatherModifiers wetmod;
	public TurnSystem turn;
	public PlayerLogic Player;
	public PlayerLogic P1;
	public PlayerLogic P2;
	public GameObject PlayerHand;
	public GameObject OppHand;

	private void Awake()
	{
		
	}
	public void InitializePlayer()
	{
		if (turn.IsYourTurn)
		{
			Player = GameObject.Find("Player1").GetComponent<PlayerLogic>();
			PlayerScore = GameObject.Find("Player1Power").GetComponent<Text>();
		} 
		else if (turn.IsYourTurn == false)
		{
			Player = GameObject.Find("Player2").GetComponent<PlayerLogic>();
			PlayerScore = GameObject.Find("Player2Power").GetComponent<Text>();
		}
		if (PlayerScore == null) Debug.LogError("Score not found");
	}


	// Use this for initialization
	void Start () 
	{
		PlayScore = GameObject.Find("Player1Power").GetComponent<Text>();
		OppScore = GameObject.Find("Player2Power").GetComponent<Text>();
		P1 = GameObject.Find("Player1").GetComponent<PlayerLogic>();
		P2 = GameObject.Find("Player2").GetComponent<PlayerLogic>();
		WeatherZone = GameObject.Find("Weather");
		m = GameObject.Find("Melee");
		r = GameObject.Find("Range");
		s = GameObject.Find("Siege");
		mo = GameObject.Find("OppMelee");
		ro = GameObject.Find("OppRange");
		so = GameObject.Find("OppSiege");
		BoostM = GameObject.Find("BoostMelee");
		BoostR = GameObject.Find("BoostRange");
		BoostS = GameObject.Find("BoostSiege");
		BoostMo = GameObject.Find("OppBoostM");
		BoostRo = GameObject.Find("OppBoostR");
		BoostSo = GameObject.Find("OppBoostS");
		turn = GameObject.Find("TurnSystem").GetComponent<TurnSystem>();
		InitializePlayer();
		PlayerHand = GameObject.Find("PlayerHand");
		OppHand = GameObject.Find("OpponentHand");
	}
	
	// Update is called once per frame
	void Update () 
	{ 
		PlayScore.text = P1.CollectedPower.ToString();
		OppScore.text = P2.CollectedPower.ToString();
		PlayerScore.text = Player.CollectedPower.ToString();
		
	}
	public void AttackGiver(CardsAttributes card)
	{
		Player.CollectedPower += card.power;
		if (card.field == "Melee") Player.MeleePower += card.power;
		else if (card.field == "Range") Player.RangePower += card.power;
		else  Player.SiegePower += card.power;
		Debug.Log("Current Power == " + Player.CollectedPower); 
	}
	public void BoostGiver(CardsAttributes card)
	{
		if (card.faccion == "Melee")
		{
			Player.BoostMelee = card.power;
		}
		else if (card.faccion == "Range")
		{
			Player.BoostRange = card.power;
		}
		else Player.BoostSiege = card.power;
	}
	public void WeatherClause(CardsAttributes card)
	{
		if (card.faccion == "Melee")
		{
			Player.WeatherMelee += card.power;
			wetmod.Melee = 1;
		}
		else if (card.faccion == "Range") 
		{
			Player.WeatherRange += card.power;
			wetmod.Range = 1;
		}
		else 
		{
			Player.WeatherSiege += card.power;
			wetmod.Melee = 1;
		}
	}
	public void PlayerEnd()
	{ 
		FieldAttributes m1 = m.GetComponent<FieldAttributes>();
		FieldAttributes r1 = r.GetComponent<FieldAttributes>();
		FieldAttributes s1 = s.GetComponent<FieldAttributes>();
		if (turn.IsYourTurn)
		{
		m1 = m.GetComponent<FieldAttributes>();
		r1 = r.GetComponent<FieldAttributes>();
		s1 = s.GetComponent<FieldAttributes>();
		}
		else 
		{
			m1 = mo.GetComponent<FieldAttributes>();
			r1 = ro.GetComponent<FieldAttributes>();
			s1 = so.GetComponent<FieldAttributes>();
		}
		WeatherTransform();
		for (int i = 0; i < m1.counter; i++)
		{
			if (Player.MeleePower > 0) 
			{
				Player.MeleePower += Player.BoostMelee;
				Player.CollectedPower += Player.BoostMelee;
			}
		}
		for (int i = 0; i < r1.counter; i++)
		{
			if (Player.RangePower > 0) 
			{
				Player.RangePower += Player.BoostRange;
				Player.CollectedPower += Player.BoostRange;
			}
		}
		for (int i = 0; i < s1.counter; i++)
		{
			if (Player.SiegePower > 0) 
			{
				Player.CollectedPower += Player.BoostSiege;
				Player.SiegePower += Player.BoostSiege;
			}
		}
		for (int i = 0; i < m1.counter; i++)
		{
			if (Player.MeleePower > 0)
			{
				Player.MeleePower -= Player.WeatherMelee;
				Player.CollectedPower -= Player.WeatherMelee;
				if (Player.MeleePower < 0) Player.MeleePower = 0;
				if (Player.CollectedPower < 0) Player.CollectedPower = 0;
			}
		}
		for (int i = 0; i < r1.counter; i++)
		{
			if (Player.RangePower > 0)
			{
				Player.RangePower -= Player.WeatherRange;
				Player.CollectedPower -= Player.WeatherRange;
				if (Player.RangePower < 0) Player.SiegePower = 0;
				if (Player.CollectedPower < 0) Player.CollectedPower = 0;
			}
		}
		for (int i = 0; i < s1.counter; i++)
		{
			if (Player.SiegePower > 0)
			{
				Player.SiegePower -= Player.WeatherSiege;
				Player.CollectedPower -= Player.WeatherSiege;
				if (Player.SiegePower < 0) Player.SiegePower = 0;
				if (Player.CollectedPower < 0) Player.CollectedPower = 0;
			}
		}
		FieldAttributes weatherfield = WeatherZone.GetComponent<FieldAttributes>();
		weatherfield.Player = turn.IsYourTurn;
		PlayerLogic Previous = Player;
		
		Player.WeatherMelee = Previous.WeatherMelee;
		Player.WeatherRange = Previous.WeatherRange;
		Player.WeatherSiege = Previous.WeatherSiege;
	}
	public void Clear(string type, int number)
	{
		if (type == "Melee") Player.WeatherMelee -= number;
		else if (type == "Range") Player.WeatherRange -= number;
		else Player.WeatherSiege -= number;
	}
	public void ConfirmWeather(GameObject zone)
	{
		foreach (Transform child in zone.transform)
		{
			if (child != null)
			{
			string type = child.GetComponent<DragDropKan>().cardatt.faccion;
			int i = child.GetComponent<DragDropKan>().cardatt.power;
			if (type == "Melee") wetmod.Melee += i;
			else if (type == "Range") wetmod.Range += i;
			else wetmod.Siege += i;
			}
		}
	}
	public void ReduceWeather(CardsAttributes cardatt)
	{
		if (cardatt.faccion == "Melee") wetmod.Melee = 0;
		else if (cardatt.faccion == "Range") wetmod.Range = 0;
		else wetmod.Siege = 0;
	}
	public void WeatherTransform()
	{
		if (wetmod.Melee == 0) Player.WeatherMelee = 0;
		else if (wetmod.Melee == 0) Player.WeatherRange = 0;
		else if (wetmod.Melee == 0) Player.WeatherSiege = 0;
	}
	public void Yuyu()
	{
		cards.Add(DenkiCard);
		cards.Add(HaganeCard);
		cards.Add(Card2);
		GameObject yuyucard = Instantiate(cards[Random.Range(0, cards.Count)], new Vector3(0,0,0), Quaternion.identity);
		GameManager gm = yuyucard.GetComponent<GameManager>();
		gm.PlaceCard();
	}
	public void PlaceCard()
	{
		GameObject Zone = ZoneManager(this.gameObject.GetComponent<CardsAttributes>());
		if (Zone.GetComponent<FieldAttributes>().counter < Zone.GetComponent<FieldAttributes>().maxsize)
		{
			transform.SetParent(Zone.transform);
			Zone.GetComponent<FieldAttributes>().counter++;
		    if (this.gameObject.GetComponent<CardsAttributes>().Boost) BoostGiver(this.gameObject.GetComponent<CardsAttributes>());
		    else AttackGiver(this.gameObject.GetComponent<CardsAttributes>());
		}
	}
	public bool TurnCorroborer(FieldAttributes field)
		{
			if (turn.IsYourTurn == field.Player) return true;
			else return false;
		}
	public GameObject ZoneManager(CardsAttributes card)
	{
		if (card.field == "Melee")
		{
			if (turn.IsYourTurn) return m;
			else return mo;
		}
		else if (card.field == "Range")
		{
			if (turn.IsYourTurn) return r;
			else return ro;
		}
		else if (card.field == "Siege")
		{
			if (turn.IsYourTurn) return s;
			else return so;
		}
		else if (card.field == "BoostMelee")
		{
			if (turn.IsYourTurn) return BoostM;
			else return BoostMo;
		}
		else if (card.field == "BoostRange")
		{
			if (turn.IsYourTurn) return BoostR;
			else return BoostRo;
		}
		else if (card.field == "BoostSiege")
		{
			if (turn.IsYourTurn) return BoostS;
			else return BoostSo;
		}
		else return WeatherZone;
	}
	/*public void Effect(CardProperties card)
	{
		if (card.CardID == 1)
		{
			PlayerMeleePower += 2;
			Debug.Log("Current Melee" + PlayerMeleePower);
		}
	}*/

}
