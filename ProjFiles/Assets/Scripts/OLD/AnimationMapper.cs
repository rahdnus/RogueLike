using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.Animations;
namespace Utils{


public class AnimationMapper 
{ 
    public void Map(AnimatorController anim)
    {
     var machine=anim.layers[0].stateMachine;
     foreach(ChildAnimatorState state in machine.states)
     {
        state.state.AddExitTransition();
        state.state.transitions[0].hasExitTime=true;
        state.state.transitions[0].exitTime=0;
        state.state.transitions[0].duration=0;

     }
    }
     public void UnMap(AnimatorController anim)
    {
     var machine=anim.layers[0].stateMachine;
     foreach(ChildAnimatorState state in machine.states)
     {
         var tranistions=state.state.transitions;
         foreach(AnimatorStateTransition transition in tranistions)
         {
         state.state.RemoveTransition(transition);

         }

     }
    }
}
}
