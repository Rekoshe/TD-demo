using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerSpt : MonoBehaviour
{
    public List<Enemy> enemies;
    public bool TargetEntered;
    public bool TargetExited;
    private void OnTriggerEnter(Collider other)
    {
        //Debug.Log("enemy entered");
        if (other.gameObject.TryGetComponent(out Enemy enemy))
        {
            enemies.Add(enemy);
            TargetEntered = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.TryGetComponent(out Enemy enemy))
        {
            enemies.Remove(enemy);
            TargetExited = true;
        }
    }

}
