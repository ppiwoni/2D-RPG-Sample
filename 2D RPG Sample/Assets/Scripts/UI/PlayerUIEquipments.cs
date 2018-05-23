using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerUIEquipments : MonoBehaviour {

    public Text moneyText;
    public GameObject itemSlotParent, equipmentSlotParent;

    Inventory inventory;
    EquipmentManager equipmentManager;

    private void Start()
    {
        equipmentManager = EquipmentManager.instance;
        inventory = Inventory.instance;
        inventory.onItemChangedCallback += UpdateUI;

        UpdateUI();
    
    }

  

    // Sprawdzam jak dużo mam slotów w inventory (w tym UI zawsze bedzie 48) i ile itemek aktualnie posiadam
    //- jeśli jakies mam to przypisuje je po kolei do kolejnych slotow w inventory metoda AddItem ze skryptu InventorySlot
    // jesli mam wiecej slotow niz itemek wtedy pozostale sloty czyszcze
    public void UpdateUI()
    {
        moneyText.text = inventory.PlayerGold.ToString() + "$";

        InventorySlot[] itemSlot = itemSlotParent.GetComponentsInChildren<InventorySlot>();

        InventorySlot[] equipmentSlot = equipmentSlotParent.GetComponentsInChildren<InventorySlot>();

        for (int i = 0; i < itemSlot.Length; i++)
        {
            if (i < inventory.items.Count)
            {
                itemSlot[i].AddItem(inventory.items[i]);
            }
            else
            {
                itemSlot[i].ClearSlot();
            }
        }

        //Udalo sie poniewaz buttony sa ulozone w tej samej kolejnosci co EqSlots enum - do naprawy.
        for (int i = 0; i < equipmentSlot.Length; i++)
        {
            if (equipmentManager.currentEquipment[i] != null)
            {
                equipmentSlot[i].AddItem(equipmentManager.currentEquipment[i]);
            }
            else
            {
                equipmentSlot[i].ClearSlot();
            }
        }

    }
}
