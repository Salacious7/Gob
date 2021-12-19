using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    #region Variables
    public GameObject prefab;
    public GameObject spawnPosition;
    private float spawnCD = 0;
    public float spawnInterval;
    #endregion

    void Update()
    {
        spawnCD -= 1 * Time.deltaTime;
        if (spawnCD <= 0)
        {
            SpawnEnemy();    
        }  
    }

    void SpawnEnemy()
    {
        Instantiate(prefab, spawnPosition.transform.transform.position, spawnPosition.transform.rotation);
        spawnCD = spawnInterval;
    }
}
