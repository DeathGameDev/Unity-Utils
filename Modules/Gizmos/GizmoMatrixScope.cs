using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GizmoMatrixScope : Scope
{
	private readonly Matrix4x4 cachedMtx;

	public GizmoMatrixScope(Matrix4x4 mtx)
	{
		cachedMtx = Gizmos.matrix;
		Gizmos.matrix = mtx;
	}

	protected override void CloseScope()
	{
		Gizmos.matrix = cachedMtx;
	}
}