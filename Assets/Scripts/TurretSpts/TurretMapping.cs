using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TurretMapping : MonoBehaviour
{
    public static Image Icon;
    public List<GameObject> Bloom;
    public Transform HeadX;
    public Transform HeadY;
    public ShootBehaviour shootBehavior;

    [SerializeField] private Image icon;
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
        if (Icon == null)
        {
            Icon = icon;
        }

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
