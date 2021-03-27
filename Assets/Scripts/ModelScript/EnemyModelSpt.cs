using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts.ModelScript.EventArgs;

public class EnemyModelSpt : MonoBehaviour
{
    public static List<Enemy> enemiesOnScreen;
    public static event EventHandler<ListChangedEventArgs> ListChanged;

    private void Start()
    {
        enemiesOnScreen = new List<Enemy>();
        
    }

    public static void KillEnemy(Enemy enemy)
    {
        enemiesOnScreen.Remove(enemy);
        OnListChanged(new ListChangedEventArgs(enemy));
        enemy.Die();

        
    }
    protected static void OnListChanged(ListChangedEventArgs e)
    {
        ListChanged?.Invoke(null, e);
    } 
}
