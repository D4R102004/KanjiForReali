using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class ImageReference  
{
	public bool Edit;
	public Sprite MyImage;
	public ImageVariable Variable;
	public Sprite Image
	{
		get {return Edit? MyImage : Variable.Image;}
	}


}
