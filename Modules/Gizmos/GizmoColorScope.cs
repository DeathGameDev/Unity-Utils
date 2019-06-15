using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GizmoColorScope : Scope
{
	private readonly Color cachedColor;

	public GizmoColorScope(Color color)
	{
		cachedColor = Gizmos.color;
		Gizmos.color = color;
	}

	protected override void CloseScope()
	{
		Gizmos.color = cachedColor;
	}
}