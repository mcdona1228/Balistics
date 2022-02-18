using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathFinder : Kinematic
{
    Find myMoveType;
    Face mySeekRotationType;
    LookWhereGoing myFleeRotateType;

    public GameObject[] myTargets;

    void Start()
    {
        myMoveType = new Find();
        myMoveType.character = this;
        myMoveType.targets = myTargets;

        mySeekRotationType = new Face();
        mySeekRotationType.character = this;
        mySeekRotationType.target = myTarget;
    }
    protected override void Update()
    {
        steeringUpdate = new SteeringOutput();
        steeringUpdate.linear = myMoveType.getSteering().linear;
        steeringUpdate.angular = mySeekRotationType.getSteering().angular;
        base.Update();
    }
}
