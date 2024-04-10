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
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E)) 
        {
            Vector3 spawnPosition = new Vector3(30, 2, 114);
            int animalIndex = Random.Range(0, animals.Length);
            //Spawns animals based on Index
            Instantiate(animals[animalIndex], spawnPosition, animals[animalIndex].transform.rotation);
        }
    }
}
