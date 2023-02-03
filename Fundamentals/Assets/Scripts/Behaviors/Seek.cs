using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Seek : SteeringBehavior
{
    public Kinematic character;
    public GameObject target;

    float maxAcceleration = 100f;

    public bool flee = false;

    protected virtual Vector3 getTargetPosition()
    {
        return target.transform.position;
    }

    public override SteeringOutput getSteering()
    {
        SteeringOutput result = new SteeringOutput();
        Vector3 targetPosition = getTargetPosition();
        if (targetPosition == Vector3.positiveInfinity)
        {
            return null;
        }

        // Get the direction to the target
        if (flee)
        {
            //result.linear = character.transform.position - target.transform.position;
            result.linear = character.transform.position - targetPosition;
        }
        else
        {
            //result.linear = target.transform.position - character.transform.position;
            result.linear = targetPosition - character.transform.position;
        }

        // give full acceleration along this direction
        result.linear.Normalize();
        result.linear *= maxAcceleration;

        result.angular = 0;
        return result;
    }
}

public class Wander : Seek
{
    float delay = 1.0f;
    float elapsedTime = 4.0f;
    Vector3 result;

    protected override Vector3 getTargetPosition()
    {
        elapsedTime = Time.deltaTime;
        if(elapsedTime > delay)
        {
            int offset = 100;
            Vector3 circlePos = Random.insideUnitCircle * offset;
            Vector3 adjustedCirclePos = new Vector3(circlePos.x, 0, circlePos.y);
            result = character.transform.position + (character.transform.forward * 10) + adjustedCirclePos;
        }
        return result;
    }
}