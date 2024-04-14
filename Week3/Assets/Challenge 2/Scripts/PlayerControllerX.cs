using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerX : MonoBehaviour
{
    public GameObject dogPrefab;
    public float dogCD = 1f;

    public bool canUseDog;

    // Update is called once per frame
    void Update()
    {
        dogCD -= Time.deltaTime;
        // On spacebar press, send dog
        if (Input.GetKeyDown(KeyCode.Space) && canUseDog)
        {
            Instantiate(dogPrefab, transform.position, dogPrefab.transform.rotation);
            dogCD = 1f;
        }

        if (dogCD <= 0)
        {
            canUseDog = true;
        }
        else
        {
            canUseDog = false; 
        }
    }
}
