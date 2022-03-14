using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public abstract class NeuronState
{
    protected Brain brain;
    public NeuronState[] relatedstates;
    public virtual void INIT(Brain _brain)
    {
        brain=_brain;
    }
    public abstract void ONEXIT();
    public abstract void ONENTER();
    public abstract void ACT();
    public abstract void CHECK();
    public void TRANSITION(int i)
    {

        brain.currentstate.ONEXIT();
        brain.currentstate=i<0?brain.getBaseState(i):relatedstates[i];
        brain.currentstate.ONENTER();
    }
}
public class P_BaseNeuron:NeuronState
{
    public override void INIT(Brain _brain)
    {
            base.INIT(_brain);
            #region States
            relatedstates=new NeuronState[2];
            relatedstates[0]=new P_JumpNeuron();
            relatedstates[0].INIT(_brain);
            relatedstates[1]=new P_AttackNeuron();
            relatedstates[1].INIT(_brain);

        #endregion

    }
       public override void ACT()
    {
        Vector3 axis=new Vector3(0,0,Input.GetAxis("Horizontal"));
        brain.actor.Move(axis);
    }
    public override void CHECK()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            TRANSITION(0);
        }
        if(Input.GetKeyDown(KeyCode.Mouse0))
        {
            TRANSITION(1);
        }
    }

    public override void ONENTER()
    {
    }

    public override void ONEXIT()
    {
    }
}
public class P_JumpNeuron:NeuronState
{
   public override void INIT(Brain _brain)
    {
        base.INIT(_brain);

        relatedstates=new NeuronState[2];
    }
       public override void ACT()
    {
        Debug.Log("Jump");
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
public class P_AttackNeuron:NeuronState
{
    float timer,counter=0;
   public override void INIT(Brain _brain)
    {
        base.INIT(_brain);

        relatedstates=new NeuronState[2];

        
    }
       public override void ACT()
    {
        counter+=Time.deltaTime;
        if(counter>timer)
         TRANSITION(-1);
    }
    public override void CHECK()
    {

    }

    public override void ONENTER()
    {
        brain.actor.Attack();
        timer=brain.actor.animator.GetCurrentAnimatorClipInfo(0).Length;

    }

    public override void ONEXIT()
    {
    }
}
