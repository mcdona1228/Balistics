using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SocialDistancer : Kinematic
{
    Separation myMoveType;

    public Kinematic[] cooties;

    void Start()
    {
        myMoveType = new Separation();
        myMoveType.character = this;
        myMoveType.targets = cooties;

    }

    protected override void Update()
    {
        steeringUpdate = new SteeringOutput();
        steeringUpdate.linear = myMoveType.getSteering().linear;
        base.Update();
    }
}
