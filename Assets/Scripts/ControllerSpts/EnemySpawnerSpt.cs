using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnerSpt : MonoBehaviour
{
    private int random;
    public IEnumerator SpawnWave(List<Enemy> enemies, float timeBetweenEach)
    {
        foreach (Enemy enemy in enemies)
        {
            Enemy thisEnemy = Instantiate(enemy);
            thisEnemy.transform.position = MapModel.Lanes[(int)thisEnemy.Lane][0].position;
            thisEnemy.transform.rotation = MapModel.Lanes[(int)thisEnemy.Lane][0].rotation;


            //Enemy thisEnemy = Instantiate(enemy);
            //if (enemy.lane == Enemy.Lane.Median)
            //{
            //    thisEnemy.lane = Enemy.Lane.Median;
            //    thisEnemy.waypoints = MapModel.Lanes[0];

            //}
            //else
            //{
            //    thisEnemy.lane = Enemy.Lane.Lateral;
            //    random = Random.Range(1, MapModel.Lanes.Count);
            //    thisEnemy.waypoints = MapModel.Lanes[random];

            //}

            //thisEnemy.transform.position = thisEnemy.waypoints[0].position;
            //thisEnemy.Tracker += 1;
            EnemyModelSpt.enemiesOnScreen.Add(thisEnemy);


            //Enemy ee = EnemyModelSpt.enemiesOnScreen.Find(x => x == thisEnemy);




            yield return new WaitForSeconds(timeBetweenEach);
            //start corotine


        }

        
    }


    //debug only
    //public void SpawnWave(Enemy enemy)
    //{
    //    Enemy thisEnemy = Instantiate(enemy);
    //    thisEnemy.transform.position = MapModel.waypoints[0].position;
    //    thisEnemy.Tracker += 1;
    //    EnemyModelSpt.enemiesOnScreen.Add(thisEnemy);
        
    //}
    
 
}
