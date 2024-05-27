using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitEnemy : Unit
{
    public override void Find()
    {
        base.Find();
        Collider[] colliders = CheckObstacle.Check(aim);
        for (int i = 0; i < colliders.Length; i++)
        {
            if (colliders[i].TryGetComponent<Unit>(out Unit unit))
            {
                animator.SetBool("IsWalk", false);
                animator.SetBool("IsAttack", false);
                UnitHero hero = unit as UnitHero;
                UnitLocationBase baseLocation = unit as UnitLocationBase;
                if (hero != null || baseLocation != null)
                {
                    animator.SetBool("IsAttack", true);
                    if (coroutine == null)
                    {
                        coroutine = StartCoroutine(DelayAttack(hero != null ? hero : baseLocation));
                    }
                }
                return;
            }

        }
        Move();
    }
}
