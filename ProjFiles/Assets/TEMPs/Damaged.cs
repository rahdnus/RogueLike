using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damaged : StateMachineBehaviour
{
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Physics2D.IgnoreLayerCollision(LayerMask.NameToLayer("Player"),LayerMask.NameToLayer("Bullet"),true);
        // Debug.Log(Physics2D.GetIgnoreLayerCollision(LayerMask.NameToLayer("Player"),LayerMask.NameToLayer("Bullet")));
    }
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Physics2D.IgnoreLayerCollision(LayerMask.NameToLayer("Player"),LayerMask.NameToLayer("Bullet"),false);
        // Debug.Log(Physics2D.GetIgnoreLayerCollision(LayerMask.NameToLayer("Player"),LayerMask.NameToLayer("Bullet")));

    }

}
