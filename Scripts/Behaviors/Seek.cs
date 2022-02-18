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

public class Find : Seek
{
    public GameObject[] targets ;
    private int targetIndex = 0;
    Vector3 distance;

    protected override Vector3 getTargetPosition()
    {
        distance = targets[targetIndex].transform.position - character.transform.position;
        if (distance.magnitude <= 1.5f)
        {
            targetIndex = (targetIndex + 1) % targets.Length;
            return targets[targetIndex].transform.position;
        }
        else
        {
            return targets[targetIndex].transform.position;
        }
    }
}

public class Drunk : Seek
{
    Vector3 result;

    protected override Vector3 getTargetPosition()
    {
        int offset = 50;
        Vector3 circlePos = Random.insideUnitCircle * offset;
        Vector3 adjustCircle = new Vector3(circlePos.x, 0, circlePos.y);
        result = character.transform.position + (character.transform.forward * 3) + adjustCircle;
        Debug.Log(result);
        return result;
    }
}
