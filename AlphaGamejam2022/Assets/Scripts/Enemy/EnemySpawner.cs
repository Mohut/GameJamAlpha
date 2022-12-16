using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using Random = UnityEngine.Random;


public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject enemyPrefeb;
    [SerializeField] private float spawnrate;
    [SerializeField] private int xmax;
    [SerializeField] private int ymax;

    [SerializeField] private int minDistance;
    
    
    private float spawnx;
    private float spawny;
    private float randomx;
    private float randomy;
    
    void Start()
    {
       StartCoroutine(SpawnEnemy());
    }
    // Update is called once per frame
    void Update()
    {

    }

    private Vector2 GetSpawnLocation()
    {
        spawnx = Random.Range(minDistance, xmax);
        spawny = Random.Range(minDistance, ymax);
        
        randomx = Random.Range(0, 2);
        randomy = Random.Range(0, 2);
        if (randomx == 0)
        {
            spawnx = -spawnx;
        }
        if (randomy == 0)
        {
            spawny = -spawny;
        }

        

        return new Vector2(spawnx, spawny);
    }

    IEnumerator SpawnEnemy()
    {
        while (true)
        {
            Vector2 spawnLocation = GetSpawnLocation();
            Instantiate(enemyPrefeb, spawnLocation, quaternion.identity);
            yield return new WaitForSeconds(spawnrate/100);
        }
    }
}
