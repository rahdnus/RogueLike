using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Actor : MonoBehaviour
{
    public AttackMoves moves;
    public int health=100;
    [SerializeField] protected float baseMovementSpeed; 
    protected float movementSpeed;
    [SerializeField] public Brain brain;
    protected Rigidbody rb;
    public Animator animator;
    
    public string currentAnimationName;
    [SerializeField]protected Collider[] colliders;

    public virtual void Start()
    {
        animator=GetComponent<Animator>();
        rb=GetComponent<Rigidbody>();
        brain.Init(this);
        Utils.AnimationMapper mapper=new Utils.AnimationMapper();
        movementSpeed=baseMovementSpeed;
        // mapper.UnMap(animator.runtimeAnimatorController as UnityEditor.Animations.AnimatorController);
        // mapper.Map(animator.runtimeAnimatorController as UnityEditor.Animations.AnimatorController);
    }

    public virtual void Update()
    {
        brain.Tick();
    }
    public abstract void Move(Vector3 axis,int falling);
    public abstract void Attack(int index);
    public abstract void Dodge();
    public void setMoveSpeed(float newMoveSpeed)
    {
        movementSpeed=newMoveSpeed;
    }
    public void resetMoveSpeed()
    {
        movementSpeed=baseMovementSpeed;
    }
    public abstract void Hurt();
    public virtual int CalculateDamage(int damage){
        return damage;
    }
    public void Modifiyhealth(int value)
    {
        if(health<0)
            return;
        health-=value;
        // if(health<=0)
        // {
        //     Die();
        // }
    }
    public virtual void Die()
    {
        Destroy(gameObject);
    }
}
