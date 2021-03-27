using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrjectileTurret : TurretSpt
{   
    void Start()
    {
        Init();        
    }
    protected override void Shoot()
    {
        base.Shoot();
        ProjectileEvents.OnProjectileLauncherFired.Invoke(this);
    }
}
