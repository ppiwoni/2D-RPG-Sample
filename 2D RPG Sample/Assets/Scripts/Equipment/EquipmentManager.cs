using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipmentManager : MonoBehaviour {

    #region Singleton

    public static EquipmentManager instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<EquipmentManager>();
            }
            return _instance;
        }
       
    }
    static EquipmentManager _instance;

    private void Awake()
    {
        _instance = this;
    }
    #endregion

    public Equipment[] currentEquipment;

    public delegate void OnEquipmentChanged(Equipment newItem, Equipment oldItem);
    public event OnEquipmentChanged onEquipmentChanged;


    Inventory inventory;

    private void Start()
    {
        inventory = Inventory.instance;
        int numSlots = System.Enum.GetNames(typeof(EquipmentSlots)).Length; // 9 slotow
        currentEquipment = new Equipment[numSlots]; // tworzymy tablice Eq o wielkosci 9 
      
    }
    

    
    public void Equip(Equipment newItem)
    {
        Equipment oldItem = null;

        int slotIndex = (int)newItem.equipmentSlot;
       
        if (currentEquipment[slotIndex] != null)
        {
            oldItem = currentEquipment[slotIndex];

            inventory.Add(oldItem);

        }


        currentEquipment[slotIndex] = newItem;

   

        if (onEquipmentChanged != null)
            onEquipmentChanged.Invoke(newItem, oldItem);

        
        Debug.Log(newItem.name + " equipped!");

    }

    void Unequip(int slotIndex)
    {
        if (currentEquipment[slotIndex] != null)
        {
            Equipment oldItem = currentEquipment[slotIndex];
            inventory.Add(oldItem);

            currentEquipment[slotIndex] = null;
           
            if (onEquipmentChanged != null)
                onEquipmentChanged.Invoke(null, oldItem);

        }


    }
}
