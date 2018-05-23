using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStats : MonoBehaviour
{
    [Header("Statistics")]
    public Stat LVL;         //Level: Co poziom zwiększane jest 'Health Points' bohatera o 20, 'Spirit Points' o 10

                             // oraz dostajemy 3 punktów statystyk do rozdania

    public Stat HP;          //Health Points          //--> HP + CON* 3 = HP
    public Stat SP;          //Spiritual Points       //--> SP + SPR* 3 = SP

    public Stat MIN_ATT;     //Minimum Attack
    public Stat MAX_ATT;     //Maximum Attack         //--> sprawdzam Miecz ATT + STR = MIN ATT + X% = MAX ATT 
                                                      //--> sprawdzam Łuk ATT + ACC = MIN ATT + X% = MAX ATT 
                                                      //--> sprawdzam Rózga ATT + SPR = MIN ATT + X% = MAX ATT 
   
    public Stat CRI_RATE;    //Critical Attack        //--> sprawdzam Pierścień CRI RATE + ACC = CRI RATE %
    public Stat DEF;         //Defense                //--> sprawdzam EQ DEF + CON = DEF
    public Stat ATT_SPD;     //Attack Speed           //--> ATT SPEED + AGI = ATT SPEED
    public Stat MOV_SPD;     //Movement Speed         //--> sprawdzam Naszyjnik MOVEMENT SPEED + AGI  = MOVEMENT SPEED

    public Stat STR;          // Strenght - siła
    public Stat ACC;          // Accuracy - celność                           
    public Stat SPR;          // Spirit - duchowość                         
    public Stat CON;          // Constitution - wytrzymalość                  
    public Stat AGI;          // Agility - zeinność

    [Header("Exp to get after kill")]
    public int EXP;

    public int CurrentHP { get; protected set; }
    public int MaxHP { get; protected set; }
    public int CurrentSP { get; protected set; }
    public int MaxSP { get; protected set; }

    public int CurrentMIN_ATT { get; protected set; }
    public int CurrentMAX_ATT { get; protected set; }
    public int CurrentDMG { get; protected set; }

    public int CurrentCRI_RATE { get; protected set; }
    public int CurrentDEF { get; protected set; }
    public int CurrentATT_SPD { get; protected set; }
    public int CurrentMOV_SPD { get; protected set; }

    

    public event System.Action OnHealthReachedZero;

   protected virtual void Start()
    {
        CurrentHP = CalculateMaxHP();
        CalculateCurrentMIN_ATT();
        CalculateCurrentMAX_ATT();
        CalculateCurrentCRI_RATE();
        CalculateCurrentDEF();
        CalculateCurrentATT_SPD();
        CalculateCurrentMOV_SPD();

    }


    #region Calculators



    public int CalculateMaxHP()
    {
        MaxHP = HP.GetValue() + (LVL.GetValue() * 20) + (CON.GetValue() * 3);
        return MaxHP;
    }

    public int CalculateMaxSP()
    {
        MaxSP = SP.GetValue() + (LVL.GetValue() * 10) + (SPR.GetValue() * 3);
        return MaxSP;
    }

    public virtual int CalculateCurrentMIN_ATT()
    {
        CurrentMIN_ATT = MIN_ATT.GetValue();   
        return CurrentMIN_ATT;
    }

    public int CalculateCurrentMAX_ATT()
    {
        CurrentMAX_ATT = MAX_ATT.GetValue() + CurrentMIN_ATT;
        return CurrentMAX_ATT;
    }

    
    public int CalculateCurrentDMG()
    {
        CalculateCurrentMIN_ATT();
        CalculateCurrentMAX_ATT();
        if (Random.Range(1, 100) <= CurrentCRI_RATE)
        {
            int baseDmg = Random.Range(CurrentMIN_ATT, CurrentMAX_ATT);
            CurrentDMG = baseDmg + baseDmg / 2;

        }
        else
        {
            CurrentDMG = Random.Range(CurrentMIN_ATT, CurrentMAX_ATT);
          
        }
        

        return CurrentDMG;
    }

    public int CalculateCurrentCRI_RATE()
    {
        CurrentCRI_RATE = CRI_RATE.GetValue() + ACC.GetValue();
        return CurrentCRI_RATE;
    }

    public int CalculateCurrentDEF()
    {
        CurrentDEF = DEF.GetValue() + CON.GetValue();
        return CurrentDEF;
    }

    public int CalculateCurrentATT_SPD()
    {
        CurrentATT_SPD = ATT_SPD.GetValue() + AGI.GetValue();
        return CurrentATT_SPD;
    }

    public int CalculateCurrentMOV_SPD()
    {
        CurrentMOV_SPD = MOV_SPD.GetValue() + AGI.GetValue();
        return CurrentMOV_SPD;
    }
    #endregion


    
    public void TakeDamage(int damage)
    {
   
        damage -= CurrentDEF;
        damage = Mathf.Clamp(damage, 0, int.MaxValue);

        CurrentHP -= damage;

        CharacterUIDamage.instance.ShowDamage(damage.ToString(), transform);

        Debug.Log(transform.name + " takes " + damage + " damage.");

        if (CurrentHP <= 0)
        {
            if (OnHealthReachedZero != null)
            {
                OnHealthReachedZero();
            }
        }
    }

    

}