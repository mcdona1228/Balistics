using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BehaviorAndWeight
{
    public SteeringBehavior behavior = null;
    public float weight = 0f;
}

public class BlendedSteering
{
    public BehaviorAndWeight[] behaviors;

    float maxRotation = 5f;
    float maxAcceleration = 1f;

    public SteeringOutput getSteering()
    {
        SteeringOutput result = new SteeringOutput();

        foreach (BehaviorAndWeight b in behaviors)
        {
            SteeringOutput s = b.behavior.getSteering();
            if (s != null)
            {
                result.angular += s.angular * b.weight;
                result.linear += s.linear * b.weight;
            }
        }

        result.linear = result.linear.normalized * maxAcceleration;
        float angularAcceleration = Mathf.Abs(result.angular);
        if(angularAcceleration > maxRotation)
        {
            result.angular /= angularAcceleration;
            result.angular *= maxRotation;
        }

        return result;
    }
}
