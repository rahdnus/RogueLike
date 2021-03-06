using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Neurons;
public abstract class Brain : MonoBehaviour
{
    public Actor actor;
    [SerializeField]protected NeuronState[] basestate;
    protected DamageNeuronState damagestates;
    protected NeuronState dieState;
    public NeuronState currentstate;
    public virtual void Init(Actor _actor)
    {
        this.actor=_actor;
    }
    public abstract void Tick();
    public NeuronState getBaseState(int i)
    {
        int index=Mathf.Abs(i)-1;
        return basestate[index];
    }
    public virtual void BeingAttacked(attackDirecton directon,int damage)
    {
        currentstate.ONEXIT();
        damagestates.SetDirection(directon);
        
        int value=actor.CalculateDamage(damage);
        actor.Modifiyhealth(value);

        if(actor.health<=0)
        {
            currentstate=dieState;
        }
        else
        {
            currentstate=damagestates;
        }

        currentstate.ONENTER();
    }
}
