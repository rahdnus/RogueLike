using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Actor
{
    [SerializeField] GameObject A_pointerSFX;
    public GameObject Fireprefab;
    public Transform arm,launchpoint;
    public Skill[] skill=new Skill[2];

    public override void Start()
    {
        base.Start();

       var vfx= Instantiate(A_pointerSFX,transform.position,Quaternion.identity);
        Destroy(vfx,3f);

       skill[0]=new FireHand
                    (this,Fireprefab,arm,true,0,
                    "ActivateSkill","Attack"); 
    }
    public override void Attack(int index)
    {
        // skill[0].Init(this);
        // animator.Play("Attack",0);
    }
    public void ActivateSkill(int i)
    {
        skill[0].Use();
    }
    public override void Dodge()
    {
        throw new System.NotImplementedException();
    }

    public override void Move(Vector3 axis,int falling)
    {
        throw new System.NotImplementedException();
    }

    public override void TakeDamage()
    {
        animator.Play("Hurt1",0);
        Debug.Log(gameObject.name+" being attacked");
    }
}
