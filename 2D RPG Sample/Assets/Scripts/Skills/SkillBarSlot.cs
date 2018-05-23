using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillBarSlot : MonoBehaviour {

    public Image icon;
    public string Skill { get; protected set; }
    Button button;


    private void Start()
    {
        button = GetComponentInChildren<Button>();
    }

    public void Add(Sprite newSprite, string skill)
    {
        Skill = skill;
        icon.sprite = newSprite;
        icon.enabled = true;


    }

    public void Clear()
    {

        icon.sprite = null;
        icon.enabled = false;
        Skill = null;

    }


    public string Use()
    {
        return Skill;
    }


    public IEnumerator Countdown()
    {
        button.interactable = false;
        yield return new WaitForSeconds(3f);
        button.interactable = true;
    }

}
