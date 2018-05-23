using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLootBag : MonoBehaviour {

    [System.Serializable]
    public struct LootBag
    {
        public GameObject interactableObject;

        [Range(1, 100)]
        public int weight;

    }

    public int goldMinAmount, goldMaxAmount;

    public List<LootBag> lootBag;

    public void Drop()
    {
        if (lootBag.Count > 0)
        {
            foreach (var item in lootBag)
            {
                if (Random.Range(1, 100) <= item.weight)
                {
                    if (item.interactableObject.GetComponent<GoldReceive>() != null)
                    {
                        int amount = Random.Range(goldMinAmount, goldMaxAmount);
                        item.interactableObject.GetComponent<GoldReceive>().goldAmount = amount;
                        
                    }

                   Instantiate(item.interactableObject, transform.position, Quaternion.identity);
                  
                }
            }
        }
    }

}
