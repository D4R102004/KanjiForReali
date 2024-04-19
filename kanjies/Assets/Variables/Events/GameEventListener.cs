using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System;
[Serializable]
public class CustomGameEvent : UnityEvent<Component, object, object, object> {}
public class GameEventListener : MonoBehaviour {

	public GameEvent gameEvent;
	public CustomGameEvent response;
	private void OnEnable() {
    	gameEvent.Register(this);
	}
	private void OnDisable() {
		gameEvent.Unregister(this);
	}
	public void OnEventRaised(Component sender, object data1, object data2, object data3)
	{
		response.Invoke(sender, data1, data2, data3);
	}
}
