using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileManager : MonoBehaviour
{
    public GameObject[] tilePrefabs;
    public float xSpawn = 0;
    public float ySpawn = 0;
    public float zSpawn = 0;
    public float tileLength = 44;
    // Start is called before the first frame update
    void Start()
    {
        SpawnTile(0);
        SpawnTile(1);
        SpawnTile(2);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void SpawnTile(int tileIndex)
    {
        Instantiate(tilePrefabs[tileIndex],transform.forward * zSpawn, transform.rotation);
        zSpawn += tileLength;
        //ySpawn += tileLength;
    }
}
