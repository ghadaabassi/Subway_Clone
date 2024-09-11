using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class randomObjects : MonoBehaviour
{
    public GameObject[] myObjects;
    public Transform playerTransform;

    private float timer = 0f;
    private float spawnInterval = 6.8f; 

    private GameObject currentObject;

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= spawnInterval)
        {
            SpawnNewObject();
            timer = 0f; 
        }
    }

    void SpawnNewObject()
    {
        
        if (currentObject != null)
        {
            Destroy(currentObject);
        }

        int randomIndex = Random.Range(0, myObjects.Length * 7);

        Vector3 playerPosition = playerTransform.position;


        Vector3 randomSpawnOffset = new Vector3(Random.Range(0, 2), 0, Random.Range(131, 135));
        Vector3 spawnDirection = playerTransform.forward.normalized;
        Vector3 randomSpawnPosition = playerPosition + spawnDirection * 10f + randomSpawnOffset * 16f;

        
        currentObject = Instantiate(myObjects[0], randomSpawnPosition, Quaternion.identity);
    }
}
