using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
[Serializable]
public class StringReference 
{
    public bool Write = true;
    public string Written;
    public StringVariable Variable;
    public string Word
    {
        get {return Write? Written : Variable.Word;}
    }


}
