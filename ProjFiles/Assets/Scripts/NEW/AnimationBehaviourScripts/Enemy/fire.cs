
using UnityEngine;
namespace Core{
namespace Actor{namespace _Enemy{namespace States{
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
}}}}
