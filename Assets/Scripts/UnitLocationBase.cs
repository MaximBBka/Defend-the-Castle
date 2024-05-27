using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitLocationBase : Unit
{
    public override void TakeDamage(float damage)
    {
        base.TakeDamage(damage);
        MainUI.Instance.HealthBase.SetText(stats.Health.ToString());
    }
}
