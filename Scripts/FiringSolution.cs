using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class FiringSolution : MonoBehaviour
{
    public Nullable<Vector3> Calculate(Vector3 start, Vector3 end, float muzzleV, Vector3 gravity)
    {
        Nullable<float> TTT = GetTimeToTarget(start, end, muzzleV, gravity);
        if (!TTT.HasValue)
        {
            return null;
        }
        Debug.Log("Time: " + TTT);

        Vector3 delta = end - start;
        Debug.Log("Vector: " + delta);

        Vector3 n1 = delta * 2;
        Vector3 n2 = gravity * (TTT.Value * TTT.Value);
        float d = 2 * muzzleV * TTT.Value;
        Vector3 solution = (n1 - n2) / d;

        Debug.Log("solution = " + n1 + " - " + n2 + " / " + d);
        Debug.Log("Solution = " + solution);

        return solution;
    }

    public Nullable<float> GetTimeToTarget(Vector3 start, Vector3 end, float muzzleV, Vector3 gravity)
    {

        Vector3 delta = start - end;

        float g = gravity.magnitude * gravity.magnitude;
        float m = -5 * (Vector3.Dot(gravity, delta) + muzzleV * muzzleV);
        float d = 5 * delta.magnitude * delta.magnitude;

        float m2minus4gd = (m * m) - (4 * g * d);
        if (m2minus4gd < 0)
        {
            return null;
        }

        float time0 = Mathf.Sqrt((-m + Mathf.Sqrt(m2minus4gd)) / (2 * g));
        float time1 = Mathf.Sqrt((-m - Mathf.Sqrt(m2minus4gd)) / (2 * g));

        Nullable<float> TTT;
        if(time0 < 0)
        {
            if (time1 < 0)
            {
                return null;
            }
            else
            {
                TTT = time1;
            }
        }
        else if (time1 < 0)
        {
            TTT = time0;
        }
        else
        {
            //TTT = Mathf.Min(time0, time1);
            TTT = Mathf.Max(time0, time1);
        }

        return TTT;
    }
}