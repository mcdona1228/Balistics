using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follower : SteeringBehavior
{
    public Kinematic character;
    public GameObject target;
    public GameObject target2;
    public GameObject target3;
    public GameObject target4;
    public GameObject target5;
    public GameObject target6;

    float maxAcceleration = 100f;

    public bool flee = false;

    protected virtual Vector3 getTargetPosition()
    {
        return target.transform.position;
    }
    protected virtual Vector3 getTarget2Position()
    {
        return target2.transform.position;
    }
    protected virtual Vector3 getTarget3Position()
    {
        return target3.transform.position;
    }
    protected virtual Vector3 getTarget4Position()
    {
        return target4.transform.position;
    }
    protected virtual Vector3 getTarget5Position()
    {
        return target5.transform.position;
    }
    protected virtual Vector3 getTarget6Position()
    {
        return target6.transform.position;
    }

    public override SteeringOutput getSteering()
    {
        SteeringOutput result = new SteeringOutput();
        Vector3 targetPosition = getTargetPosition();
        Vector3 target2Position = getTarget2Position();
        Vector3 target3Position = getTarget3Position();
        Vector3 target4Position = getTarget4Position();
        Vector3 target5Position = getTarget5Position();
        Vector3 target6Position = getTarget6Position();

        if (targetPosition == Vector3.positiveInfinity)
        {
            return null;
        }
        if (target2Position == Vector3.positiveInfinity)
        {
            return null;
        }
        if (target3Position == Vector3.positiveInfinity)
        {
            return null;
        }
        if (target4Position == Vector3.positiveInfinity)
        {
            return null;
        }
        if (target5Position == Vector3.positiveInfinity)
        {
            return null;
        }
        if (target6Position == Vector3.positiveInfinity)
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
