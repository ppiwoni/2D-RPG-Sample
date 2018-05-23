using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayerUIStatusBars : MonoBehaviour {

    
    public Slider hpBar;
    public Slider spBar;
    public Slider expBar;
    public Text lvlText;

    protected PlayerStats stats;


    protected virtual void Start()
    {

        stats = Player.instance.playerStats;

    }

    protected virtual void Update()
    {
        if (stats != null)
        {
           
            float hpPercent = GetHpPercent();
            hpBar.value = hpPercent;

            float spPercent = GetSpPercent();
            spBar.value = spPercent;

            float expPercent = GetExpPercent();
            expBar.value = expPercent;

            lvlText.text = "LVL " + stats.LVL.GetValue();
        }


    }

   protected float GetHpPercent()
    {
        return Mathf.Clamp01(stats.CurrentHP / (float)stats.MaxHP);
    }

    protected float GetSpPercent()
    {
        return Mathf.Clamp01(stats.CurrentSP / (float)stats.MaxSP);
    }

    protected float GetExpPercent()
    {
        return Mathf.Clamp01(stats.CurrentEXP / (float)stats.MaxEXP);
    }

}


