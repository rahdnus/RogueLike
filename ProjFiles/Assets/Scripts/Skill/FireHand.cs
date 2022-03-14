using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireHand : Skill
{

    public FireHand(Actor _actor,GameObject _skillprefab,Transform _spawnTransform,bool _parent,int _skillindex,string _eventName,string _animationName):
    base(_actor,_skillprefab,_spawnTransform,_parent,_skillindex,_eventName,_animationName){}
    public override void Use(){
       base.Use();
    }

}
