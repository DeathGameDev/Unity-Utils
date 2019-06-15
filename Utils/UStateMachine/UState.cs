using System;
using System.Collections.Generic;
using System.Linq;

public abstract class UState<TParamStruct> where TParamStruct : struct
{
	public UStateMachine<TParamStruct> Parent;

	public virtual void Enter(TParamStruct ps) { }
	public virtual void Update(TParamStruct ps) { }
	public virtual void OnGUI(TParamStruct ps) { }
	public virtual void CheckForTransitions(TParamStruct ps) { }
	public virtual void Exit(TParamStruct ps) { }
}