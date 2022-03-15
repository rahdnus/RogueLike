using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackCollider : MonoBehaviour
{
    [SerializeField] LayerMask mask;
    [SerializeField]Status status;
//     void OnCollisionEnter(Collision other)
//    {
//        Debug.Log(other.gameObject.layer);
//        if(!other.gameObject.GetComponentInParent<Player>())
//        if(other.gameObject.GetComponent<CringeBall>())
//        {
//            Debug.Log("wtf");
//            other.gameObject.GetComponent<Rigidbody>().AddForce(transform.forward*50,ForceMode.Impulse);
//        }
//    }
    void OnTriggerEnter(Collider other)
   {

       int otherlayer=1<<other.gameObject.layer;
        if((otherlayer & mask.value)>0)
       {
           Debug.Log(other.gameObject.name+" "+this.gameObject.name);
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
