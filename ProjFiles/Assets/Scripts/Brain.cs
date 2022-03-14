using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Brain : MonoBehaviour
{
    public Actor actor;
    [SerializeField]protected NeuronState[] basestate;
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
}