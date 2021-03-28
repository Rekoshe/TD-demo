using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneController : MonoBehaviour
{
    [SerializeField] Enemy _prefab;

    [SerializeField] GameObject MapController;
    [SerializeField] GameObject EnemyController;
    [SerializeField] GameObject TurretController;
    [SerializeField] GameObject UIController;


    MapController MapControllerSpt;
    EnemySpawnerSpt enemySpawnerSpt;
    EnemyMoveSpt enemyMoveSpt;
    List<Enemy> enemies;
    [SerializeField] int NumberOfEnemies;
    [SerializeField] float timeScale = 1;

 
    // Start is called before the first frame update
    void Start()
    {
        Application.targetFrameRate = 60;
        enemySpawnerSpt = EnemyController.GetComponent<EnemySpawnerSpt>();
        enemyMoveSpt = EnemyController.GetComponent<EnemyMoveSpt>();
        


        //loading stuff goes here

        MapControllerSpt = MapController.GetComponent<MapController>();
        MapControllerSpt.ListWaypoints();

        //_prefab.lane = Enemy.Lane.Lateral;

        enemies = new List<Enemy>();

        for (int i = 0; i < NumberOfEnemies; i++)
        {
            enemies.Add(_prefab);
        }

        StartCoroutine(enemySpawnerSpt.SpawnWave(enemies, 1));

        Time.timeScale = timeScale;


        
    }
     
    // Update is called once per frame
    void Update()
    {
            
        enemyMoveSpt.MoveEnemy();
        
    }
}
