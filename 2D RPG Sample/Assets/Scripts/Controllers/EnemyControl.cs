using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterCombat), typeof(CharacterStats))]
public class EnemyControl : CharacterControl {

    Transform target;
    CharacterCombat combat;
    CharacterStats characterStats;
    CharacterAttacks spells;
    public float lookRadius = 5f;
    public float attackDistance;

    Vector2 startPos;

    public EnemyType enemyType;

    private void Start()
    {
        spells = GetComponent<CharacterAttacks>();

        if (enemyType.ToString() == "flying")
        {
            moving = true;
        }
        
        target = Player.instance.transform;

        combat = GetComponent<CharacterCombat>();
        characterStats = GetComponent<CharacterStats>();

        startPos = transform.position;
    }

    protected override void Update()
    {
       
        base.Update();
        
    }

    private void FixedUpdate()
    {
    
        float distance = Vector2.Distance(target.position, transform.position);

        if (distance <= lookRadius)
        {

            moving = true;
            faceDirection = Mathf.Sign(target.position.x - transform.position.x);

            transform.localScale = new Vector2(faceDirection, transform.localScale.y);
            transform.position = Vector2.MoveTowards(transform.position, target.position, characterStats.CurrentMOV_SPD * Time.deltaTime);

            if (distance <= attackDistance && attackCountdown <= 0)
            {

                //odpalamy metode o nazwie takiej samej jak nazwa prefabu na miejscu w tablicy spellPrefab

                if (spells.spellPrefabs.Length == 2 && Random.Range(1, 10) > 7)
                {
                    spells.Invoke(spells.spellPrefabs[1].name, 0);
                }
                else
                {
                    spells.Invoke(spells.spellPrefabs[0].name, 0);
                }

                attackCountdown = 10f / characterStats.CurrentATT_SPD;

            }

        }
        else if(new Vector2(transform.position.x, transform.position.y) != startPos)
        {
            faceDirection = Mathf.Sign(startPos.x - transform.position.x);
            transform.localScale = new Vector2(faceDirection, transform.localScale.y);
            transform.position = Vector2.MoveTowards(transform.position, startPos, characterStats.CurrentMOV_SPD * Time.deltaTime);

            if (enemyType.ToString() == "walking" && new Vector2(transform.position.x, transform.position.y) == startPos)
            {
                moving = false;
            }
        }
        
    }


    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, lookRadius );
    }


   public enum EnemyType {walking, flying }
}
