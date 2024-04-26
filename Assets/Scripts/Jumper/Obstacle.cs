using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    private float Movespeed = 1;
    public CubeAgentJumper agent;

    private void Update()
    {
        Movespeed = Random.Range(2f, 9f);
        this.transform.Translate(Vector3.back * Movespeed * Time.deltaTime);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("wall") == true)
        {
            Debug.Log("Award Recieved");
            agent.JumpSuccess();
            Destroy(this.gameObject);
        }
    }
}
