using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UStateMachine<TParamStruct> where TParamStruct : struct
{
	public UState<TParamStruct>[] States;
	public UState<TParamStruct> ActiveState;

	private Dictionary<Type, int> typeMap;

	public UStateMachine(TParamStruct p, params UState<TParamStruct>[] states)
	{
		States = states;

		typeMap = new Dictionary<Type, int>();

		for (int i = 0; i < states.Length; i++)
		{
			states[i].Parent = this;
			typeMap.Add(states[i].GetType(), i);
		}

		ActiveState = states[0];
		ActiveState.Enter(p);
	}

	public void Update(TParamStruct parameters)
	{
		if (ActiveState == null)
			return;
		ActiveState.Update(parameters);
		ActiveState.CheckForTransitions(parameters);
	}

	public void OnGUI(TParamStruct parameters)
	{
		if (ActiveState != null)
			ActiveState.OnGUI(parameters);
	}

	public void SetState(Type stateType, TParamStruct parameters)
	{
		// Set the state to a certain state type
		if (ActiveState != null)
			ActiveState.Exit(parameters);
		ActiveState = States[typeMap[stateType]];
		ActiveState.Enter(parameters);
	}
}