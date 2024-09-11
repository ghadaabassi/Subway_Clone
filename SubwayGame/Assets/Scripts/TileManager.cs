using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class TileManager : MonoBehaviour
{
    public GameObject[] tilePrefabs;
    public float zSpawn = 0;
    public int numbertiles = 5;
    public Transform playerTransform;
    private List<GameObject> activeTiles = new List<GameObject>();

    //public GameObject subwayPrefab;
    float tileLength;
    int nbtiles;
    
    // Set a minimum distance between tile spawns
    public float minDistanceBetweenTiles = 5000f;

    // Flag to control tile spawning
    private bool canSpawnTile = true;

    // Distance from the player at which tiles will be destroyed
    public float destroyDistance = 8000f;

    void Start()
    {
        for (int i = 0; i < numbertiles - 2; i++)
        {
            SpawnTile(0);
        }
    }

    void Update()
    {
      
        if (canSpawnTile && playerTransform.position.z > zSpawn - minDistanceBetweenTiles)
        {
            SpawnTile(Random.Range(0, tilePrefabs.Length));

            canSpawnTile = false;

            StartCoroutine(ResetSpawnFlag());
        }

        if (activeTiles.Count > 0 && playerTransform.position.z > activeTiles[0].transform.position.z + destroyDistance)
        {
            DeleteTile();
        }
    }

    
    IEnumerator ResetSpawnFlag()
    {
      
        yield return new WaitForSeconds(0.0f); 
        canSpawnTile = true;
    }

    public void SpawnTile(int index)
    {
        GameObject tilePrefab = tilePrefabs[index];

        Vector3 spawnPosition = new Vector3(0, 0, zSpawn);

        GameObject spawnedTile = Instantiate(tilePrefab, spawnPosition, Quaternion.identity);

        spawnedTile.transform.Rotate(Vector3.up, 180f);



        tileLength = 50;
        Debug.Log(tileLength);


        activeTiles.Add(spawnedTile);

        zSpawn += 5077;
    }


    private void DeleteTile()
    {
        Destroy(activeTiles[0]);
        activeTiles.RemoveAt(0);
    }
}