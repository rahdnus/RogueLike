using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Neurons;

public class EnemyBrain : Brain
{
    public override void Init(Actor actor)
    {
        base.Init(actor);

        basestate=new NeuronState[1];
        basestate[0]=new EN_BaseNeuron();

        damagestates=new NeuronState[1];
        damagestates[0]=new EN_DamageNeuron();
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
namespace Neurons{
public class EN_BaseNeuron:NeuronState
{
    float counter=0;
    float time=2f;
    public override void INIT(Brain _brain)
    {
            base.INIT(_brain);
            #region States
            relatedstates=new NeuronState[2];
            relatedstates[0]=new EN_JumpNeuron();
            relatedstates[0].INIT(_brain);
            relatedstates[1]=new EN_AttackNeuron();
            relatedstates[1].INIT(_brain);

        #endregion

    }
       public override void ACT()
    {
        // Vector3 axis=new Vector3(0,0,Input.GetAxis("Horizontal"));
        // brain.actor.Move(axis);
    }
    public override void CHECK()
    {
        counter+=Time.deltaTime;
        if(counter>time)
        {
            counter=0;
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
public class EN_JumpNeuron:NeuronState
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
public class EN_AttackNeuron:NeuronState
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
        brain.actor.Attack(0);
        timer=brain.actor.animator.GetCurrentAnimatorClipInfo(0).Length;

    }

    public override void ONEXIT()
    {
    }
}
public class EN_DamageNeuron:NeuronState
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
    }

    public override void ONEXIT()
    {
    }
}
}
