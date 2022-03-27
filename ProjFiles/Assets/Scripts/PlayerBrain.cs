using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Neurons;
using Neurons.PlayerNeurons;

public class PlayerBrain : Brain
{
    bool attackFlag,jumpFlag;
    public override void Init(Actor actor)
    {
        base.Init(actor);

        basestate=new NeuronState[1];
        basestate[0]=new P_BaseNeuron();

        damagestates=new DamageNeuronState();
        damagestates=new P_DamageNeuron();
        damagestates.INIT(this);

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
    namespace PlayerNeurons{
public class P_BaseNeuron:NeuronState
{
    Player player;
    int attackCounter,noOfAttacks;
    float nextattackWait=.7f,counter=0;
    Vector3 axis;
    public override void INIT(Brain _brain)
    {

        base.INIT(_brain);
        player=brain.actor as Player; 
        noOfAttacks=_brain.actor.moves.animationNames.Length;
        attackCounter=0;
        #region States

            relatedstates=new NeuronState[2+noOfAttacks+1];
            relatedstates[0]=new P_JumpNeuron(0);
            relatedstates[0].INIT(_brain);
            relatedstates[1]=new P_JumpNeuron(1);
            relatedstates[1].INIT(_brain);
            for(int i=1;i<=noOfAttacks;i++)
            {
            relatedstates[i+1]=new P_AttackNeuron(i-1);
            relatedstates[i+1].INIT(_brain);
            }
            
            relatedstates[5]=new P_FallNeuron();
            relatedstates[5].INIT(_brain);

        #endregion

    }
    public override void ACT()
    {
        axis=new Vector3(0,0,Input.GetAxis("Horizontal"));
        brain.actor.Move(axis,0);
    }
    public override void CHECK()
    {
        player.CheckGround();
        counter+=Time.deltaTime;
        if(counter>nextattackWait)
        {
            attackCounter=0;
            brain.actor.animator.applyRootMotion=false;
            counter=0;
        }
          if(Input.GetKeyDown(KeyCode.Mouse0))
        {
            // Debug.Log("wtf");
            TRANSITION(attackCounter+2);
            attackCounter=(attackCounter+2)%noOfAttacks;
        }
        if(Input.GetKeyDown(KeyCode.Space))
        {
            if(axis!=Vector3.zero)
            TRANSITION(1);
            else 
            TRANSITION(0);
        }
        if(!player.CheckGround(0.2f))
        {
            TRANSITION(5);
        }
        
      

    }

    public override void ONENTER()
    {
        counter=0;
    }

    public override void ONEXIT()
    {
        counter=0;
    }
}
public class P_JumpNeuron:NeuronState
{
    int index;
    float counter,timer;
    int secondframe;
    public P_JumpNeuron(int _index)
    {
        this.index=_index;
        counter=0;
        timer=-1;
        secondframe=0;
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
            if(index==1)
                brain.actor.animator.applyRootMotion=true;
            Debug.Log(brain.actor.animator.GetCurrentAnimatorClipInfo(0)[0].clip.name + brain.actor.animator.GetCurrentAnimatorClipInfo(0)[0].clip.length);
        }
        else
            secondframe += 1;
        
      
    }
    public override void CHECK()
    {  
          if (timer != -1)
        {
            counter += Time.deltaTime;
            if (counter > timer)
            {
                TRANSITION(-1);
            }
        }
    }

    public override void ONENTER()
    {
       var player= brain.actor as Player;
       player.Jump(index);
    }

    public override void ONEXIT()
    {
        counter=0;
        timer=-1;
        secondframe=0;
            brain.actor.animator.applyRootMotion=false;

    }
}
public class P_FallNeuron:NeuronState
{
    bool hitground;
    Vector3 axis;
    Player player;
    // float counter,timer,transitioncounter,transitiontimer;
    // int secondframe;
    public P_FallNeuron()
    {
        // counter=0;
        // timer=-1;
        // secondframe=0;
    }
    public override void INIT(Brain _brain)
    {
        base.INIT(_brain);
        relatedstates=new NeuronState[2];
        player=_brain.actor as Player;
        // transitioncounter=0;
        // transitiontimer=0.25f;
        // timer=-1;
    }
    public override void ACT()
    {
        axis=new Vector3(0,0,Input.GetAxis("Horizontal"));
        // brain.actor.Move(axis,3);
    }
    public override void CHECK()
    {  
         if(player.CheckGround(-0.5f))
        {
           TRANSITION(-1);
        }
    }
    public override void ONENTER()
    {
        player.Fall();
        player.setMoveSpeed(1);
    }
    public override void ONEXIT()
    {
        player.resetMoveSpeed();
        // counter=0;
        // timer=-1;
        // secondframe=0;
        // transitioncounter=0;
        // brain.actor.animator.applyRootMotion=false;
    }
}
public class P_AttackNeuron:NeuronState
{
    float timer=-1,counter=0;
    float returnOffset;
    int secondframe=0;
    private int index;
    public P_AttackNeuron(int _index)
    {
        this.index=_index;
        returnOffset=0.7f;
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
            timer = brain.actor.animator.GetCurrentAnimatorClipInfo(0)[0].clip.length-returnOffset;
            // brain.actor.animator.applyRootMotion=true;
            brain.actor.currentAnimationName=brain.actor.animator.GetCurrentAnimatorClipInfo(0)[0].clip.name ;
            // Debug.Log(brain.actor.animator.GetCurrentAnimatorClipInfo(0)[0].clip.name + brain.actor.animator.GetCurrentAnimatorClipInfo(0)[0].clip.length);
        }
        else
            secondframe += 1;
        

      
      
    }
    public override void CHECK()
    {
        if (timer != -1)
        {
            counter += Time.deltaTime;
            if (counter > timer)
            {
                TRANSITION(-1);
            }
        }
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
    }
}
public class P_DamageNeuron:DamageNeuronState
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
    }
    public override void CHECK()
    {
        if(counter>timer)
        {
         TRANSITION(-1);
         counter=0;
        }
    }

    public override void ONENTER()
    {
        brain.actor.TakeDamage();
        timer=brain.actor.animator.GetCurrentAnimatorClipInfo(0)[0].clip.length;
        Debug.Log(brain.actor.animator.GetCurrentAnimatorClipInfo(0)[0].clip.name+brain.actor.animator.GetCurrentAnimatorClipInfo(0)[0].clip.length);
        Debug.Log(currentattackDirection);
        Debug.Log(timer);

    }

    public override void ONEXIT()
    {
    }
}
}
}


