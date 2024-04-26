using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.MLAgents;
using Unity.MLAgents.Sensors;
using Unity.MLAgents.Actuators;


public class CubeAgentJumper : Agent
{
    public float force;
    public Transform reset = null;
    private Rigidbody rb = null;
    private bool ground = false;

    public override void Initialize()
    {
        rb = this.GetComponent<Rigidbody>(); 
        ResetMyAgent();
    }

    public override void OnEpisodeBegin()
    {
        ResetMyAgent();
    }

    public override void OnActionReceived(ActionBuffers actions)
    {
        var DiscreteActions = actions.DiscreteActions;
        if (DiscreteActions[0] == 1)
        {
            UpForce();
        }
    }
     
    public override void Heuristic(in ActionBuffers actionsOut)
    {
        var DiscreteActions = actionsOut.DiscreteActions;
        DiscreteActions[0] = 0;
        if (Input.GetKey(KeyCode.Space))
            DiscreteActions[0] = 1;
    }

    private void OnCollisionStay(Collision collision)
    {
        if(collision.gameObject.CompareTag("obstacle") == true)
        {
            AddReward(-1.0f);
            Destroy(collision.gameObject);
            EndEpisode();
        }
        if (collision.gameObject.CompareTag("ground") == true)
        {
            AddReward(0.2f);
            ground = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("ground") == true)
        {
            ground = false;
        }
    }

    private void UpForce()
    {
        if (ground)
        {
            rb.AddForce(Vector3.up * force, ForceMode.Force);
        }
        
    }

    private void ResetMyAgent()
    {
        this.transform.position = new Vector3(reset.position.x, reset.position.y, reset.position.z);
    }

    public void JumpSuccess()
    {
        Debug.Log("Award Recieved");
        AddReward(0.4f);
    }

}

