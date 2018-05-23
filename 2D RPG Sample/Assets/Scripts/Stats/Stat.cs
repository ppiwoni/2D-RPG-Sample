using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Stat
{

    public int baseValue;   

    // Lista modyfikatorow np. z ekwipunku lub viala
    private List<int> modifiers = new List<int>();

    
    public int GetValue()
    {
        int finalValue = baseValue;
        modifiers.ForEach(x => finalValue += x); //kazdego int x w liscie modifiers dodajemy do final value
        return finalValue;
    }

  
    public void AddModifier(int modifier)
    {
        if (modifier != 0)
            modifiers.Add(modifier);
    }

   
    public void RemoveModifier(int modifier)
    {
        if (modifier != 0)
            modifiers.Remove(modifier);
    }

}