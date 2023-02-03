using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wanderer : Kinematic
{
    public Wander myRotateType;

    void Start()
    {
        myRotateType = new Wander();
        myRotateType.character = this;
        myRotateType.target = myTarget;
    }

    // Update is called once per frame
    protected override void Update()
    {
        steeringUpdate = new SteeringOutput();
        steeringUpdate.angular = myRotateType.getSteering().angular;
        base.Update();
    }
}