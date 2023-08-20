using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public Transform[] spawnPositions;
    [SerializeField] private GameObject enemy;
    public static EnemySpawner current;
    public GridLayout gridLayout;

    [SerializeField] private List<Enemy> enemies= new List<Enemy>();

    public void Awake()
    {
        current = this;
    }
    public void SpawnEnemy()
    {
        Vector3 mySpawnPos = spawnPositions[Random.Range(0, spawnPositions.Length)].position;
        Instantiate(enemy, mySpawnPos, Quaternion.identity);
    }

    public void SpawnEnemyTemp()
    {
        foreach (Transform spawnPos in spawnPositions) 
        {
            GameObject newEnemy = Instantiate(enemy, spawnPos.position, Quaternion.identity);
            newEnemy.GetComponentInChildren<Enemy>().KillIn30();
        }
    }
}
