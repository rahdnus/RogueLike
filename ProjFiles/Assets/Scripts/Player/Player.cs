using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Actor
{
        public Transform arm;
        public Transform launchpoint;
        public GameObject Fireprefab;
        public Skill[] skill=new Skill[2];

    public override void Start()
    {
        skill[0]=new ElementalDash(this,Fireprefab,arm,true,0,"UseSkill","Dash");
        skill[1]=new FireHand(this,Fireprefab,arm,true,1,"UseSkill","Launch"); 
        base.Start();
    }    
    public override void Move(Vector3 axis)
    {
        if(axis.z>0)
        {
            transform.localRotation=Quaternion.Euler(transform.localRotation.x,0,transform.localRotation.z);
        }
        else if(axis.z<0)
        {
            transform.localRotation=Quaternion.Euler(transform.localRotation.x,-180,transform.localRotation.z);
        }
        transform.position+=new Vector3(axis.y,axis.y,axis.z)*MovementSpeed*Time.deltaTime;
    }
    public override void Attack()
    {
        skill[1].Init(this);
        animator.Play("Launch");
        // skill[0].Init(this);
        // animator.Play("Dash");
    }
    public void UseSkill(int index)
    {
        skill[index].Use();
    }
    public override void Dodge()
    {
        Debug.Log("Yo");
    
        animator.Play("dodge");
    }
    public void SetCollider(int status)
    {
          foreach(Collider collider in colliders)
        {
            collider.enabled=status==1;
        }
    }
    // public void LaunchAttack()
    // {
    //     var fire=Instantiate(Fireprefab,launchpoint.position,launchpoint.rotation);
    // }
    public void BoxCast()
    {
        // RaycastHit hit;
        // Physics.Raycast(arm.position,transform.forward,out hit,5f);
        // if(hit.collider)
        // if(hit.collider.gameObject.GetComponent<CringeBall>())
        // {
        //     Debug.Log("fuk u");
        //   hit.collider.GetComponent<Rigidbody>().AddForce(transform.forward*10,ForceMode.Impulse);
        // }
    }
    void OnDrawGizmosSelected()
    {
    }
}
