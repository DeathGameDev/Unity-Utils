using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class GUIColorScope : Scope
{
	private readonly Color cachedColor;

	public GUIColorScope(Color color)
	{
		cachedColor = GUI.color;
		GUI.color = color;
	}

	protected override void CloseScope()
	{
		GUI.color = cachedColor;
	}
}