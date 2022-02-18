using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrioritySteering : MonoBehaviour
{
    float epsilon = 1f;

    public BlendedSteering[] groups;

    public SteeringOutput getSteering()
    {
        SteeringOutput steering = new SteeringOutput();
        foreach (BlendedSteering group in groups)
        {
            steering = group.getSteering();

            if (steering.linear.magnitude > epsilon || Mathf.Abs(steering.angular) > epsilon)
            {
                return steering;
            }
        }
        return steering;
    }
}
