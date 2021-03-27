using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretMapping : MonoBehaviour
{
    public List<GameObject> Bloom;
    public Transform HeadX;
    public Transform HeadY;
    public ShootBehaviour shootBehavior;
    public float TimeBetweenShots { get { return _timeBetweenShots; }
        set
        {
            MainTrtShoot mainTrtShoot = shootBehavior as MainTrtShoot;
            if (mainTrtShoot != null)
            {
                mainTrtShoot.animator.SetFloat("speed", 1 / value);
                _timeBetweenShots = value;
            }
        }
    }

    
    [SerializeField] private float _timeBetweenShots;

    // Start is called before the first frame update
    void Start()
    {
        

        if (Bloom.Count == 0)
        {
            throw new System.Exception("bloom is not assigned for this turret");
        }
        if (HeadX == null || HeadY == null)
        {
            throw new System.Exception("No head is assigned for this turret");
        }
    }

    
}
