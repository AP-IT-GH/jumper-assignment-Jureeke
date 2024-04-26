using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject prefab = null;
    public Transform spawn = null;
    public float minTime = 1.0f;
    public float maxTime = 3.0f;
    private void Start()
    {
        Invoke("SpawnObstacle", Random.Range(minTime, maxTime));
     //   agent = GameObject.FindGameObjectWithTag("Player").GetComponent<CubeAgentJumper>();
       
    }
    private void SpawnObstacle()
    {
        //instantiate new spawn
        GameObject go = Instantiate(prefab);
        go.transform.parent = gameObject.transform.parent;
        go.transform.position = spawn.position;
        //go.transform.position = new Vector3(spawn.position.x, spawn.position.y, spawn.position.z);

        //set agent to obstacle component of new spawn
        CubeAgentJumper agent = transform.parent.gameObject.GetComponentInChildren<CubeAgentJumper>();
        go.GetComponent<Obstacle>().agent = agent;
       
        Invoke("SpawnObstacle", Random.Range(minTime, maxTime));
    }
}
