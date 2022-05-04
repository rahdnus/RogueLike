using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Neurons{
[System.Serializable]
public abstract class NeuronState
{
    protected Brain brain;
    public NeuronState[] relatedstates;
    public virtual void INIT(Brain _brain)
    {
        brain=_brain;
    }
    public abstract void ONEXIT();public abstract void ONENTER();
    public abstract void ACT();public abstract void CHECK();
    public void TRANSITION(int i)
    {
        brain.currentstate.ONEXIT();
        brain.currentstate=i<0?brain.getBaseState(i):relatedstates[i];
        brain.currentstate.ONENTER();
    }
}
    public class DamageNeuronState : NeuronState
    {
       protected attackDirecton currentattackDirection;
        public void SetDirection(attackDirecton directon)
        {
            currentattackDirection=directon;
        }
        public override void ACT()
        {
        }

        public override void CHECK()
        {
        }

        public override void ONENTER()
        {
        }

        public override void ONEXIT()
        {
        }
    }
}
