using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Actor
{
    #region misc
    float prevrotation=0;
    float resttimer=0.2f,restcounter=0;
    bool atrest=true;
    #endregion
    public GameObject Fireprefab;
    public Transform arm,launchpoint,foot;
    [SerializeField]LayerMask groundmask;
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
    public override void Move(Vector3 axis,int falling)
    {
        float rotation=prevrotation;
        if (axis.z != 0){
            restcounter = 0;
            rotation = axis.z > 0 ? 0 : -180;
            if (atrest)
            {
                if(falling==0)
                {
                    animator.CrossFade("Run",0.5f, 0);
                    atrest = false;
                }
                   
            }
        }
        else{
            restcounter += Time.deltaTime;
            if (restcounter > resttimer)
            {
                if(falling==0)
                {
                    animator.CrossFade("rest",0.5f,0);
                    atrest = true;
                }
                   
                restcounter = 0;
            }
        }
        // Debug.Log(rotation);
        if(prevrotation!=rotation){prevrotation=rotation;}

        
        transform.localRotation=Quaternion.Euler(transform.localRotation.x,rotation,transform.localRotation.z);
        transform.position=transform.position+new Vector3(0,0,axis.z)*movementSpeed*Time.deltaTime;
    }
    public override void Attack(int index)
    {
        animator.Play(moves.attacks[index].animationName,0);
        // skill[1].Init(this);
        // animator.Play("Launch");
        // skill[0].Init(this);
        // animator.Play("Dash");
    }
    public void Jump(int index)
    {
        atrest=true;//so that run animation can play
        if(index==0)
        {
            animator.Play("standJump");
        }
        else if(index==1)
        {
            animator.Play("runJump");
        }
    }
    public void Fall()
    {
        atrest=true;    
        animator.CrossFade("Fall",0.2f,0,0.3f);
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
    public override void Hurt()
    {
        animator.Play("Hurt",0);
        Debug.Log(gameObject.name+" being attacked");
    }
    public bool CheckGround(float yoffset=0)
    {
        RaycastHit hit;
        float coyote=prevrotation!=0?1:-1;
        Vector3 offset=new Vector3(0,yoffset,coyote);
        // Debug.Log(coyote);
        return Physics.Raycast(foot.position+offset, Vector3.down,out hit,0.5f, groundmask);
        // Debug.Log(hit.collider.gameObject.name);

    }

}
