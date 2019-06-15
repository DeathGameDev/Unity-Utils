using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Reimplementation of Unity's GUI.Scope(), just without the if(GUIUtility.guiIsExiting) check.
/// </summary>
public abstract class Scope : IDisposable
{
    private bool isDisposed;

    protected abstract void CloseScope();

    ~Scope()
    {
        if (this.isDisposed)
            return;
        Debug.LogError((object)"Scope was not disposed! You should use the 'using' keyword or manually call Dispose.");
    }

    public void Dispose()
    {
        if (isDisposed)
            return;
        isDisposed = true;
        CloseScope();
    }
}