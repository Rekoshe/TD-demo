using Assets.Scripts.ModelScript.EventArgs;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class OnHasTarget : UnityEvent<string>
{

}

public abstract class TurretSpt : MonoBehaviour
{
    public static Image Icon;
    public bool Activated { get; set; }

    public OnHasTarget OnHasTarget;
    public float TimeBetweenShots { get { return _timeBetweenShots; }
        set { _currentTurretMappping.TimeBetweenShots = value; _timeBetweenShots = value;  } }

    [SerializeField] protected float _timeBetweenShots;
    [SerializeField] protected TargetOrder targetorder = TargetOrder.First;
    [SerializeField] protected List<TurretMapping> _forms;
    [SerializeField] protected int _damage;
    [SerializeField] protected Image icon;

    protected Enemy target;
    protected TriggerSpt triggerSpt;
    protected bool canShoot;    
    protected GameObject turretHead;
    protected Transform turretHeadX;
    protected Transform turretHeadY;
    protected List<GameObject> bloomStuff;

    public int UpgradePointer { get; private set; }

    protected ShootBehaviour shootBehaviour;
    protected GameObject _currentForm;
    protected TurretMapping _currentTurretMappping;

    private float _timer;

    
    public int Damage { get; set; }


    public enum TargetOrder
    {
        First,
        Last,
        Random
    }

    public virtual void UpgradeTurret()
    {
        if (UpgradePointer >= _forms.Count - 1)
        {
            throw new System.Exception("There are no more upgrades for this turret");
        }
        else
        {
            UpgradePointer += 1;            
            SetupTurretMappings(); 
        }  
    }

    protected virtual void Init()
    {
        if (Icon == null)
        {
            Icon = icon;
        }        
        EnemyModelSpt.ListChanged += RemoveEnemyFromTrigger;        
        _currentForm = _forms[0].gameObject;

        ChangeColor(TurretModel.chillColor);
        SetupTurretMappings();
    }


    protected void SetCurrentForm(GameObject newForm)
    {
        _currentForm.SetActive(false);
        _currentForm = newForm;
        _currentForm.SetActive(true);
    }
    private void AddToTimer()
    {
        if (_timer < _timeBetweenShots && !canShoot)
        {
            _timer += Time.deltaTime;
        }
        else
        {
            _timer = 0;
            canShoot = true;
        }

    }
    protected virtual void SetupTurretMappings()
    {
        SetCurrentForm(_forms[UpgradePointer].gameObject);
        
        _currentTurretMappping = _currentForm.GetComponent<TurretMapping>();
        triggerSpt = _currentTurretMappping.GetComponentInChildren<TriggerSpt>();


        turretHeadX = _currentTurretMappping.HeadX;
        turretHeadY = _currentTurretMappping.HeadY;
        
        shootBehaviour = _currentTurretMappping.shootBehavior;
    }

    private void Aim()
    {
        if (target != null)
        {
            Quaternion XRotation = turretHeadX.rotation;
            
            turretHeadX.LookAt(target.transform);
            turretHeadX.transform.rotation =  //lock the Y rotation of parent head the rotates around the x axis
                Quaternion.Euler(XRotation.eulerAngles.x, turretHeadX.rotation.eulerAngles.y, XRotation.eulerAngles.z);

            turretHeadY.LookAt(target.transform);
        }

    }

    private void ChangeColor(Material Material)
    {
        if (bloomStuff != null)
        {
            foreach (GameObject bloom in bloomStuff)
            {
                bloom.GetComponent<MeshRenderer>().material = Material;
            }
        }
        
    }

    protected void RemoveEnemyFromTrigger(object sender, ListChangedEventArgs e)
    {
        if (triggerSpt.enemies.Exists(enemy => enemy == e.enemy))
        {
            triggerSpt.enemies.Remove(e.enemy);
        }
    }

    //experimental Ai
    private bool EnemyEntered()
    {
        if (triggerSpt.TargetEntered)
        {
            triggerSpt.TargetEntered = false;
            return true;
        }
        return false;
    }



    private void PickTarget()
    {
        if (triggerSpt.enemies.Count > 0)
        {
            switch (targetorder)
            {
                case TargetOrder.First:
                    target = triggerSpt.enemies[0];
                    break;
                case TargetOrder.Last:
                    target = triggerSpt.enemies[triggerSpt.enemies.Count - 1];
                    break;
                case TargetOrder.Random:
                    target = triggerSpt.enemies[Random.Range(0, triggerSpt.enemies.Count)];
                    break;
                default:
                    break;
            }

            ChangeColor(TurretModel.angryColor);
        }

        
    }


    protected virtual void Shoot()
    {
        shootBehaviour.Shoot(target);
        canShoot = false;
        EnemyMoveSpt.GiveDamage(target, Damage);      
    }

    protected virtual bool TargetInRangeAndAlive()
    {
        if (triggerSpt.enemies.Contains(target) && target != null)
        {
            Aim();

            if (canShoot)
            {
                return true;
            }
            
        }     
        ChangeColor(TurretModel.chillColor);
        return false;
    }

    private void Update()
    {
        if (Activated)
        {
            AddToTimer();

            //experimental Ai
            if (EnemyEntered())
            {
                PickTarget();
            }
            if (TargetInRangeAndAlive())
            {
                //turret.Aim();
                Shoot();
            }
            else
            {
                PickTarget();
            }

            TurretModel.Projectiles.RemoveAll(proj => proj == null);
        }

        
    }

}
