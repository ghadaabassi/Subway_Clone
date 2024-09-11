using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class randomDouble : MonoBehaviour
{
    public GameObject[] myObjects;
    public Transform playerTransform;

    private float timer = 0f;
    private float spawnInterval = 15.7f; 

    private GameObject currentObject;

    void Update()
    {
        timer += Time.deltaTime;

        // Check if it's time to spawn a new object
        if (timer >= spawnInterval)
        {
            SpawnNewObject();
           // Debug.Log("New money Bag");
            timer = 0f; // Reset the timer
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


        Vector3 randomSpawnOffset = new Vector3(Random.Range(0, 1), (float)0.6, Random.Range(132, 135));
        Vector3 spawnDirection = playerTransform.forward.normalized;
        Vector3 randomSpawnPosition = playerPosition + spawnDirection * 10f + randomSpawnOffset * 16f;

        currentObject = Instantiate(myObjects[0], randomSpawnPosition, Quaternion.identity);
    }
}
