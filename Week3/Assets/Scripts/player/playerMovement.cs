using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SocialPlatforms;

public class playerMovement : MonoBehaviour
{
    float horizontalInput;
    float verticalInput;

    public float moveSpeed = 10f;
    public float xRange;
    public float zRange;
    public Vector3 offset;

    public GameObject ProjectilePrefab;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        //Get Inputs
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");

        //Translate Movement
        transform.Translate(Vector3.right * horizontalInput * moveSpeed * Time.deltaTime);
        transform.Translate(Vector3.forward * verticalInput * moveSpeed * Time.deltaTime);

        //Keep player in bounds
        if (transform.position.x > xRange)
        {
            transform.position = new Vector3(xRange, transform.position.y, transform.position.z);
        }
        if (transform.position.x < -xRange)
        {
            transform.position = new Vector3(-xRange, transform.position.y, transform.position.z);
        }
        if (transform.position.z > zRange)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, zRange);
        }
        if (transform.position.z < -zRange)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, -zRange);
        }

        //Launch Projectile
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GameObject steak = Instantiate(ProjectilePrefab, transform.position + offset, ProjectilePrefab.transform.rotation);
            Destroy(steak, 3);
        }
    }

    void OnTriggerEnter(Collider other)
        {
        if (other.tag == "Animal")
        {
         Debug.Log("Game Over");
        }
    }
}

