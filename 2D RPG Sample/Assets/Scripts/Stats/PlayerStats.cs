using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : CharacterStats
{
  
    public int freeStatsPoints = 3;
    public int skillPoints = 1;

    public int MaxEXP { get; protected set; }
    public int CurrentEXP { get; protected set; }



    protected override void Start()
    {
       
        base.Start();
        CalculateMaxEXP();
        CurrentSP = CalculateMaxSP();
        EquipmentManager.instance.onEquipmentChanged += OnEquipmentChanged;

        InvokeRepeating("Regeneration", 1.0f, 5f);

    }

    void OnEquipmentChanged(Equipment newItem, Equipment oldItem)
    {
        if (newItem != null)
        {
            HP.AddModifier(newItem.HP);
            SP.AddModifier(newItem.SP);

            MIN_ATT.AddModifier(newItem.MIN_ATT);
            MAX_ATT.AddModifier(newItem.MAX_ATT);

            CRI_RATE.AddModifier(newItem.CRI_RATE);
            DEF.AddModifier(newItem.DEF);
            ATT_SPD.AddModifier(newItem.ATT_SPD);
            MOV_SPD.AddModifier(newItem.MOV_SPD);

            STR.AddModifier(newItem.STR);
            ACC.AddModifier(newItem.ACC);
            SPR.AddModifier(newItem.SPR);
            CON.AddModifier(newItem.CON);
            AGI.AddModifier(newItem.CON);

            CalculateMaxHP();
            CalculateMaxSP();
            CalculateCurrentDMG();
            CalculateCurrentCRI_RATE();
            CalculateCurrentDEF();
            CalculateCurrentATT_SPD();
            CalculateCurrentMOV_SPD();

        }

        if (oldItem != null)
        {
            HP.RemoveModifier(oldItem.HP);
            SP.RemoveModifier(oldItem.SP);

            MIN_ATT.RemoveModifier(oldItem.MIN_ATT);
            MAX_ATT.RemoveModifier(oldItem.MAX_ATT);

            CRI_RATE.RemoveModifier(oldItem.CRI_RATE);
            DEF.RemoveModifier(oldItem.DEF);
            ATT_SPD.RemoveModifier(oldItem.ATT_SPD);
            MOV_SPD.RemoveModifier(oldItem.MOV_SPD);

            STR.RemoveModifier(oldItem.STR);
            ACC.RemoveModifier(oldItem.ACC);
            SPR.RemoveModifier(oldItem.SPR);
            CON.RemoveModifier(oldItem.CON);
            AGI.RemoveModifier(oldItem.CON);

            CalculateMaxHP();
            CalculateMaxSP();
            CalculateCurrentDMG();
            CalculateCurrentCRI_RATE();
            CalculateCurrentDEF();
            CalculateCurrentATT_SPD();
            CalculateCurrentMOV_SPD();

        }

    }


    public override int CalculateCurrentMIN_ATT()
    {
        Equipment currentWeapon = EquipmentManager.instance.currentEquipment[3];

        if (currentWeapon != null)
        {
            if (currentWeapon.weaponType == WeaponType.Axe)
            {
                CurrentMIN_ATT = MIN_ATT.GetValue() + STR.baseValue;
            }
            else if (currentWeapon.weaponType == WeaponType.Bow)
            {
                CurrentMIN_ATT = MIN_ATT.GetValue() + ACC.baseValue;
            }
            else if (currentWeapon.weaponType == WeaponType.Staff)
            {
                CurrentMIN_ATT = MIN_ATT.GetValue() + SPR.baseValue;
            }

        }
        else
        {
            CurrentMIN_ATT = MIN_ATT.GetValue() + STR.baseValue;
        }

        return CurrentMIN_ATT;
    }

    public int CalculateMaxEXP()
    {
        MaxEXP = LVL.GetValue() * 100;
        return MaxEXP;
    }

    public void PlayerLvlUpSystem (int exp)
    {
        CurrentEXP += exp;
        if (CurrentEXP >= MaxEXP)
        {
            LVL.baseValue++;
            freeStatsPoints += 3;
            skillPoints += 1;

            CurrentEXP = 0;

            CalculateMaxHP();
            CalculateMaxSP();
            CalculateMaxEXP();
            
        }
    }

    void Regeneration()
    {
        if (CurrentHP != MaxHP)
        {
            if (CurrentHP > MaxHP - 3)
            {
                CurrentHP += MaxHP - CurrentHP;
                    return;
            }
            CurrentHP += 3;
        }

        if (CurrentSP != MaxSP)
        {
            if (CurrentSP > MaxSP - 5)
            {
                CurrentSP += MaxSP - CurrentSP;
                return;
            }
            CurrentSP += 5;
        }

    }

    public void SpEater(int sp)
    {
        CurrentSP -= sp;
    }

}
