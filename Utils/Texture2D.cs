using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static partial class Utils
{
    /// <summary>
    /// Converts a Texture2D to a Sprite
    /// </summary>
    public static Sprite ToSprite(this Texture2D t)
    {
        return Sprite.Create(t, new Rect(0, 0, t.width, t.height), new Vector2(0.5f, 0.5f));
    }

    /// <summary>
    /// Converts a list of Texture2D to a list of Sprites.
    /// </summary>
    public static List<Sprite> ToSprites(this List<Texture2D> l)
    {
        List<Sprite> sprites = new List<Sprite>();
        foreach (Texture2D t in l)
        {
            sprites.Add(Sprite.Create(t, new Rect(0, 0, t.width, t.height), new Vector2(0.5f, 0.5f)));
        }
        return sprites;
    }

    /// <summary>
    /// Converts a dictionary of Type and Texture2D to a Dict of Type and Sprite.
    /// </summary>
    public static Dictionary<T, Sprite> ToSprites<T>(this Dictionary<T, Texture2D> dict)
    {
        Dictionary<T, Sprite> spriteDict = new Dictionary<T, Sprite>();
        foreach (KeyValuePair<T, Texture2D> pair in dict)
        {
            spriteDict.Add(pair.Key, pair.Value.ToSprite());
        }
        return spriteDict;
    }

    /// <summary>
    /// Crops a texture2D by it's alpha.
    /// </summary>
    public static Texture2D CropByAlpha(this Texture2D tex)
    {
        Vector2 least = new Vector2(tex.width, tex.height);
        Vector2 most = new Vector2(0, 0);
        for (int x = 0; x < tex.width; x++)
        {
            for (int y = 0; y < tex.height; y++)
            {
                Color c = tex.GetPixel(x, y);
                if (c == Color.clear) continue;
                if (x < least.x)
                    least.x = x;
                if (x > most.x)
                    most.x = x;
                if (y < least.y)
                    least.y = y;
                if (y > most.y)
                    most.y = y;
            }
        }
        //If our values are the same, the entire image is transparent, so we don't need to do anything.
        if (most == Vector2.zero && least == new Vector2(tex.width, tex.height))
            return tex;

        //Since the entire image wasn't transparent, crop it and return.
        Vector2 size = (most - least);
        Rect cropRect = new Rect(least, size);
        Texture2D result = new Texture2D((int)size.x, (int)size.y);
        result.filterMode = tex.filterMode;
        Color[] pixels = tex.GetPixels(
            (int)cropRect.x,
            (int)cropRect.y,
            (int)cropRect.width,
            (int)cropRect.height);
        result.SetPixels(pixels);
        result.Apply();
        return result;
    }

    // http://wiki.unity3d.com/index.php?title=TextureDrawLine
    /// <summary>
    /// Draws a line on the texture.
    /// </summary>
    public static void DrawLine(this Texture2D tex, int x0, int y0, int x1, int y1, Color c = default(Color))
    {
        c = (c == default(Color)) ? Color.white : c;
        int dy = (int)(y1 - y0);
        int dx = (int)(x1 - x0);
        int stepx, stepy;

        if (dy < 0) { dy = -dy; stepy = -1; }
        else { stepy = 1; }
        if (dx < 0) { dx = -dx; stepx = -1; }
        else { stepx = 1; }
        dy <<= 1;
        dx <<= 1;

        float fraction = 0;

        tex.SetPixel(x0, y0, c);
        if (dx > dy)
        {
            fraction = dy - (dx >> 1);
            while (Mathf.Abs(x0 - x1) > 1)
            {
                if (fraction >= 0)
                {
                    y0 += stepy;
                    fraction -= dx;
                }
                x0 += stepx;
                fraction += dy;
                tex.SetPixel(x0, y0, c);
            }
        }
        else
        {
            fraction = dx - (dy >> 1);
            while (Mathf.Abs(y0 - y1) > 1)
            {
                if (fraction >= 0)
                {
                    x0 += stepx;
                    fraction -= dy;
                }
                y0 += stepy;
                fraction += dx;
                tex.SetPixel(x0, y0, c);
            }
        }

        tex.Apply();
    }

    public static void DrawLine(this Texture2D tex, Vector2 a, Vector2 b, Color c = default(Color))
    {
        tex.DrawLine((int)a.x, (int)a.y, (int)b.x, (int)b.y, c);
    }
}