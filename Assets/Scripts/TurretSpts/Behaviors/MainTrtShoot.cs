using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class MainTrtShoot : ShootBehaviour
{
    public Animator animator;

    public override void Shoot(Enemy enemy)
    {
        if (animator != null)
        {
            animator.SetTrigger("shoot");
        }
        
        if (muzzleFlash != null)
        {
            muzzleFlash.Play();
        }
        
    }
}
