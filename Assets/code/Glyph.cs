using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class Glyph {
    [SerializeField]
    float red = 128;
    public float Red { get { return red; } set { red = value; } }
    [SerializeField]
    float green = 128; 
    public float Green { get { return green; } set { green = value; } }
    [SerializeField]
    float blue = 128; 
    public float Blue { get { return blue; } set { blue = value; } }

    public Glyph SumGlyphs(Glyph glyph)
    {
        glyph.Red += red;
        glyph.Blue += blue;
        glyph.Green += green;
        return glyph; 
    }

    public float CalculateDeviation(Glyph glyph)
    {
        float total = 0;
        total += Mathf.Pow(glyph.Red - red, 2);
        total += Mathf.Pow(glyph.Blue - blue, 2);
        total += Mathf.Pow(glyph.Green - green, 2);
        return total;
    }
}
