using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Projectile : MonoBehaviour
{
    Enemy target;
    protected MeshRenderer rendererr;
    internal float ProjectileSpeed = 1;
    private float _activationDistance = 0.1f;
    public int Damage;
    private float _hopsPerFrame;
    private float _hopDistance = 0.1f;


    //private float _distanceFromTarget;
    [SerializeField] protected float _speed = 100;
    [SerializeField] protected ParticleSystem SmokeParticleSystem;
    [SerializeField] protected ParticleSystem FireParticleSystem;
    public GameObject Exprosion;
    
    private bool Exploded = false;

    public void RemoveProjectile()
    {
        
        if (!SmokeParticleSystem.IsAlive())
        {
            
            Destroy(gameObject);
        }   
    }

    
    private float DistanceFromTarget()
    {
        return Vector3.Distance(target.transform.position, transform.position);
    }
    public void SetTarget(Enemy enemy)
    {
        target = enemy;
    }
    public void Move()
    {
        if (!Exploded)
        {
            if (target != null)
            {
                CalculateMovement();
            }
            else
            {
                ProjectileEvents.OnRemovedWithNoTarget.Invoke(this);
                Explod();
                Exploded = true;
            }
        }
        else
        {
            Explod();
        }
        
        
    }

    private void Explod()
    {

        FireParticleSystem.Stop();
        rendererr.enabled = false;
        RemoveProjectile();
    }

    protected virtual void CalculateMovement()
    {
        _hopsPerFrame = 1 + (Time.deltaTime * _speed);

        transform.LookAt(target.transform.position);

        //basically the faster the object moves the more checks per frame we do for collision detection
        CollisionDetection();
    }
    
    protected virtual void CollisionDetection()
    {
        for (int i = 0; i < _hopsPerFrame; i++)
        {

            if (DistanceFromTarget() > _activationDistance)
            {
                Vector3 trajictory = target.transform.position - transform.position;
                trajictory.Normalize();

                transform.Translate(trajictory * _hopDistance, Space.World);
            }
            else
            {
                EnemyMoveSpt.GiveDamage(target, Damage);
                ProjectileEvents.OnHitEnemy.Invoke(this, target);
                Exploded = true;
                break;
            }
        }
    }
    private void Update()
    {
        Move();
    }

}
