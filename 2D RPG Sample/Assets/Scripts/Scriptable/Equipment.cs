using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New item", menuName = "Inventory/Equipment")]
public class Equipment : Item {

    public EquipmentSlots equipmentSlot;
    public WeaponType weaponType;

    public int HP;          //Health Points         
    public int SP;          //Spiritual Points    

    public int MIN_ATT;     //Minimum Attack
    public int MAX_ATT;     //Maximum Attack         
                            
    public int CRI_RATE;    //Critical Attack       
    public int DEF;         //Defense                
    public int ATT_SPD;     //Attack Speed          
    public int MOV_SPD;     //Movement Speed        

    public int STR;          // Strenght - siła
    public int ACC;          // Accuracy - celność                           
    public int SPR;          // Spirit - duchowość                         
    public int CON;          // Constitution - wytrzymalość                  
    public int AGI;          // Agility - zeinność

    public override void Use()
    {
        EquipmentManager.instance.Equip(this);
        RemoveFromInventory();
        
    }

    

}


public enum EquipmentSlots { Head, Chest, Gloves, Weapon, Shield, Boots, Neck, Ring1, Ring2 }
public enum WeaponType { Axe, Bow, Staff, Sword}