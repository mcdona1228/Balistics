using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flock : Kinematic
{
    public bool avoidObstacles = false;
    public GameObject cohereTarget;
    BlendedSteering mySteering;
    PrioritySteering advancedSteering;
    Kinematic[] birbs;

    void Start()
    {
        Separation seperate = new Separation();
        seperate.character = this;
        GameObject[] begoneBirbs = GameObject.FindGameObjectsWithTag("birb");
        birbs = new Kinematic[begoneBirbs.Length - 1];
        int j = 0;
        for (int i=0; i < begoneBirbs.Length-1; i++)
        {
            if(begoneBirbs[i] == this)
            {
                continue;
            }
            birbs[j++] = begoneBirbs[i].GetComponent<Kinematic>();
        }
        seperate.targets = birbs;

        Arrive cohere = new Arrive();
        cohere.character = this;
        cohere.target = cohereTarget;

        LookWhereGoing myRotateType = new LookWhereGoing();
        myRotateType.character = this;

        mySteering = new BlendedSteering();
        mySteering.behaviors = new BehaviorAndWeight[3];
        mySteering.behaviors[0] = new BehaviorAndWeight();
        mySteering.behaviors[0].behavior = seperate;
        mySteering.behaviors[0].weight = 10f;
        mySteering.behaviors[1] = new BehaviorAndWeight();
        mySteering.behaviors[1].behavior = cohere;
        mySteering.behaviors[1].weight = 3f;
        mySteering.behaviors[2] = new BehaviorAndWeight();
        mySteering.behaviors[2].behavior = myRotateType;
        mySteering.behaviors[2].weight = 8f;
        
        ObstacleAvoidance myAvoid = new ObstacleAvoidance();
        myAvoid.character = this;
        myAvoid.target = cohereTarget;
        myAvoid.flee = true;
        BlendedSteering highPrioritySteering = new BlendedSteering();
        highPrioritySteering.behaviors = new BehaviorAndWeight[1];
        highPrioritySteering.behaviors[0] = new BehaviorAndWeight();
        highPrioritySteering.behaviors[0].behavior = myAvoid;
        highPrioritySteering.behaviors[0].weight = 1f;

        advancedSteering = new PrioritySteering();
        advancedSteering.groups = new BlendedSteering[2];
        advancedSteering.groups[0] = new BlendedSteering();
        advancedSteering.groups[0] = highPrioritySteering;
        advancedSteering.groups[1] = new BlendedSteering();
        advancedSteering.groups[1] = mySteering;
        
    }
    protected override void Update()
    {
        steeringUpdate = new SteeringOutput();
        steeringUpdate = mySteering.getSteering();
        base.Update();
    }
}
