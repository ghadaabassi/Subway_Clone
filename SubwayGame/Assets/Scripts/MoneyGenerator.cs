using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneyGenerator : MonoBehaviour
{
    public GameObject coinPrefab;
    public Transform playerTransform;

    private float timer = 0f;
    private float spawnInterval = 0.1f;
    private float destroyDistance = 550f;

    void Update()
    {
        timer += Time.deltaTime;
        Debug.Log("coinn ");
        if (timer >= spawnInterval)
        {
            Debug.Log("coinn ");
            SpawnNewCoin();
            timer = 0f;
        }

        // Vérifier la distance des pièces par rapport au joueur
        CheckCoinDistance();
    }

    void SpawnNewCoin()
    {

        Vector3 playerPosition = playerTransform.position;
        int[] pos = {-5,0,5};

        Vector3 randomSpawnOffset = new Vector3(pos[Random.Range(0,3)], 1.15f, Random.Range(132, 135));
        Vector3 spawnDirection = playerTransform.forward.normalized;
        Vector3 randomSpawnPosition = playerPosition + spawnDirection*3f + randomSpawnOffset * 4f;
        if((Vector3.left.x * 22) + playerTransform.position.x > -87 && (Vector3.right.x * 22) + playerTransform.position.x < -40)
        {
            Instantiate(coinPrefab, randomSpawnPosition, Quaternion.identity);
        }
        
    }

    void CheckCoinDistance()
    {
        GameObject[] coins = GameObject.FindGameObjectsWithTag("coin");
        foreach (GameObject coin in coins)
        {
            float distanceToPlayer = Vector3.Distance(coin.transform.position, playerTransform.position);
            if (distanceToPlayer > destroyDistance)
            {

                Destroy(coins[0]);
                
            }
        }
    }
}
