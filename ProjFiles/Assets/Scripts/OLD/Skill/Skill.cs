using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Skill 
{
    protected Actor actor;
    protected Transform spawnTransform;
    protected bool parent;
    protected GameObject skillprefab;
    int skillindex=-1;
    string eventName="", animationName="";

    public Skill(Actor _actor,GameObject _skillprefab,Transform _spawnTransform,bool _parent,int _skillindex,string _eventName,string _animationName)
    {
        this.actor=_actor;
        this.spawnTransform=_spawnTransform;
        this.parent=_parent;
        this.skillprefab=_skillprefab;
        this.animationName=_animationName;
        this.eventName=_eventName;
        this.skillindex=_skillindex;
    }
    public void Init(Actor actor)
    {
        AnimationEvent[] Events=null;
        var clips=actor.animator.runtimeAnimatorController.animationClips;
        int j=0;
        for(int i=0;i<clips.Length;i++)
        {
            if(clips[i].name==animationName)
            {
                Events=clips[i].events;
                j=i;
                break;
            }
        }
        int k=-1;
        for(int i=0;i<Events.Length;i++)
        {
            if(Events[i].functionName==eventName)
            {
                Events[i].intParameter=skillindex;
                k=i;
                break;
            }
        }
        if(k!=-1)
        {
            actor.animator.runtimeAnimatorController.animationClips[j].events=Events;
            actor.animator.Rebind();
        }
    
    }
    public virtual void Use(){
        GameObject skillSpawn=GameObject.Instantiate(skillprefab,spawnTransform.position,skillprefab.transform.rotation);        
        if(parent)
        {
            skillSpawn.transform.SetParent(spawnTransform);
        }
        GameObject.Destroy(skillSpawn,2f);
    } 
}
