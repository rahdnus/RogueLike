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
public class P_DamageNeuron:NeuronState
{
    float timer,counter=0;
   public override void INIT(Brain _brain)
    {
        base.INIT(_brain);
        relatedstates=new NeuronState[2];

    }
       public override void ACT()
    {
        Debug.Log("in act");
        counter+=Time.deltaTime;
        if(counter>timer)
        {
         TRANSITION(-1);
         counter=0;
        }
    }
    public override void CHECK()
    {
    }

    public override void ONENTER()
    {
        brain.actor.TakeDamage();
        timer=brain.actor.animator.GetCurrentAnimatorClipInfo(0)[0].clip.length;
        Debug.Log(brain.actor.animator.GetCurrentAnimatorClipInfo(0)[0].clip.name+brain.actor.animator.GetCurrentAnimatorClipInfo(0)[0].clip.length);

        Debug.Log(timer);

    }

    public override void ONEXIT()
    {
    }
}
