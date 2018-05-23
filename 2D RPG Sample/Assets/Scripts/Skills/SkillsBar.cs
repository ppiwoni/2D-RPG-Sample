using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillsBar : MonoBehaviour {

    #region Singleton

    public static SkillsBar instance;

    private void Awake()
    {
        instance = this;
    }

    #endregion

    public CharacterAttacks playerAttacks;
    
    public SkillBarSlot[] skillBarSlot;

    public bool SkillBarState { get; protected set ; }

    private void Start()
    {
        SkillBarState = true;
        transform.localScale = new Vector2(System.Convert.ToInt32(SkillBarState), System.Convert.ToInt32(SkillBarState));
        skillBarSlot = GetComponentsInChildren<SkillBarSlot>();

    }

    public void SkillsBarButton()
    {
        SkillBarState = !SkillBarState;
        transform.localScale = new Vector2(System.Convert.ToInt32(SkillBarState), System.Convert.ToInt32(SkillBarState));
        
    }  

    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            SkillBarSlot slot = skillBarSlot[0];

            if (slot.GetComponentInChildren<Button>().interactable == true)
            {
                playerAttacks.Invoke(slot.Use(), 0);
                StartCoroutine(slot.Countdown());
            }

        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            SkillBarSlot slot = skillBarSlot[1];

            if (slot.GetComponentInChildren<Button>().interactable == true)
            {
                playerAttacks.Invoke(slot.Use(), 0);
                StartCoroutine(slot.Countdown());
            }

        }

        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            SkillBarSlot slot = skillBarSlot[2];

            if (slot.GetComponentInChildren<Button>().interactable == true)
            {
                playerAttacks.Invoke(slot.Use(), 0);
                StartCoroutine(slot.Countdown());
            }
         
        }

        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            SkillBarSlot slot = skillBarSlot[3];

            if (slot.GetComponentInChildren<Button>().interactable == true)
            {
                playerAttacks.Invoke(slot.Use(), 0);
                StartCoroutine(slot.Countdown());
            }
   
        }

        if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            SkillBarSlot slot = skillBarSlot[4];

            if (slot.GetComponentInChildren<Button>().interactable == true)
            {
                playerAttacks.Invoke(slot.Use(), 0);
                StartCoroutine(slot.Countdown());
            }
           
        }
        if (Input.GetKeyDown(KeyCode.Alpha6))
        {
            SkillBarSlot slot = skillBarSlot[5];

            if (slot.GetComponentInChildren<Button>().interactable == true)
            {
                playerAttacks.Invoke(slot.Use(), 0);
                StartCoroutine(slot.Countdown());
            }
            
        }
        if (Input.GetKeyDown(KeyCode.Alpha7))
        {
            SkillBarSlot slot = skillBarSlot[6];

            if (slot.GetComponentInChildren<Button>().interactable == true)
            {
                playerAttacks.Invoke(slot.Use(), 0);
                StartCoroutine(slot.Countdown());
            }
         
        }
        if (Input.GetKeyDown(KeyCode.Alpha8))
        {
            SkillBarSlot slot = skillBarSlot[7];

            if (slot.GetComponentInChildren<Button>().interactable == true)
            {
                playerAttacks.Invoke(slot.Use(), 0);
                StartCoroutine(slot.Countdown());
            }
           
        }
        if (Input.GetKeyDown(KeyCode.Alpha9))
        {
            SkillBarSlot slot = skillBarSlot[8];

            if (slot.GetComponentInChildren<Button>().interactable == true)
            {
                playerAttacks.Invoke(slot.Use(), 0);
                StartCoroutine(slot.Countdown());
            }
          
        }
        if (Input.GetKeyDown(KeyCode.Alpha0))
        {
            SkillBarSlot slot = skillBarSlot[9];

            if (slot.GetComponentInChildren<Button>().interactable == true)
            {
                playerAttacks.Invoke(slot.Use(), 0);
                StartCoroutine(slot.Countdown());
            }
      
        }

    }

    
    public void AddSkill(Sprite newSprite, string skill)
    {
        for (int i = 0; i < skillBarSlot.Length; i++)
        {

            if (skillBarSlot[i].Skill == skill)
            {
                return;

            }
            else if (skillBarSlot[i].icon.enabled == false)
            {
                for (int j = i + 1; j < skillBarSlot.Length; j++)
                {
                    if (skillBarSlot[j].Skill == skill)
                    {
                        skillBarSlot[j].Clear();

                    }
                }
                skillBarSlot[i].Add(newSprite, skill);
                return;

            }
            else
            {
                Debug.Log("No free slot");
            };

        }
    }


}
