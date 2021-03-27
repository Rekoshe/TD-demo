using UnityEngine;
using System.Collections.Generic;



public class RLprojSpawn : ShootBehaviour
{
    [SerializeField] private List<Transform> silos;
    [SerializeField] private float projectileSpeed;
    [SerializeField] private Projectile projectile;
    public int Damage;
    public override void Shoot(Enemy enemy)
    {
        SpawnProjectile(enemy);
    }

    public void SpawnProjectile(Enemy target)
    {
        Projectile thisproj = Instantiate(projectile);
        int random = Random.Range(0, silos.Count);
        thisproj.transform.position = silos[random].transform.position;
        thisproj.transform.rotation = silos[random].rotation;
        thisproj.Damage += Damage;
        thisproj.SetTarget(target);
        //TurretModel.Projectiles.Add(thisproj);
        ProjectileEvents.OnLaunched.Invoke(thisproj);
    }
}

