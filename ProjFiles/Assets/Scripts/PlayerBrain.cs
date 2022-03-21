using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Neurons;

public class PlayerBrain : Brain
{
    bool attackFlag,jumpFlag;
    public override void Init(Actor actor)
    {
        base.Init(actor);

        basestate=new NeuronState[1];
        basestate[0]=new P_BaseNeuron();

        damagestates=new NeuronState[1];
        damagestates[0]=new P_DamageNeuron();
        damagestates[0].INIT(this);

        currentstate=basestate[0];
        currentstate.INIT(this);
       
    }
    public override void Tick()
    {
        currentstate.ACT();
        currentstate.CHECK();
    }
}

