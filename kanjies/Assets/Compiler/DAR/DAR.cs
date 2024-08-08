using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Dar;
using Dar.CodeAnalysis;
using Dar.CodeAnalysis.Syntax;
using Dar.CodeAnalysis.Symbols;
using System.Linq;


public class DAR : MonoBehaviour {
	string t = @"{
        var x = 1
        for i = 1 to 10
        {
            x = x * 2
        }
        x
        }";
	public Compilation _previous;
	private readonly Dictionary<VariableSymbol, object> _variables = new Dictionary<VariableSymbol, object>();

	// Use this for initialization
	void Start () 
	{
		Compile(t);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	public void Compile(string text)
	{
		var syntaxTree = SyntaxTree.Parse(text);
		var compilation = _previous == null
                                ? new Compilation(syntaxTree)
                                : _previous.ContinueWith(syntaxTree);
		
		var result = compilation.Evaluate(_variables);

		if (!result.Diagnostics.Any())
		{
			Debug.Log(result.Value);

			_previous = compilation;
		}
		else
		{
			foreach (var d in result.Diagnostics)
			{
				Debug.LogError(d.Message);
			}
		}
	}
}
