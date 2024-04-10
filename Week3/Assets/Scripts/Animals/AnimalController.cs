using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class AnimalController : MonoBehaviour
{
    public NavMeshAgent agent;
    public float followDistance;

    GameManager gameManager;
    private bool isFed = false;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        gameManager = GameObject.FindGameObjectWithTag("GM").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {

        if (isFed && Vector3.Distance(GameObject.FindGameObjectWithTag("Player").transform.position, transform.position) <= followDistance) 
        {
            agent.destination = GameObject.FindGameObjectWithTag("Player").transform.position;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Food")
        {
            isFed = true;
            Destroy(other.gameObject);
        }

        if (other.tag == "Finish")
        {
            gameManager.score += 1;
            Debug.Log(gameManager.score);
            Destroy(gameObject);
        }
    }

}
