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
  
        currentstate=basestate[0];

        currentstate.INIT(this);
        // rootstate.relatedstates=new NeuronState[1];
        // rootstate.relatedstates[0]=new NeuronState();
        // rootstate.relatedstates[0].Init(actor.Dodge);
        // currentstate.CHECK(this);
        // currentstate.ACT();
       
    }

    public override void Tick()
    {
        currentstate.ACT();
        currentstate.CHECK();
    }
    void CHeckMOve()
    {
       
    }
    void CheckAttack()
    {
        if(Input.GetKeyDown(KeyCode.Mouse0) && attackFlag==false)
        {
            actor.Attack();
            attackFlag=true;
            StartCoroutine(BSRTimer(false,0.3f));
        }
    }
    void CheckDodge()
    {
        if(Input.GetKey(KeyCode.Space)&&(Input.GetKeyDown(KeyCode.S)||Input.GetKeyDown(KeyCode.A)||Input.GetKeyDown(KeyCode.D)))
        {
           actor.Dodge();
        }
    }
    IEnumerator BSRTimer(bool _status=false,float waitime=1f)
    {
        yield return new WaitForSeconds(waitime);
        attackFlag=_status;
    }
}
