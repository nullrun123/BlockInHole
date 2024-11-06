using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObject : MonoBehaviour
{
    public GameObject[] objects;
    public float minSpawnTime, maxSpawnTime;
    public bool spawnMovingObjects = false;

    void Start()
    {
        if (spawnMovingObjects)
        {
            SpawnMovingObjects();
        }
        else
        {
            SpawnStaticObjects();
        }
    }

    void SpawnMovingObjects()
    {
        Instantiate(objects[Random.Range(0, objects.Length)], transform);

        Invoke("SpawnMovingObjects", Random.Range(minSpawnTime, maxSpawnTime));
        
    }

    void SpawnStaticObjects()
    {
        Instantiate(objects[Random.Range(0,objects.Length)], new Vector3(Random.Range(-5,5),0,transform.position.z),Quaternion.identity);
    }
}
