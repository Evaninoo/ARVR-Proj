using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class ApplicationManager : MonoBehaviour
{
    public GameObject EnemyPrefab;
    public Transform camTransform;
    public int EnemyNumber = 10;
    public float SpawnRange = 3f;

   

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        SpawnEnemy();
    }

    public void SpawnEnemy()
    {
        for (int i = 0; i < EnemyNumber; i++)
        {
            float x = camTransform.position.x + Random.Range(-SpawnRange, SpawnRange);
            float y = camTransform.position.y + Random.Range(-SpawnRange, SpawnRange);
            float z = camTransform.position.z + Random.Range(-SpawnRange, SpawnRange);
            Vector3 spawnPos = new Vector3(x, y, z);
            Instantiate(EnemyPrefab, spawnPos, Quaternion.identity);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
