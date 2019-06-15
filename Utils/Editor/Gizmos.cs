using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public static partial class Utils
{
    public class ColorScopeInstance : Scope
    {
        private Color cachedColor;
        private ColorSpace colorSpace;

        public ColorScopeInstance(ColorSpace actingColorSpace, Color color)
        {
            colorSpace = actingColorSpace;
            switch (colorSpace)
            {
                case ColorSpace.Gizmos:
                    cachedColor = Gizmos.color;
                    Gizmos.color = color;
                    break;
                case ColorSpace.Handles:
                    cachedColor = Handles.color;
                    Handles.color = color;
                    break;
            }
        }

        protected override void CloseScope()
        {
            switch (colorSpace)
            {
                case ColorSpace.Gizmos:
                    Gizmos.color = cachedColor;
                    break;
                case ColorSpace.Handles:
                    Handles.color = cachedColor;
                    break;
            }
        }

        public enum ColorSpace
        {
            Gizmos, Handles
        }
    }

    public static ColorScopeInstance ColorScope(this Gizmos g, Color c)
    {
        return new ColorScopeInstance(ColorScopeInstance.ColorSpace.Gizmos, c);
    }
}