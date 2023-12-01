using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public GameObject prefabToSpawn;

    void Start()
    {
        SpawnNewPrefab();
        SpawnNewPrefab();
    }

    void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {
            SpawnNewPrefab();
        }
    }

    void SpawnNewPrefab()
    {
        // Belirli pozisyonlara spawnlamak istedi�imiz yerleri bir dizi i�inde tan�mlay�n
        Vector3[] spawnPositions = new Vector3[]
        {
            new Vector3(0f, 1f, 0f),
            new Vector3(2.5f, 1f, 0f),
            new Vector3(-2.5f, 1f, 0f),
            new Vector3(5f, 1f, 0f),
            new Vector3(-5f, 1f, 0f),
            new Vector3(0f, 1f, 2.5f),
            new Vector3(-2.5f, 1f, 2.5f),
            new Vector3(2.5f, 1f, 2.5f),
            new Vector3(-5f, 1f, 2.5f),
            new Vector3(5f, 1f, 2.5f),
            new Vector3(0f, 1f, -2.5f),
            new Vector3(2.5f, 1f, -2.5f),
            new Vector3(-2.5f, 1f, -2.5f),
            new Vector3(5f, 1f, -2.5f),
            new Vector3(-5f, 1f, -2.5f),
            new Vector3(0f, 1f, -5f),
            new Vector3(2.5f, 1f, -5f),
            new Vector3(-2.5f, 1f, -5f),
            new Vector3(5f, 1f, -5f),
            new Vector3(-5f, 1f, -5f),
            new Vector3(0f, 1f, 5f),
            new Vector3(2.5f, 1f, 5f),
            new Vector3(-2.5f, 1f, 5f),
            new Vector3(5f, 1f, 5f),
            new Vector3(-5f, 1f, 5f)
        };

        // Rastgele bir pozisyon se�in
        Vector3 randomPosition = spawnPositions[Random.Range(0, spawnPositions.Length)];

        // Yeni prefab'� se�ilen pozisyonda spawnlay�n
        Instantiate(prefabToSpawn, randomPosition, Quaternion.identity);
    }
}