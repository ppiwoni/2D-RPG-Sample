using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillPanelSlot : MonoBehaviour {

    PlayerStats stats;
    Sprite imageSprite;

    public Skill mySkill;

    public Button addButton, skillButton;

    private void Start()
    {
        stats = Player.instance.playerStats;
        imageSprite = skillButton.GetComponent<Image>().sprite;

        
    }

    public void ActiveSkill()
    {
        if (stats.skillPoints > 0)
        {
            skillButton.interactable = true;
            addButton.interactable = false;
            stats.skillPoints--;
            

        }
    }

    public void SendSkill()
    {
        SkillsBar.instance.AddSkill(imageSprite, mySkill.ToString());
       
    }

  public enum Skill { Sword4, Arrow1, Special12 };
  
}

