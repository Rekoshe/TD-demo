using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class OnLaunched : UnityEvent<Projectile>{}
public class OnRemovedWithNoTarget : UnityEvent<Projectile>{}
public class OnHitEnemy : UnityEvent<Projectile, Enemy>{}
public class OnProjectileLauncherFired : UnityEvent<TurretSpt> {}


public class ProjectileEvents : MonoBehaviour
{
    public static OnLaunched OnLaunched;
    public static OnRemovedWithNoTarget OnRemovedWithNoTarget;
    public static OnHitEnemy OnHitEnemy;
    public static OnProjectileLauncherFired OnProjectileLauncherFired;

    private void Start()
    {
        if (OnLaunched == null)
        {
            OnLaunched = new OnLaunched();
        }
        if (OnRemovedWithNoTarget == null)
        {
            OnRemovedWithNoTarget = new OnRemovedWithNoTarget();
        }
        if (OnHitEnemy == null)
        {
            OnHitEnemy = new OnHitEnemy();
        }
        if (OnProjectileLauncherFired == null)
        {
            OnProjectileLauncherFired = new OnProjectileLauncherFired();
        }

        OnLaunched.AddListener(Launched);
        OnRemovedWithNoTarget.AddListener(Removed);
        OnHitEnemy.AddListener(HitEnemy);
        OnProjectileLauncherFired.AddListener(LaunchedProjectile);

    }

    public void Launched(Projectile proj)
    {

        /* Add what happens here
         * when the Missile Gets
         * Launched */

        
    }

    public void Removed(Projectile proj)
    {


        /* Add what happens here
        * when the Missile Gets
        * Removed mid air cuz it's
        * target died */

    }

    public void HitEnemy(Projectile proj, Enemy enemy)
    {

        Instantiate(proj.Exprosion, proj.transform.position, Quaternion.identity);
        

        /* Add what happens here
        * when the Missile Successfully
        * hits and deals damage to it's
        * target */


    }
    public void LaunchedProjectile(TurretSpt launcher)
    {
        //*******************//

    }

    /*
     * P.S: the Methods here will only work for the frame that 
     * the event was triggered in, DO NOT try storing the 
     * References and using them in a following frame
     * it will most likely cause a null reference exception
     */
}
