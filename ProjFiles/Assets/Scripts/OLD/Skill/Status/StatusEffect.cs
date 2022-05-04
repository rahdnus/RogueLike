using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public  class StatusEffect:MonoBehaviour 
{
   protected Actor targetactor;
    protected float fadetime=3.0f,waittime=1.0f;
    protected float fadecounter=0f,waitcounter=0f;
    void Update()
    {
        waitcounter+=Time.deltaTime;
        if(waitcounter>waittime)
        {
            waitcounter=0;
            Enact();
        }
        fadecounter+=Time.deltaTime;
        if(fadecounter>fadetime)
        {
            fadecounter=0;
            Destroy(this);
        }
    }

    public void Init(Actor _actor,float _waittime,float _fadetime)
    {
        this.targetactor=_actor;
        this.waittime=_waittime;
        this.fadetime=_fadetime;
    }
  public virtual void Enact()
  {
      return;
  }
}
public enum Status{
    None,Burn,Stunned
}
