using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBrain : Brain
{
    bool attackFlag,jumpFlag;
    public override void Init(Actor actor)
    {
        base.Init(actor);

        basestate=new NeuronState[1];
        basestate[0]=new P_BaseNeuron();
        currentstate=basestate[0];

        currentstate.INIT(this);
       
    }
    public override void Tick()
    {
        currentstate.ACT();
        currentstate.CHECK();
    }

}
