using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitHero : Unit
{
    private bool isBreak;
    public override void Find()
    {
        base.Find();
        isBreak = false;
        Collider[] colliders = CheckObstacle.Check(aim);
        for (int i = 0; i < colliders.Length; i++)
        {
            if (colliders[i].TryGetComponent<Unit>(out Unit unit))
            {
                UnitLocationBase locationBase = unit as UnitLocationBase;
                if ( locationBase != null)
                {
                    continue;
                }
                animator.SetBool("IsAttack", false);
                animator.SetBool("IsWalk", false);
                UnitEnemy enemy = unit as UnitEnemy;
                if (enemy != null) 
                {
                    animator.SetBool("IsAttack", true);
                    if (coroutine == null)
                    {
                        coroutine = StartCoroutine(DelayAttack(enemy));
                    }
                }
                return;
            }
            if (colliders[i].TryGetComponent<StopUnit>(out StopUnit stop))
            {
                animator.SetBool("IsAttack", false);
                animator.SetBool("IsWalk", false);
                isBreak = true;
            }
        }
        if (isBreak)
        {
            return;
        }
        Move();
    }
}