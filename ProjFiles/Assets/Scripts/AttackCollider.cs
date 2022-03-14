using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackCollider : MonoBehaviour
{
    [SerializeField]Status status;
    void OnCollisionEnter(Collision other)
   {
       if(!other.gameObject.GetComponentInParent<Player>())
       if(other.gameObject.GetComponent<CringeBall>())
       {
           Debug.Log("wtf");
           other.gameObject.GetComponent<Rigidbody>().AddForce(transform.forward*50,ForceMode.Impulse);
       }
   }
    void OnTriggerEnter(Collider other)
   {
       if(!other.gameObject.GetComponentInParent<Player>())
       if(other.gameObject.GetComponent<Actor>())
       {
           Debug.Log("wtf");
           StatusEffect effect=null;

           if(status==Status.Burn)
           {
                if(!other.gameObject.GetComponent<BurnStatus>())
                    effect= other.gameObject.AddComponent<BurnStatus>();
           }
         
            if(effect!=null)
            effect.Init(other.gameObject.GetComponent<Actor>(),0.5f,3f);

        //    other.gameObject.GetComponent<Rigidbody>().AddForce(transform.forward*50,ForceMode.Impulse);
       }
   }
}
