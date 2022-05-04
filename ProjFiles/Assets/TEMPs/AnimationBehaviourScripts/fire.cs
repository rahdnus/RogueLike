using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fire : StateMachineBehaviour
{
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
       animator.transform.GetComponent<Hanabi.Spawner>().SyncSpawn();
    }
     override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if(animator.transform.GetComponent<Hanabi.Spawner>().destinationreached)
            {
                animator.SetTrigger("next");
            }
    }
}
