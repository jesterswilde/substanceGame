using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Substance : MonoBehaviour {
    [SerializeField]
    List<Glyph> glyphs = new List<Glyph>();
    [SerializeField]
    Glyph glyphTotal = new Glyph();
    public Glyph Glyph { get { return glyphTotal; } }
    [SerializeField]
    Material mat;
    [SerializeField]
    Properties properties; 

    Renderer rend;

    [SerializeField]
    bool overrideColor = false;

    public float CalculateDeviation(Substance substance)
    {
        return glyphTotal.CalculateDeviation(substance.Glyph); 
    }

    public void AddGlyph(Glyph glyph)
    {
        glyphs.Add(glyph);
        UpdateGlyph(); 
    }

    public void RemoveGlyph(Glyph glyph)
    {
        glyphs.Remove(glyph);
        UpdateGlyph(); 
    }
    public void RemoveGlyph(int index)
    {
        glyphs.RemoveAt(index);
        UpdateGlyph(); 
    }

    void UpdateGlyph()
    {
        glyphTotal = glyphs.Aggregate(new Glyph(), (accGlyph, glyph) =>
        {
            return glyph.SumGlyphs(accGlyph); 
        });
    }
  
    private void Start()
    {
        rend = GetComponent<Renderer>(); 
        UpdateGlyph(); 
        if(rend != null)
        {
            if(mat == null)
            {
                mat = SubstanceManager.DefaultMaterial; 
            }
            rend.material = mat; 
            if (overrideColor)
            {
                mat.color = new Color(glyphTotal.Red, glyphTotal.Green, glyphTotal.Blue); 
            }    
        }
    }

}
