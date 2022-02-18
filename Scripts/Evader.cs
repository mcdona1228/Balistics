using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Evader : Kinematic
{
    Pursue myPursueMoveType;
    Face mySeekRotateType;
    LookWhereGoing myFleeRotateType;
    public bool flee = false;

    void Start()
    {
        myPursueMoveType = new Pursue();
        myPursueMoveType.character = this;
        myPursueMoveType.target = myTarget;
        myPursueMoveType.flee = flee;

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
        steeringUpdate.angular = flee ? myFleeRotateType.getSteering().angular : mySeekRotateType.getSteering().angular;
        base.Update();
    }
}
