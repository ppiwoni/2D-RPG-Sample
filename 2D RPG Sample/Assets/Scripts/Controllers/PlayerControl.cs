using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerCombat),typeof(PlayerStats))]
public class PlayerControl : CharacterControl {
 
    float horizontalMoving, verticalMoving;

    PlayerCombat combat;
    PlayerStats playerStats;

    public List<GameObject> interactableObj;

    void Start ()
    {
        combat = GetComponent<PlayerCombat>();
        playerStats = GetComponent<PlayerStats>();
   
        
	}

     protected override void Update()
     {
        
        base.Update();

        if (Input.GetKeyDown(KeyCode.E) && interactableObj.Count > 0)
        {

            interactableObj[0].GetComponent<Interactable>().Interact();

        }

     }

    private void OnTriggerEnter2D(Collider2D collision)
    {
       
        if(collision.CompareTag("Interactable") )
        {
            interactableObj.Add(collision.gameObject);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {

        if (collision.CompareTag("Interactable"))
        {
            interactableObj.Remove(collision.gameObject);
        }
    }

    void FixedUpdate () {

        
   
        horizontalMoving = Input.GetAxisRaw("Horizontal");
        verticalMoving = Input.GetAxisRaw("Vertical");

        

        if (horizontalMoving != 0 || verticalMoving != 0)
        {

            moving = true;

               if (horizontalMoving != 0)
               {
                 transform.Translate(horizontalMoving * playerStats.CurrentMOV_SPD * Time.deltaTime, 0f, 0f);
                 transform.localScale = new Vector2(horizontalMoving, transform.localScale.y);
                 faceDirection = horizontalMoving;
               }


               if (verticalMoving != 0)
               {
                 transform.Translate(0f, verticalMoving * playerStats.CurrentMOV_SPD * Time.deltaTime, 0f);

               }

        }
        else
        {
                     moving = false;
        }


        if (Input.GetKey(KeyCode.LeftControl) && attackCountdown <= 0)
        {

            combat.AttackEvent();
            attackCountdown = 10f / playerStats.CurrentATT_SPD;

        }


        
    }



}
