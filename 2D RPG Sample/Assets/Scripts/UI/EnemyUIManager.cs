using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyUIManager : MonoBehaviour {
   
    public EnemyUIBars barPrefab;
    public static EnemyUIManager instance;
	// Use this for initialization
	void Awake () {
        instance = this;
	}

    public void Create(Transform target, CharacterStats stats)
    {
        EnemyUIBars newHpUI = Instantiate(barPrefab, transform) as EnemyUIBars;   
        newHpUI.Init(target, stats);
    }
}
