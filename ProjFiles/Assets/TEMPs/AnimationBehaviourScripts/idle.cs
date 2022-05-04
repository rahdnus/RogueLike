using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Core.Actor;
public class idle : StateMachineBehaviour
{
    [SerializeField] float radius=1.0f;
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
       animator.transform.GetComponent<Pathfinding.AIPath>().canMove=true;
       var player=FindObjectOfType(typeof(Controller)) as Controller;

            float angle=Random.Range(45,135);
        float x=radius*Mathf.Cos(angle*Mathf.Deg2Rad);
        float y=radius*Mathf.Sin(angle*Mathf.Deg2Rad);

        Vector3 destination=new Vector3(player.transform.position.x,player.transform.position.y,0)+new Vector3(x,y,0);
        animator.transform.GetComponent<Pathfinding.AIPath>().destination=destination;
        
  
    }
      override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if(animator.transform.GetComponent<Pathfinding.AIPath>().reachedDestination)
        {
            animator.transform.GetComponent<Pathfinding.AIPath>().canMove=false;
            animator.SetTrigger("next");

        }
    }
}
