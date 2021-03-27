using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class OnTookDamage : UnityEvent<int>
{

}

public class Enemy : MonoBehaviour
{
    [SerializeField] GameObject BillBoard;
    
    //public int Tracker;
    public int Tracker { get { return _tracker; } private set { _tracker = value;} }
    public MapModel.Lane Lane { get { return _lane; } private set { _lane = value; } }

    private int _tracker; //backing private field for Tracker
    [SerializeField] private MapModel.Lane _lane = MapModel.Lane.Medium;

    public Transform Target { get; private set; } 

    

    public float Speed = 1;
    public bool ReachedTheEnd { get; private set; }
    //public List<Transform> waypoints;
    //public Lane lane; deprecated
    public int Health;

    //private Vector3 _position; 
    //private Transform _moveTarget;
    //private Vector3 _ab;

    //private float _distance;
    public OnTookDamage OnTookDamage;


    protected EnemyMoveSpt MoveController;

    //public enum Lane //deprecated
    //{
    //    Median,
    //    Lateral
    //}


    // Start is called before the first frame update
    void Start()
    {
        ReachedTheEnd = false;
        OnTookDamage = new OnTookDamage();
    }

    public void Heal(int health) { }
    public void TakeDamage(int damage)
    {
        Health -= damage;
        OnTookDamage.Invoke(Health);
        if (Health <= 0)
        {
            Die();
        }
    }

    public void Die()
    {
        Destroy(gameObject);
    }

    public void UpdateBillBoard(Camera camera)
    {
        BillBoard.transform.LookAt(camera.transform);
    }

    //new waypoint managment system start
    protected void RequestTarget()
    {
        Target = EnemyMoveSpt.GiveTarget(ref _tracker, _lane, this);
        //Debug.Log("new target is " + Target.position);

    }
    protected void ChangeOrientation() 
    {
        if(Target != null)
        {
            transform.LookAt(Target.position);
        }
        
        //Debug.Log("looking at " + Target.position);
    }
    protected void Move() 
    {
        Vector3 _myposition = transform.position;
        Vector3 _targetPosition = Target.position;
        Vector3 _vectorToTarget = _targetPosition - _myposition;
        _vectorToTarget.Normalize();

        transform.Translate(_vectorToTarget * Speed * Time.deltaTime, Space.World);
        //Debug.Log("moving towards" + Target.position);
    }
    protected bool HasReachedTarget()
    {
        float _distance; 
        _distance = Vector3.Distance(transform.position, Target.position);  

        if (_distance <= EnemyMoveSpt.newActivationDistance)
        {
            return true;
        }
        return false;
    }
    //new waypoint managment system end

    void Update()
    {
        if (Target == null)
        {
            RequestTarget();
            
        }
        else if (!HasReachedTarget())
        {
            Move();
            
            //Debug.Log("target is " + Target.position);

        }
        else
        {
            
            RequestTarget();
            ChangeOrientation();
        }
    }
}
