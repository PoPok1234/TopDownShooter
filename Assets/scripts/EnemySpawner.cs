using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private Transform[] spawnPoints;
    private Enemy[] ememies;
    [SerializeField] private GameObject[] enemy;
    private float timer = 5f;
    public bool isPistol { get; set; }
    public bool isEnemyPistol { get; set; }

    private void Awake()
    {
        isPistol = true;
        isEnemyPistol = true;
    }

    void Update()
    {
        ememies = FindObjectsOfType<Enemy>();
        timer -= Time.deltaTime;
        if(ememies.Length < 10 && timer <= 0)
        {
            int currentSpawnPoint = Random.Range(0, 3);
            int currentEnemy = Random.Range(0, 1);
            Instantiate(enemy[currentEnemy], spawnPoints[currentSpawnPoint]);
            timer = 5f;
            if (currentEnemy == 0)
                isEnemyPistol = true;
            else
                isEnemyPistol = false;
        }
    }
}
