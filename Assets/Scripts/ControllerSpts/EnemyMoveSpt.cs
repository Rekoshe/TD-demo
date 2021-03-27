using UnityEngine;
using static MapModel;



public class EnemyMoveSpt : MonoBehaviour
{
    public static float newActivationDistance = 0.3f; //new for testing

    //[SerializeField] float ActivationDistance;
    //[SerializeField] float WaveSpeed;
    

    

    public void MoveEnemy()
    {
        //Enemy enemySpt;
        //int tracker;
        //Vector3 currentPosition;
        //Vector3 waypointInfront;
        //float distance;
        //space 

        if (EnemyModelSpt.enemiesOnScreen.Count > 0)
        {
            foreach (Enemy enemy in EnemyModelSpt.enemiesOnScreen)
            {

                //enemy.UpdateBillBoard(CameraSwitcher.ActiveCamera);
            }
        }
    }

    public static void GiveDamage(Enemy enemy, int damage)
    {
        if (enemy != null)
        {
            enemy.TakeDamage(damage);
        }
    }

    public static Transform GiveTarget(ref int tracker, Lane lane, Enemy enemy) //returns which target to go for anyone that requests
    {
        //passed by reference so that the controller has control over the enemy tracker
        //passing enemy reference should be removed 
        tracker++;
        if (tracker > Lanes[(int)lane].Count - 1)
        {
            EnemyModelSpt.KillEnemy(enemy);
            return null;
        }
        else
        {
            return Lanes[(int)lane][tracker];
        }
        
    }
}
