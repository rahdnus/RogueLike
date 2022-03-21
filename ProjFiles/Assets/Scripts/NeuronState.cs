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
public class P_BaseNeuron:NeuronState
{
    int attackCounter,noOfAttacks;
    public override void INIT(Brain _brain)
    {

        base.INIT(_brain);
            
        noOfAttacks=_brain.actor.moves.animationNames.Length;
        attackCounter=0;
        #region States

            relatedstates=new NeuronState[1+noOfAttacks];
            relatedstates[0]=new P_JumpNeuron();
            relatedstates[0].INIT(_brain);
            for(int i=1;i<=noOfAttacks;i++)
            {
            relatedstates[i]=new P_AttackNeuron(i-1);
            relatedstates[i].INIT(_brain);
            }

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
            // Debug.Log("wtf");
            TRANSITION(attackCounter+1);
            attackCounter=(attackCounter+1)%noOfAttacks;
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
    float timer=-1,counter=0;
    int secondframe=0;
    private int index;
    public P_AttackNeuron(int _index)
    {
        this.index=_index;
    }

    public override void INIT(Brain _brain)
    {
        base.INIT(_brain);
        relatedstates=new NeuronState[2];
    }
       public override void ACT()
    {
        if (secondframe == 2 && timer==-1)
        {
            //Because Unity Fuking sucks ass 
            //animator takes a frame to switch to new animation so getanimatorclip always return old animation
            timer = brain.actor.animator.GetCurrentAnimatorClipInfo(0)[0].clip.length;
            brain.actor.animator.applyRootMotion=true;
            Debug.Log(brain.actor.animator.GetCurrentAnimatorClipInfo(0)[0].clip.name + brain.actor.animator.GetCurrentAnimatorClipInfo(0)[0].clip.length);
        }
        else
            secondframe += 1;
        
        if (timer != -1)
        {
            counter += Time.deltaTime;
            if (counter > timer)
            {
                TRANSITION(-1);
            }
        }
      
      
    }
    public override void CHECK()
    {
    }

    public override void ONENTER()
    {
        brain.actor.Attack(index);
      
    }

    public override void ONEXIT()
    {
        counter=0;
        timer=-1;
        secondframe=0;
        brain.actor.animator.applyRootMotion=false;


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

}
