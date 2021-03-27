using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighFireRateTurret : TurretSpt
{

    LazerShoot lazerShoot;

    void Start()
    {
        Init();
        TimeBetweenShots = _timeBetweenShots;
    }
}
