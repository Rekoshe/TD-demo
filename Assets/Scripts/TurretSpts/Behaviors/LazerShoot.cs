using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LazerShoot : ShootBehaviour
{
    public GameObject LazerBeam;
    private float _distance;

    public override void Shoot(Enemy enemy)
    {
        if (enemy != null)
        {
            LazerBeam.SetActive(true);

            _distance = Vector3.Distance(enemy.transform.position, LazerBeam.transform.position);
            LazerBeam.transform.localScale =
                new Vector3(LazerBeam.transform.localScale.x, LazerBeam.transform.localScale.y,
                _distance);
        }
        else
        {
            LazerBeam.SetActive(false);
        }
    }
}
