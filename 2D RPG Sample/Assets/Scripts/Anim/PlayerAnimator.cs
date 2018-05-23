using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimator : CharacterAnimator {

    int attackIndex;

    protected override void Start()
    {
        base.Start();
    }

    protected override void Update()
    {
        base.Update();

    }

    protected override void OnAttack()
    {
            
        Equipment currentWeapon = EquipmentManager.instance.currentEquipment[3];
        
        if (currentWeapon != null)
        {
            if (currentWeapon.weaponType == WeaponType.Axe)
            {
                attackIndex = 1;
            }
            else if (currentWeapon.weaponType == WeaponType.Bow)
            {
                attackIndex = 2;
            }
            else if (currentWeapon.weaponType == WeaponType.Staff)
            {
                attackIndex = 3;
            }

        }
        else
        {
            attackIndex = 0;
        }
        animator.SetFloat("AttackIndex", attackIndex);
        animator.SetTrigger("Attack");
        
    }

    protected override void OnMove()
    {
        base.OnMove();
    }
}
