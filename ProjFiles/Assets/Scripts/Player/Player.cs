using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Actor
{
    float prevrotation=0;
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
        float rotation=prevrotation;
        if(axis.z>0)
        {
            rotation=0;
            prevrotation=rotation;
        }
        else if(axis.z<0)
        {
            rotation=-180;
            prevrotation=rotation;
        }
        transform.localRotation=Quaternion.Euler(transform.localRotation.x,rotation,transform.localRotation.z);
        transform.position+=new Vector3(axis.y,axis.y,axis.z)*MovementSpeed*Time.deltaTime;
    }
    public override void Attack(int index)
    {
        animator.Play(moves.animationNames[index],0);
        // skill[1].Init(this);
        // animator.Play("Launch");
        // skill[0].Init(this);
        // animator.Play("Dash");
    }
    public void Jump(int index)
    {
        if(index==0)
        {
            animator.Play("standJump");

        }
        else if(index==1)
        {
            animator.Play("runJump");
        }
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

    public override void TakeDamage()
    {

        animator.Play("Hurt",0);

        Debug.Log(gameObject.name+" being attacked");
    }
}
