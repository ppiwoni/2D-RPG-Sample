using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerUIBackpack : MonoBehaviour {

    public GameObject statusPanel, equipmentsPanel, skillsPanel, missionsPanel, settingsPanel;
    public List<GameObject> backpackOptions = new List<GameObject>();


    private void Awake()
    {
        backpackOptions.Add(statusPanel);
        backpackOptions.Add(equipmentsPanel);
        backpackOptions.Add(skillsPanel);
        backpackOptions.Add(missionsPanel);
        backpackOptions.Add(settingsPanel);

    }

   

    public void BackpackButton()
    {
       
        gameObject.SetActive(!gameObject.active);
        Time.timeScale = System.Convert.ToSingle(!gameObject.active);


    }

    private void OnEnable()
    {
        StatusButton();
        if (SkillsBar.instance.SkillBarState)
        {
            SkillsBar.instance.SkillsBarButton();
        }
    }

    private void OnDisable()
    {

        if (!SkillsBar.instance.SkillBarState)
        {
            SkillsBar.instance.SkillsBarButton();
        }
    }


    public void StatusButton()
    {
       
        foreach (var option in backpackOptions)
        {
            if (option == statusPanel)
            {
                option.SetActive(true);
            }
            else
            {
                option.SetActive(false);
            }
        }

    }

    public void EquipmentsButton()
    {
        
        foreach (var option in backpackOptions)
        {
            if (option == equipmentsPanel)
            {
                option.SetActive(true);
               
            }
            else
            {
                option.SetActive(false);
            }
        }

    }

    

    public void SkillsButton()
    {
        foreach (var option in backpackOptions)
        {
            if (option == skillsPanel)
            {
                option.SetActive(true);
            }
            else
            {
                option.SetActive(false);
            }
        }

    }

    public void MissionsButton()
    {
        foreach (var option in backpackOptions)
        {
            if (option == missionsPanel)
            {
                option.SetActive(true);
            }
            else
            {
                option.SetActive(false);
            }
        }

    }

    public void SettingssButton()
    {
        foreach (var option in backpackOptions)
        {
            if (option == settingsPanel)
            {
                option.SetActive(true);
            }
            else
            {
                option.SetActive(false);
            }
        }

    }




}
