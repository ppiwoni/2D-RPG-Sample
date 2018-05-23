using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterControl : MonoBehaviour {

    [HideInInspector]
    public bool moving;
    [HideInInspector]
    public float faceDirection;

    protected float attackCountdown = 0f;
   
	
	// Update is called once per frame
	protected virtual void Update ()
    {
            attackCountdown -= Time.deltaTime;

    }
}
