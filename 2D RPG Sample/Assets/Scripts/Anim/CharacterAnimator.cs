using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAnimator : MonoBehaviour {

    public Animator animator;
    protected CharacterCombat combat;
    protected CharacterControl controller;


    protected virtual void Start () {

        combat = GetComponent<CharacterCombat>();
        controller = GetComponent<CharacterControl>();
     
        combat.OnAttack += OnAttack;
    }
	
	
	protected virtual void Update () {

        OnMove();
        
    }

    protected virtual void OnAttack()
    {
       
    }



    //controller.faceDirection - zbedny - do poprawy -> transform.localScale.x -
    protected virtual void OnMove()
    {
        animator.SetBool("Moving", controller.moving); //Przesylam stan ruchu bohatera

        if (controller.moving)
        {
            animator.SetFloat("Walk", controller.faceDirection);
        }

    }
}
