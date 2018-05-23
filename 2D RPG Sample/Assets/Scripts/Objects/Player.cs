using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour {

    #region Singleton

    public static Player instance;

    void Awake()
    {
        instance = this;
    }

    #endregion

    public PlayerStats playerStats;

    // Use this for initialization
    void Start () {

        playerStats.OnHealthReachedZero += Die;
	}

    void Die()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

    }
}
