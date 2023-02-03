using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sperator : Kinematic
{
    Separation myMoveType;
    public Kinematic[] myTargets;

    void Start()
    {
        myMoveType = new Separation();
        myMoveType.character = this;
        myMoveType.targets = myTargets;
    }

    protected override void Update()
    {
        steeringUpdate = new SteeringOutput();
        steeringUpdate.linear = myMoveType.getSteering().linear;
        base.Update();
    }
}
