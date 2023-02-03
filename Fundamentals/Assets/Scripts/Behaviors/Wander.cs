using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wander : Face
{
    public float wanderOffset = 5f;
    public float wanderRadius = 0f;
    public Vector3 center;

    public float wanderRate = 40f;

    public float wanderOrientation;
    public float targetOrientation;

    public float maxAcceleration = 2f;
    public override SteeringOutput getSteering()
    {
        SteeringOutput result = new SteeringOutput();
       
        wanderOrientation += randomBinomial() * wanderRate;
        targetOrientation = wanderOrientation + character.transform.eulerAngles.y;

        center = character.transform.position + wanderOffset * character.transform.eulerAngles;

        center += wanderRadius * new Vector3(0, targetOrientation, 0);

        result = base.getSteering();
        result.linear = maxAcceleration * character.transform.eulerAngles;

        return result;
    }

    public float randomBinomial()
    {
        return Random.Range(0, 1) - Random.Range(0, 1);
    }
}