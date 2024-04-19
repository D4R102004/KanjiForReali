﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoomDisplayer : MonoBehaviour {

	public void GetZoom(Component sender, object data1, object data2, object data3)
	{
		GameObject card = (GameObject)data1;
        card.transform.SetParent(this.gameObject.transform, true);
        card.transform.position = this.transform.position;
        RectTransform rect = card.GetComponent<RectTransform>();
        rect.sizeDelta = new Vector2(209, 218);
}
}