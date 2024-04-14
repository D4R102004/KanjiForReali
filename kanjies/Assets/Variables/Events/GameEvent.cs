using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "GameEvent", menuName = "kanjies/GameEvent", order = 0)]
public class GameEvent : ScriptableObject 
{
	public List<GameEventListener> listeners = new List<GameEventListener>();
	public void Raise(Component sender, object data1, object data2, object data3)
	{
		for (int i = 0; i < listeners.Count; i++)
		{
			listeners[i].OnEventRaised(sender, data1, data2, data3);
		}
	}
	public void Register(GameEventListener listener)
	{
		if (!listeners.Contains(listener))
		{
			listeners.Add(listener);
		}
	}
	public void Unregister(GameEventListener listener)
	{
		if (listeners.Contains(listener))
		{
			listeners.Remove(listener);
		}
	}
	
} 
