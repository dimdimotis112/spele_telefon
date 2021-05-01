using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileManager : MonoBehaviour
{  // Ceļš spawnojamis
    public GameObject[] tilePrefabs;
    private List<GameObject> activeTiles = new List<GameObject>();
    private float  spawnPos = 0;
    private float tileLength = 100;
	private int lastPrefabIndex = 0;

    [SerializeField] private Transform player;
    private int startTiles = 6;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < startTiles; i++)
        {
            SpawnTile(Random.Range(0, tilePrefabs.Length));
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (player.position.z - 60 > spawnPos - (startTiles * tileLength))
        {
            SpawnTile(Random.Range(0, tilePrefabs.Length));
            DeleteTile();
        }
    }

    private void SpawnTile(int tileIndex)
    {
        GameObject go;
		go = Instantiate (tilePrefabs [RandomPrefabIndex()]) as GameObject;
        go.transform.SetParent (transform);
		go.transform.position = Vector3.forward * spawnPos;
		spawnPos += tileLength;
		activeTiles.Add (go);
    }
    private void DeleteTile()
    {
        Destroy(activeTiles[0]);
        activeTiles.RemoveAt(0);
    }
	
	private int RandomPrefabIndex()
	{
		if(tilePrefabs.Length <= 1)
			return 0;
		
		int randomIndex = lastPrefabIndex;
		while(randomIndex == lastPrefabIndex)
		{
			randomIndex = Random.Range(0,tilePrefabs.Length);
		}
		
		lastPrefabIndex = randomIndex;
		return randomIndex;
	}
	
	}