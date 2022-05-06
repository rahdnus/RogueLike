using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Core{

namespace Actor{namespace _Player{namespace States{
public class Idle : StateMachineBehaviour
{
    Player controller;
    [SerializeField]float j_timer=0,j_holdtime=0.25f;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
       controller=animator.GetComponent<Player>();
    }
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
       
        if(j_timer!=0)
        Debug.Log(j_timer);

        controller.horizontal= Input.GetAxis("Horizontal");

        if(!controller.jump)
        {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(controller.groundcheck.position, 0.2f, LayerMask.GetMask("Ground"));
		for (int i = 0; i < colliders.Length; i++)
		{
    		if (colliders[i].gameObject != animator.gameObject)
			{
				controller.grounded = true;
				controller.j_count=0;
                j_timer=0;
			}
        }
        }
       

        if(Input.GetKeyDown(KeyCode.Space)&&(controller.grounded||controller.j_count<2))
        {
            controller.j_count++;
            controller.jump=true;
            controller.grounded=false;
            j_timer=0;
            // Debug.Log(j_count);
        }

        else if(Input.GetKeyUp(KeyCode.Space))
        {
            j_timer=0;
            controller.jump=false;
        }
        if(controller.jump)
        {
            j_timer+=Time.deltaTime;
            if(j_timer>j_holdtime)
            {
                controller.jump=false;
                j_timer=0;
            }
        }
    }
  override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        controller.jump=false;
        controller.j_count=0;
        controller.horizontal=0;
    }

}

    }
}
}
}
