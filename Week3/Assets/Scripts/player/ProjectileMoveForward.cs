using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileMoveForward : MonoBehaviour
{
    GameManager gameManager;
    public float speed = 40f;
    public float gravity = .1f;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.FindGameObjectWithTag("GM").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
        transform.Translate(Vector3.down * gravity * Time.deltaTime);

    }
 }

