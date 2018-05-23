using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(EnemyLootBag))]
public class Enemy : MonoBehaviour {


    CharacterStats stats;
    PlayerStats playerStats;

    EnemyLootBag loot;

	void Start () {
        stats = GetComponent<CharacterStats>();
        playerStats = Player.instance.playerStats;

        stats.OnHealthReachedZero += Die;

        loot = GetComponent<EnemyLootBag>();
	}

    


    void Die()
    {
        playerStats.PlayerLvlUpSystem(stats.EXP);

        loot.Drop();

        Destroy(gameObject);
        
    }
}

