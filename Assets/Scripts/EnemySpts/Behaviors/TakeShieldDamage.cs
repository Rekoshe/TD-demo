using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeShieldDamage : ITakeDamageBehavior
{
    int _shield;
    public TakeShieldDamage(int shield)
    {
        _shield = shield;
    }
    public void TakeDamage(int damage)
    {
        throw new System.NotImplementedException();
    }
}
