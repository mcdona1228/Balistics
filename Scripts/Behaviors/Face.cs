using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Face : Align
{

    // TODO: override Align's getTargetAngle to face the target instead of matching it's orientation
    public override float getTargetAngle()
    {
        // --- replace me ---

       Vector3 velocity = target.transform.position - character.transform.position;
       if (velocity.magnitude == 0)
           return character.transform.rotation.y;

       float targetAngle = Mathf.Atan2(velocity.x, velocity.z);
        targetAngle *= Mathf.Rad2Deg;
        // ------------------

        return targetAngle;
    }
}
