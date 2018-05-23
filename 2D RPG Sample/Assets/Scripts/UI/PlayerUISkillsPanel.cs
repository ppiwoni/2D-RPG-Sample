using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerUISkillsPanel : MonoBehaviour {

    PlayerStats stats;

    public Text playerSkillPoints;

	void Start ()
    {

        stats = Player.instance.playerStats;

	}

    private void Update()
    {
        if (stats != null)
        {
            playerSkillPoints.text = "Skill Points: " + stats.skillPoints.ToString();
        }

    }

}
