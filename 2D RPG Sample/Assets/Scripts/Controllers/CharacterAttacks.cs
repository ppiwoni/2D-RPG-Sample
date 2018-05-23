using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CharacterAttacks : MonoBehaviour {

    CharacterCombat combat;
    CharacterControl controller;

    string opponentTag;

    int spCost;
    static bool penetrating;
    static bool weaponAttack;

    static int minSpellDamage, maxSpellDamage;
   
    int spellDamage;

    static GameObject objectParent;
 
    public GameObject[] spellPrefabs;
    public int spellNumber;
    
    public GameObject summon;
    public int summonSkillNumber;


    private void Start()
    {
        // mozna zmienic na enum
        if (gameObject.tag == "Player")
        {
            opponentTag = "Enemy";
        }
        else
        {
            opponentTag = "Player";
        }

        combat = GetComponent<CharacterCombat>();
        controller = GetComponent<CharacterControl>();

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
      
        if (collision.tag == opponentTag && objectParent != null)
        {
            if (weaponAttack)
            {
                CharacterStats myStats = transform.GetComponent<CharacterStats>();
                objectParent.GetComponent<CharacterCombat>().Attack(myStats); 
            }
            else
            {
                spellDamage = Random.Range(minSpellDamage,maxSpellDamage);
                GetComponent<CharacterStats>().TakeDamage(spellDamage);
            }

            if (penetrating == false)
            {
                collision.GetComponent<Collider2D>().enabled = false;
            }
            
        }
    }


    void FistAttack()
    {
        weaponAttack = true;
        GetComponent<AudioSource>().Play();
        RaycastHit2D[] hits = Physics2D.BoxCastAll(transform.position, new Vector2(1, 1), 0f, new Vector2(controller.faceDirection, 0f), 0.5f);
       
        for (int i = 0; i < hits.Length; i++)
        {
            RaycastHit2D hit = hits[i];

            if (hit.collider.tag == opponentTag)
            {
                CharacterStats enemyStats = hit.transform.GetComponent<CharacterStats>();

               
               if(enemyStats != null)
                combat.Attack(enemyStats);

            }

        }

    }




  public void Sword1()
    {
        weaponAttack = true;
        penetrating = false;

        for (int i = 0; i < spellPrefabs.Length; i++)
        {
            if (spellPrefabs[i].name == "Sword1")
            {
                var sword1 = Instantiate(spellPrefabs[i], new Vector2(transform.position.x + (1 * transform.localScale.x),
                transform.position.y), Quaternion.identity, transform);

                sword1.gameObject.tag = gameObject.tag;

                sword1.GetComponent<Animator>().SetFloat("SpellIndex", 3);
                sword1.GetComponent<Animator>().SetTrigger("Spell");

                objectParent = sword1.transform.parent.gameObject;
                sword1.transform.parent = null;

                Destroy(sword1, 1f);

               
            }
        }



    }

    public void Sword4()
    {
        Equipment currentWeapon = EquipmentManager.instance.currentEquipment[3];

        weaponAttack = false;
        penetrating = false;

        minSpellDamage = 30;
        maxSpellDamage = 40;

        spCost = 20;
        if (gameObject.tag == "Player" && Player.instance.playerStats.CurrentSP >= spCost 
            && currentWeapon != null && currentWeapon.weaponType == WeaponType.Axe)
        {

            Player.instance.playerStats.SpEater(spCost);
        }
        else if (gameObject.tag == "Player")
        {
            return;
        }

        for (int i = 0; i < spellPrefabs.Length; i++)
        {
            if (spellPrefabs[i].name == "Sword4")
            {
                var sword4 = Instantiate(spellPrefabs[i], new Vector2(transform.position.x + (1 * transform.localScale.x),
                transform.position.y), Quaternion.identity, transform);

                sword4.gameObject.tag = gameObject.tag;

                sword4.GetComponent<Animator>().SetFloat("SpellIndex", 4);
                sword4.GetComponent<Animator>().SetTrigger("Spell");

                objectParent = sword4.transform.parent.gameObject;
                sword4.transform.parent = null;

                Destroy(sword4, 1f);

              
            }
        }
    }

    public void Arrow()
    {
        weaponAttack = true;
        penetrating = true;

        for (int i = 0; i < spellPrefabs.Length; i++)
        {
            if (spellPrefabs[i].name == "Arrow")
            {
                var arrow = Instantiate(spellPrefabs[i], transform.position, Quaternion.identity, transform);

                arrow.GetComponent<Rigidbody2D>().velocity = new Vector2(10 * transform.localScale.x, 0);
                arrow.gameObject.tag = gameObject.tag;


                objectParent = arrow.transform.parent.gameObject;
                arrow.transform.parent = null;

                Destroy(arrow, 0.5f);
            }
        }
    }

   public void Arrow1()
    {
        Equipment currentWeapon = EquipmentManager.instance.currentEquipment[3];

        weaponAttack = false;
        penetrating = true;

        minSpellDamage = 20;
        maxSpellDamage = 50;

        spCost = 30;
        if (gameObject.tag == "Player" && Player.instance.playerStats.CurrentSP >= spCost
             && currentWeapon != null && currentWeapon.weaponType == WeaponType.Bow)
        {
            Player.instance.playerStats.SpEater(spCost);
        }
        else if (gameObject.tag == "Player")
        {
            return;
        }

        for (int i = 0; i < spellPrefabs.Length; i++)
        {
            if (spellPrefabs[i].name == "Arrow1")
            {
                var arrow1 = Instantiate(spellPrefabs[i], new Vector2(transform.position.x + (2 * transform.localScale.x),
               transform.position.y), Quaternion.identity, transform);

                arrow1.GetComponent<Rigidbody2D>().velocity = new Vector2(10 * transform.localScale.x, 0);
                arrow1.gameObject.tag = gameObject.tag;

                arrow1.GetComponent<Animator>().SetFloat("SpellIndex", 0);
                arrow1.GetComponent<Animator>().SetTrigger("Spell");

                objectParent = arrow1.transform.parent.gameObject;
                arrow1.transform.parent = null;

                Destroy(arrow1, 0.75f);

               
            }
        }
    }

    public void Fire()
    {
        weaponAttack = true;
        penetrating = true;

        spCost = 5;
        if (gameObject.tag == "Player" && Player.instance.playerStats.CurrentSP >= spCost)
        {
            Player.instance.playerStats.SpEater(spCost);
        }
        else if(gameObject.tag == "Player")
        {
            return;
        }

        for (int i = 0; i < spellPrefabs.Length; i++)
        {
            if (spellPrefabs[i].name == "Fire")
            {
                var fire = Instantiate(spellPrefabs[i], transform.position, Quaternion.identity, transform);

                fire.GetComponent<Rigidbody2D>().velocity = new Vector2(10 * transform.localScale.x, 0);
                fire.gameObject.tag = gameObject.tag;

                fire.GetComponent<Animator>().SetFloat("SpellIndex", 1);
                fire.GetComponent<Animator>().SetTrigger("Spell");

                objectParent = fire.transform.parent.gameObject;
                fire.transform.parent = null;

                Destroy(fire, 0.5f);

                
            }
        }
    }

    public void Special12()
    {
        Equipment currentWeapon = EquipmentManager.instance.currentEquipment[3];

        weaponAttack = false;
        penetrating = true;

        minSpellDamage = 20;
        maxSpellDamage = 60;

        spCost = 50;
        if (gameObject.tag == "Player" && Player.instance.playerStats.CurrentSP >= spCost
             && currentWeapon != null && currentWeapon.weaponType == WeaponType.Staff)
        {
            Player.instance.playerStats.SpEater(spCost);
        }
        else if (gameObject.tag == "Player")
        {
            return;
        }

        for (int i = 0; i < spellPrefabs.Length; i++)
        {
            if (spellPrefabs[i].name == "Special12")
            {

                var special12 = Instantiate(spellPrefabs[i], new Vector2(transform.position.x,
                transform.position.y + 1), Quaternion.identity, transform);

                special12.GetComponent<Rigidbody2D>().velocity = new Vector2(10 * transform.localScale.x, 0);
                special12.gameObject.tag = gameObject.tag;

                special12.GetComponent<Animator>().SetFloat("SpellIndex", 2);
                special12.GetComponent<Animator>().SetTrigger("Spell");

                objectParent = special12.transform.parent.gameObject;
                special12.transform.parent = null;

                Destroy(special12, 1f);

                
            }
        }

    }

    public void Special7()
    {

        weaponAttack = true;
        for (int i = 0; i < spellPrefabs.Length; i++)
        {
            if (spellPrefabs[i].name == "Special7")
            {
                
                var special7 = Instantiate(spellPrefabs[i], new Vector2(transform.position.x,
                transform.position.y +1.2f), Quaternion.identity, transform);

                var summonChild = Instantiate(summon, new Vector2(transform.position.x,
                  transform.position.y + 1.2f), Quaternion.identity);

                special7.gameObject.tag = gameObject.tag;

                special7.GetComponent<Animator>().SetFloat("SpellIndex", 9);
                special7.GetComponent<Animator>().SetTrigger("Spell");

                objectParent = special7.transform.parent.gameObject;
                special7.transform.parent = null;

               

                Destroy(special7, 1f);

            }
        }
    }

    //jak na ten moment tylko dla enemy
    public void Special14()
    {
        weaponAttack = true;
        penetrating = false;

        for (int i = 0; i < spellPrefabs.Length; i++)
        {
            if (spellPrefabs[i].name == "Special14")
            {
     
                var special14 = Instantiate(spellPrefabs[i], Player.instance.transform.position, 
                    Quaternion.identity, transform);

                special14.gameObject.tag = gameObject.tag;

                special14.GetComponent<Animator>().SetFloat("SpellIndex", 7);
                special14.GetComponent<Animator>().SetTrigger("Spell");

                objectParent = special14.transform.parent.gameObject;
                special14.transform.parent = null;

                Destroy(special14, 1f);


            }
        }

    }


    public void Slash2()
    {
        weaponAttack = true;
        penetrating = false;

        for (int i = 0; i < spellPrefabs.Length; i++)
        {
            if (spellPrefabs[i].name == "Slash2")
            {
                var slash2 = Instantiate(spellPrefabs[i], new Vector2(transform.position.x + (0.75f * transform.localScale.x),
                transform.position.y), Quaternion.identity, transform);

                slash2.gameObject.tag = gameObject.tag;

                slash2.GetComponent<Animator>().SetFloat("SpellIndex", 5);
                slash2.GetComponent<Animator>().SetTrigger("Spell");

                objectParent = slash2.transform.parent.gameObject;
                slash2.transform.parent = null;

                Destroy(slash2, 1f);

            }
        }
    }

    public void Blow1()
    {
        weaponAttack = true;
        penetrating = false;

        for (int i = 0; i < spellPrefabs.Length; i++)
        {
            if (spellPrefabs[i].name == "Blow1")
            {
                
                var blow1 = Instantiate(spellPrefabs[i], new Vector2(transform.position.x + (0.5f * transform.localScale.x),
                transform.position.y), Quaternion.identity, transform);

                blow1.gameObject.tag = gameObject.tag;

                blow1.GetComponent<Animator>().SetFloat("SpellIndex", 6);
                blow1.GetComponent<Animator>().SetTrigger("Spell");

                objectParent = blow1.transform.parent.gameObject;
                blow1.transform.parent = null;

                Destroy(blow1, 1f);

            }
        }
    }


    public void Melee1()
    {
        weaponAttack = true;
        penetrating = false;

        for (int i = 0; i < spellPrefabs.Length; i++)
        {
            if (spellPrefabs[i].name == "Melee1")
            {
                var melee1 = Instantiate(spellPrefabs[i], new Vector2(transform.position.x + (0.75f * transform.localScale.x),
                transform.position.y), Quaternion.identity, transform);

                melee1.gameObject.tag = gameObject.tag;

                melee1.GetComponent<Animator>().SetFloat("SpellIndex", 8);
                melee1.GetComponent<Animator>().SetTrigger("Spell");

                objectParent = melee1.transform.parent.gameObject;
                melee1.transform.parent = null;

                Destroy(melee1, 0.75f);

            }
        }
    }

    

}
