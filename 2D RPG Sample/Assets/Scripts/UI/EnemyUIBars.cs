using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class EnemyUIBars : MonoBehaviour {


    public Slider hpBar;
     Transform target;
     CharacterStats stats;


    public void Init(Transform target, CharacterStats stats)
    {
        this.target = target;
        this.stats = stats;

      
      
    }

   void LateUpdate()
    {
        if (target == null)
        {
            Destroy(gameObject);
            return;
        }

        transform.position = target.position;

        float hpPercent = GetHpPercent();
        hpBar.value = hpPercent;
       


    }

    float GetHpPercent()
    {
        return Mathf.Clamp01(stats.CurrentHP / (float)stats.CalculateMaxHP());
    }
}
