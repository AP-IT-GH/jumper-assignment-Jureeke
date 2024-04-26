using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.MLAgents;
using Unity.MLAgents.Sensors;
using Unity.MLAgents.Actuators;


public class CubeAgentRaysGreen : Agent
{
    public GameObject Target;
    public GameObject Platform;

    public float speedMultiplier = 0.1f;
    public float rotationMultiplier = 5;

    private bool hasFoundEnemy = false;
    private bool inCollider = false;

    public override void OnEpisodeBegin()
    {
        Target.SetActive(true);

        //reset de positie en orientatie als de agent gevallen is
        if (this.transform.localPosition.y < 0)
        {
            this.transform.localPosition = new Vector3(0, 0.5f, 0);
            this.transform.localRotation = Quaternion.identity;
        }

        // verplaats de target naar een nieuwe willekeurige locatie 
        Target.transform.localPosition = new Vector3(Random.value * 8 - 4, 0.5f, Random.value * 8 - 4);

        hasFoundEnemy = false;
        inCollider = false;
    }
    public override void CollectObservations(VectorSensor sensor)
    {
        // Target en Agent posities
        sensor.AddObservation(Target.transform.localPosition);
        sensor.AddObservation(hasFoundEnemy);
    }

    public override void OnActionReceived(ActionBuffers actionBuffers)
    {
        // Acties, size = 2
        Vector3 controlSignal = Vector3.zero;
        controlSignal.z = actionBuffers.ContinuousActions[0];
        transform.Translate(controlSignal * speedMultiplier);
        transform.Rotate(0.0f, rotationMultiplier * actionBuffers.ContinuousActions[1], 0.0f);

        // Beloningen
        float distanceToTarget = Vector3.Distance(this.transform.localPosition, Target.transform.localPosition);

        // target bereikt
        if (distanceToTarget < 1.42f && !hasFoundEnemy)
        {
            Debug.Log("Found ball");
            SetReward(0.5f);
            Target.SetActive(false);
            hasFoundEnemy = true;
        }

        else if (hasFoundEnemy && inCollider)
        {
            Debug.Log("Found ball & in Green Zone");
            SetReward(1.0f);
            EndEpisode();
        }

        // Van het platform gevallen?
        else if (this.transform.localPosition.y < 0)
        {
            Debug.Log("Fall of platform");
            EndEpisode();
        }
    }

    public override void Heuristic(in ActionBuffers actionsOut)
    {
        var continuousActionsOut = actionsOut.ContinuousActions;
        continuousActionsOut[0] = Input.GetAxis("Vertical");
        continuousActionsOut[1] = Input.GetAxis("Horizontal");
    }

    private void OnTriggerEnter(Collider other)
    {
        inCollider = true;
    }

    private void OnTriggerExit(Collider other)
    {
        inCollider = false;
    }

}

