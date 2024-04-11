using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animalSpawner : MonoBehaviour
{
    public GameObject[] animals;
    

    public float xRange, zRange;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnRandomAnimal", 5, 10);
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    void SpawnRandomAnimal()
    {
        Vector3 spawnPosition = new Vector3(Random.Range(-xRange, xRange), 0 , zRange);
        int animalIndex = Random.Range(0, animals.Length);
        //Spawns animals based on Index
        Instantiate(animals[animalIndex], spawnPosition, animals[animalIndex].transform.rotation);
    }
}
