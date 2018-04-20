using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq; 


public class SubstanceManager : MonoBehaviour {

    public static SubstanceManager t;

    [SerializeField]
    Material defaultMaterial; 
    public static Material DefaultMaterial { get { return t.defaultMaterial; } }
    [SerializeField]
    List<Substance> substances; 

    public static Substance GetClosestSubstance(Substance substance)
    {
        Substance closest = null;
        float smallestDiff = float.MaxValue;
        t.substances.ForEach((_substance) =>
        {
            float diff = _substance.CalculateDeviation(substance);
            if ( diff < smallestDiff)
            {
                closest = _substance;
                smallestDiff = diff; 
            }
        });
        return closest; 
    }
}
