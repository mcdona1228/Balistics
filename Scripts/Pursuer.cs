using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pursuer : Kinematic
{
    Pursue myPursueMoveType;
    Face mySeekRotateType;
    LookWhereGoing myFleeRotateType;

    void Start()
    {
        myPursueMoveType = new Pursue();
        myPursueMoveType.character = this;
        myPursueMoveType.target = myTarget;

        mySeekRotateType = new Face();
        mySeekRotateType.character = this;
        mySeekRotateType.target = myTarget;

        myFleeRotateType = new LookWhereGoing();
        myFleeRotateType.character = this;
        myFleeRotateType.target = myTarget;
    }

    // Update is called once per frame
    protected override void Update()
    {
        steeringUpdate = new SteeringOutput();
        steeringUpdate.linear = myPursueMoveType.getSteering().linear;
        base.Update();
    }
}
