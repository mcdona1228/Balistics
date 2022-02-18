using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionAvoidance : SteeringBehavior
{
    public Kinematic character;
    public float maxAcceleration = 1f;
    public Kinematic[] targets;
    float radius = .5f; 

    public override SteeringOutput getSteering()
    {

        float shortestTime = float.PositiveInfinity;
        float firstMinSeparation = float.PositiveInfinity;
        float firstDistance = float.PositiveInfinity;

        Kinematic firstTarget = null;
        Vector3 firstRelativePos = Vector3.positiveInfinity;
        Vector3 firstRelativeVel = Vector3.zero;

        Vector3 relativePos = Vector3.positiveInfinity;

        SteeringOutput result = new SteeringOutput();

        foreach (Kinematic target in targets)
        {

            relativePos = target.transform.position - character.transform.position;

            Vector3 relativeVel = character.linearVelocity - target.linearVelocity;
            float relativeSpeed = relativeVel.magnitude;
            float timeToCollision = (Vector3.Dot(relativePos, relativeVel) / (relativeSpeed * relativeSpeed));


            float distance = relativePos.magnitude;
            float minSeparation = distance - relativeSpeed * timeToCollision;
            if (minSeparation > 2 * radius)
            {
                continue;
            }

            if (timeToCollision > 0 && timeToCollision < shortestTime)
            {

                shortestTime = timeToCollision;
                firstDistance = distance;
                firstRelativePos = relativePos;
                firstRelativeVel = relativeVel;
                firstTarget = target;
                firstMinSeparation = minSeparation;
            }
        }

        if (firstTarget == null)
        {
            return null;
        }

        float dotResult = Vector3.Dot(character.linearVelocity.normalized, firstTarget.linearVelocity.normalized);
        if (dotResult < -0.9)
        {

            result.linear = new Vector3(character.linearVelocity.z, 0.0f, character.linearVelocity.x);
        }
        else
        {
            result.linear = -firstTarget.linearVelocity;
        }
        result.linear.Normalize();
        result.linear *= maxAcceleration;
        result.angular = 0;
        return result;
    }
}