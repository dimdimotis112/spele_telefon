using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{

	
	// Objekti spawnojamis
	public GameObject[] objectPrefabs;
	private List<GameObject> activeObjects = new List<GameObject>();
	private float OspawnPos = 0;
	private int lastObjectIndex = 0;
	private float objectLength = 50;
	
	[SerializeField] private Transform player;
	private int startObjects = 6;
    // Start is called before the first frame update
    void Start()
    {
        for (int l = 0; l < startObjects; l++)
		{
			SpawnObject(Random.Range(0, objectPrefabs.Length));
		}
    }

    // Update is called once per frame
    void Update()
    {
        if (player.position.z - 60 > OspawnPos - (startObjects * objectLength))
		{
			SpawnObject(Random.Range(0, objectPrefabs.Length));
			DeleteObject();
		}
    }
	private void SpawnObject(int objectIndex)
	{
		GameObject go;
		go = Instantiate (objectPrefabs [RandomObjectIndex()]) as GameObject;
		go.transform.SetParent (transform);
		go.transform.position = Vector3.forward * OspawnPos;
		OspawnPos += objectLength;
		activeObjects.Add (go);
	}
	private void DeleteObject()
	{
		Destroy(activeObjects[0]);
		activeObjects.RemoveAt(0);
	}
	private int RandomObjectIndex()
	{
		if (objectPrefabs.Length <= 1)
			return 0;
		
		int randomIndex = lastObjectIndex;
		while(randomIndex == lastObjectIndex)
		{
			randomIndex = Random.Range(0,objectPrefabs.Length);
		}
		lastObjectIndex = randomIndex;
		return randomIndex;
	}
}
