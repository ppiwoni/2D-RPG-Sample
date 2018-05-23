using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterStats))]
public class CharacterCombat : MonoBehaviour {

    

   public Transform barPos;

   protected CharacterStats myStats;
   protected CharacterStats enemyStats;

   public event System.Action OnAttack;
  

    // Use this for initialization
    protected virtual void Start () {
        myStats = GetComponent<CharacterStats>();
        EnemyUIManager.instance.Create(barPos, myStats);
     
    }
	
	public void AttackEvent()
    {

        if (OnAttack != null)
        {
            OnAttack();
        }

    }


    public void Attack(CharacterStats enemyStats)
    {
   

        this.enemyStats = enemyStats;
            
        enemyStats.TakeDamage(myStats.CalculateCurrentDMG());

       

    }

   
}
