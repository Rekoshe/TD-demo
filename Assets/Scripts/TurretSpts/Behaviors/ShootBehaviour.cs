using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ShootBehaviour : MonoBehaviour
{
    [SerializeField] protected ParticleSystem muzzleFlash;
    public abstract void Shoot(Enemy enemy);
}
