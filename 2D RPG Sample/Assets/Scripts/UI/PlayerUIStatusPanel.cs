using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerUIStatusPanel : PlayerUIStatusBars {

    [Header("StatAddPanel")] 
    public Text hpText, spText, expText, strText, accText, conText, sprText, agiText, freeStatsText;

    [Header("StatShowPanel")]
    public Text minAttText;
    public Text maxAttText, criRateText, defText, attSpdText, movSpdText;

    

    protected override void Start()
    {

        base.Start();
       
    }

    protected override void Update()
    {
        
        if (stats != null)
        {

            hpText.text = "HP " + stats.CurrentHP + "/" + stats.MaxHP;
            spText.text = "SP " + stats.CurrentSP + "/" + stats.MaxSP;
            expText.text = "EXP " + stats.CurrentEXP + "/" + stats.MaxEXP;
            freeStatsText.text = "FREE STATS "+stats.freeStatsPoints;

            strText.text = "STR " + stats.STR.GetValue();
            accText.text = "ACC " + stats.ACC.GetValue();
            conText.text = "CON " + stats.CON.GetValue();
            sprText.text = "SPR " + stats.SPR.GetValue();
            agiText.text = "AGI " + stats.AGI.GetValue();

            minAttText.text = "MIN ATT " + stats.CurrentMIN_ATT;
            maxAttText.text = "MAX ATT " + stats.CurrentMAX_ATT;
            criRateText.text = "CRI RATE " + stats.CurrentCRI_RATE + "%";
            defText.text = "DEF " + stats.CurrentDEF;
            attSpdText.text = "ATT SPD " + stats.CurrentATT_SPD;
            movSpdText.text = "MOV SPD " + stats.CurrentMOV_SPD;


        }

        base.Update();
    }

    public void StrAddButton()
    {
        if (stats.freeStatsPoints > 0)
        {
            stats.STR.baseValue++;
            stats.freeStatsPoints--;
            stats.CalculateCurrentMIN_ATT();
            stats.CalculateCurrentMAX_ATT();
        }
    }

    public void AccAddButton()
    {
        if (stats.freeStatsPoints > 0)
        {
            stats.ACC.baseValue++;
            stats.freeStatsPoints--;
            stats.CalculateCurrentCRI_RATE();
            stats.CalculateCurrentMIN_ATT();
            stats.CalculateCurrentMAX_ATT();
        }
    }

    public void ConAddButton()
    {
        if (stats.freeStatsPoints > 0)
        {
            stats.CON.baseValue++;
            stats.freeStatsPoints--;
            stats.CalculateMaxHP();
            stats.CalculateCurrentDEF();
        }
    }

    public void SprAddButton()
    {
        if (stats.freeStatsPoints > 0)
        {
            stats.SPR.baseValue++;
            stats.freeStatsPoints--;
            stats.CalculateMaxSP();
            stats.CalculateCurrentMIN_ATT();
            stats.CalculateCurrentMAX_ATT();
        }
    }

    public void AgiAddButton()
    {
        if (stats.freeStatsPoints > 0)
        {
            stats.AGI.baseValue++;
            stats.freeStatsPoints--;
            stats.CalculateCurrentATT_SPD();
            stats.CalculateCurrentMOV_SPD();
        }
    }
}
