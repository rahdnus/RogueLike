using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Actor
{
    public GameObject Fireprefab;
    public Transform arm,launchpoint;
    public Skill[] skill=new Skill[2];

    public override void Start()
    {
        skill[0]=new ElementalDash
                    (this,Fireprefab,arm,true,0,
                    "ActivateSkill","Dash");
        skill[1]=new FireHand
                    (this,Fireprefab,arm,true,1,
                    "ActivateSkill","Launch"); 
        base.Start();
    }    
    public override void Move(Vector3 axis)
    {
        float rotation=axis.z>0?0:-180;

        transform.localRotation=Quaternion.Euler(transform.localRotation.x,rotation,transform.localRotation.z);
        transform.position+=new Vector3(axis.y,axis.y,axis.z)*MovementSpeed*Time.deltaTime;
    }
    public override void Attack()
    {
        skill[1].Init(this);
        animator.Play("Launch");
        // skill[0].Init(this);
        // animator.Play("Dash");
    }
    public override void Dodge()
    {    
        animator.Play("dodge");
    }
    public void ActivateSkill(int index)
    {
        skill[index].Use();
    }
    public void SetCollider(int status)
    {
          foreach(Collider collider in colliders)
        {
            collider.enabled=status==1;
        }
    }
    void OnDrawGizmosSelected()
    {
    }
}
